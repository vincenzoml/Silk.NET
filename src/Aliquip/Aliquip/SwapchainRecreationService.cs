// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Reactive;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Silk.NET.Maths;
using Silk.NET.Vulkan;

namespace Aliquip
{
    internal sealed class SwapchainRecreationService : IHostedService, ISwapchainRecreationService, IObserver<WindowResized>
    {
        private readonly IWindowProvider _windowProvider;
        private readonly ILogger _logger;
        private readonly ISwapchainProvider _swapchainProvider;
        private readonly IImageViewProvider _imageViewProvider;
        private readonly IRenderPassProvider _renderPassProvider;
        private readonly IGraphicsPipelineFactory _graphicsPipelineFactory;
        private readonly IFramebufferProvider _framebufferProvider;
        private readonly IPipelineLayoutFactory _pipelineLayoutFactory;
        private readonly Vk _vk;
        private readonly ILogicalDeviceProvider _logicalDeviceProvider;
        private readonly IGraphicsCommandBufferProvider _graphicsCommandBufferProvider;
        private readonly IDescriptorPoolFactory _descriptorPoolFactory;
        private readonly IDescriptorSetFactory _descriptorSetFactory;
        private readonly IDepthImageProvider _depthImageProvider;
        private readonly IColorImageProvider _colorImageProvider;
        private readonly IScene _scene;
        private IDisposable? _subscription;

        public SwapchainRecreationService
        (
            IWindowProvider windowProvider,
            ILogger<SwapchainRecreationService> logger,
            ISwapchainProvider swapchainProvider,
            IImageViewProvider imageViewProvider,
            IRenderPassProvider renderPassProvider,
            IGraphicsPipelineFactory graphicsPipelineFactory,
            IFramebufferProvider framebufferProvider,
            IPipelineLayoutFactory pipelineLayoutFactory,
            Vk vk,
            ILogicalDeviceProvider logicalDeviceProvider,
            IGraphicsCommandBufferProvider graphicsCommandBufferProvider,
            IDescriptorPoolFactory descriptorPoolFactory,
            IDescriptorSetFactory descriptorSetFactory,
            IDepthImageProvider depthImageProvider,
            IColorImageProvider colorImageProvider,
            IScene scene
        )
        {
            _windowProvider = windowProvider;
            _logger = logger;
            _swapchainProvider = swapchainProvider;
            _imageViewProvider = imageViewProvider;
            _renderPassProvider = renderPassProvider;
            _graphicsPipelineFactory = graphicsPipelineFactory;
            _framebufferProvider = framebufferProvider;
            _pipelineLayoutFactory = pipelineLayoutFactory;
            _vk = vk;
            _logicalDeviceProvider = logicalDeviceProvider;
            _graphicsCommandBufferProvider = graphicsCommandBufferProvider;
            _descriptorPoolFactory = descriptorPoolFactory;
            _descriptorSetFactory = descriptorSetFactory;
            _depthImageProvider = depthImageProvider;
            _colorImageProvider = colorImageProvider;
            _scene = scene;
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

        public void RecreateSwapchain(Vector2D<int>? newSize)
        {
            if (_windowProvider.Window.IsClosing)
                return;
            
            _logger.LogDebug("Recreating swapchain");
            _vk.DeviceWaitIdle(_logicalDeviceProvider.LogicalDevice);

            _graphicsCommandBufferProvider.Dispose();
            _framebufferProvider.Dispose();
            _depthImageProvider.Dispose();
            _colorImageProvider.Dispose();
            _pipelineLayoutFactory.Dispose();
            _renderPassProvider.Dispose();
            _imageViewProvider.Dispose();
            _swapchainProvider.Dispose();
            
            _swapchainProvider.Recreate(newSize);
            _imageViewProvider.Recreate();
            _renderPassProvider.Recreate();
            _colorImageProvider.Recreate();
            _depthImageProvider.Recreate();
            _framebufferProvider.Recreate();
            _graphicsCommandBufferProvider.Recreate();
        }

        public void OnCompleted()
        { }

        public void OnError(Exception error)
        { }

        public void OnNext(WindowResized value)
        {
            RecreateSwapchain(value.EventArgs);
        }
    }
}
