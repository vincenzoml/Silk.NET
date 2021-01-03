// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Silk.NET.Core.Native;
using Silk.NET.Vulkan;
using Silk.NET.Vulkan.Extensions.KHR;
using Buffer = Silk.NET.Vulkan.Buffer;
using Semaphore = Silk.NET.Vulkan.Semaphore;

namespace Aliquip
{
    internal sealed class DrawFrameService : IHostedService, IObserver<WindowRender>, IDisposable
    {
        private const int MaxFramesInFlight = 2;
        
        private readonly IWindowProvider _windowProvider;
        private readonly Vk _vk;
        private readonly ILogicalDeviceProvider _logicalDeviceProvider;
        private readonly ISwapchainProvider _swapchainProvider;
        private readonly KhrSwapchain _khrSwapchain;
        private readonly IGraphicsQueueProvider _graphicsQueueProvider;
        private readonly IPresentQueueProvider _presentQueueProvider;
        private readonly ISwapchainRecreationService _recreationService;
        private readonly ICommandBufferFactory _commandBufferFactory;
        private readonly IGraphicsCommandBufferProvider _graphicsCommandBufferProvider;
        private readonly IGraphicsPipelineFactory _graphicsPipelineFactory;
        private readonly ILogger _logger;
        private IDisposable _subscription;
        private readonly Semaphore[] _imageAvailableSemaphores;
        private readonly Semaphore[] _renderFinishedSemaphores;
        private readonly Fence[] _inFlightFences;
        private readonly Fence[] _imagesInFlight;
        private int _currentFrame = 0;
#if DEBUG
        private readonly float _nanosecondsPerTimestampStep;
        private uint _lastTime;
#endif

        public unsafe DrawFrameService
        (
            IWindowProvider windowProvider,
            Vk vk,
            ILogicalDeviceProvider logicalDeviceProvider,
            ISwapchainProvider swapchainProvider,
            KhrSwapchain khrSwapchain,
            IGraphicsQueueProvider graphicsQueueProvider,
            IPresentQueueProvider presentQueueProvider,
            ISwapchainRecreationService recreationService,
            ICommandBufferFactory commandBufferFactory,
            IGraphicsCommandBufferProvider graphicsCommandBufferProvider,
            IGraphicsPipelineFactory graphicsPipelineFactory,
            IPhysicalDeviceProvider physicalDeviceProvider,
            ILogger<DrawFrameService> logger
        )
        {
            _windowProvider = windowProvider;
            _vk = vk;
            _logicalDeviceProvider = logicalDeviceProvider;
            _swapchainProvider = swapchainProvider;
            _khrSwapchain = khrSwapchain;
            _graphicsQueueProvider = graphicsQueueProvider;
            _presentQueueProvider = presentQueueProvider;
            _recreationService = recreationService;
            _commandBufferFactory = commandBufferFactory;
            _graphicsCommandBufferProvider = graphicsCommandBufferProvider;
            _graphicsPipelineFactory = graphicsPipelineFactory;
            _logger = logger;

            _imageAvailableSemaphores = new Semaphore[MaxFramesInFlight];
            _renderFinishedSemaphores = new Semaphore[MaxFramesInFlight];
            _inFlightFences = new Fence[MaxFramesInFlight];
            _imagesInFlight = new Fence[swapchainProvider.SwapchainImages.Length];

            var semaphoreCreateInfo = new SemaphoreCreateInfo(flags: default);
            var fenceCreateInfo = new FenceCreateInfo(flags: FenceCreateFlags.FenceCreateSignaledBit);

            for (int i = 0; i < MaxFramesInFlight; i++)
            {
                _vk.CreateSemaphore
                    (
                        _logicalDeviceProvider.LogicalDevice, &semaphoreCreateInfo, null,
                        out _imageAvailableSemaphores[i]
                    )
                    .ThrowCode();
                _vk.CreateSemaphore
                    (
                        _logicalDeviceProvider.LogicalDevice, &semaphoreCreateInfo, null,
                        out _renderFinishedSemaphores[i]
                    )
                    .ThrowCode();
                _vk.CreateFence
                        (_logicalDeviceProvider.LogicalDevice, &fenceCreateInfo, null, out _inFlightFences[i])
                    .ThrowCode();
            }

            _vk.GetPhysicalDeviceProperties(physicalDeviceProvider.Device, out var physicalDeviceProperties);
#if DEBUG
            _nanosecondsPerTimestampStep = physicalDeviceProperties.Limits.TimestampPeriod;
#endif
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _subscription = _windowProvider.Subscribe(this);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _subscription?.Dispose();
            return Task.CompletedTask;
        }
        
        public unsafe void OnNext(WindowRender value)
        {
            _vk.WaitForFences(_logicalDeviceProvider.LogicalDevice, 1, _inFlightFences[_currentFrame], true, ulong.MaxValue);
            uint imageIndex = 0;
            var result = _khrSwapchain.AcquireNextImage(_logicalDeviceProvider.LogicalDevice, _swapchainProvider.Swapchain, ulong.MaxValue, _imageAvailableSemaphores[_currentFrame], default, ref imageIndex);

            if (result == Result.ErrorOutOfDateKhr)
            {
                _recreationService.RecreateSwapchain(null);
                return;
            }

            result.ThrowCode();

            if (_imagesInFlight[imageIndex].Handle != default)
            {
                var v = _imagesInFlight[imageIndex];
                _vk.WaitForFences(_logicalDeviceProvider.LogicalDevice, 1, v, true, ulong.MaxValue).ThrowCode();
            }
            
#if DEBUG
            {
                var pool = _graphicsCommandBufferProvider.TimeQueryPool;
                var queryResult = stackalloc uint[1];
                _vk.GetQueryPoolResults(_logicalDeviceProvider.LogicalDevice, pool, 0, 1, (UIntPtr) (sizeof(int) * 1), queryResult, 0, 0).ThrowCode();
                var diff = queryResult[0] - _lastTime;
                _lastTime = queryResult[0];
                var time = diff * _nanosecondsPerTimestampStep;
                var timespan = TimeSpan.FromMilliseconds((diff * ((double) time)) / 1000000);
                _logger.LogDebug("Time: {time}", timespan);
            }
#endif

            _imagesInFlight[imageIndex] = _inFlightFences[_currentFrame];

            var waitSemaphores = stackalloc[] {_imageAvailableSemaphores[_currentFrame]};
            var waitStages = stackalloc[] {PipelineStageFlags.PipelineStageColorAttachmentOutputBit};
            var signalSemaphores = stackalloc[] {_renderFinishedSemaphores[_currentFrame]};
            var submitInfo = new SubmitInfo
            (
                waitSemaphoreCount: 1,
                pWaitSemaphores: waitSemaphores,
                pWaitDstStageMask: waitStages,
                commandBufferCount: 1,
                pCommandBuffers: _graphicsCommandBufferProvider[(int)imageIndex],
                signalSemaphoreCount: 1,
                pSignalSemaphores: signalSemaphores
            );
            
            _vk.ResetFences(_logicalDeviceProvider.LogicalDevice, 1, _inFlightFences[_currentFrame]).ThrowCode();

            _vk.QueueSubmit(_graphicsQueueProvider.GraphicsQueue, 1, &submitInfo, _inFlightFences[_currentFrame]).ThrowCode();

            var swapchains = stackalloc[] {_swapchainProvider.Swapchain};
            var presentInfo = new PresentInfoKHR
            (
                waitSemaphoreCount: 1,
                pWaitSemaphores: signalSemaphores,
                swapchainCount: 1,
                pSwapchains: swapchains,
                pImageIndices: &imageIndex
            );

            result = _khrSwapchain.QueuePresent(_presentQueueProvider.PresentQueue, &presentInfo);

            if (result == Result.ErrorOutOfDateKhr || result == Result.SuboptimalKhr)
            {
                _recreationService.RecreateSwapchain(null);
            }
            else
            {
                result.ThrowCode();
            }

            _currentFrame = (_currentFrame + 1) % MaxFramesInFlight;
        }

        public void OnCompleted()
        { }

        public void OnError(Exception error)
        { }

        public unsafe void Dispose()
        {
            _subscription?.Dispose();

            _vk.DeviceWaitIdle(_logicalDeviceProvider.LogicalDevice);

            for (int i = 0; i < MaxFramesInFlight; i++)
            {
                _vk.DestroySemaphore(_logicalDeviceProvider.LogicalDevice, _imageAvailableSemaphores[i], null);
                _vk.DestroySemaphore(_logicalDeviceProvider.LogicalDevice, _renderFinishedSemaphores[i], null);
                _vk.DestroyFence(_logicalDeviceProvider.LogicalDevice, _inFlightFences[i], null);
            }
        }
    }
}
