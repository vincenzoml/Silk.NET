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

namespace Aliquip
{
    internal sealed class SwapchainRecreationService : IHostedService, ISwapchainRecreationService, IObserver<WindowResized>
    {
        private readonly IWindowProvider _windowProvider;
        private readonly ILogger _logger;
        private readonly ISwapchainProvider _swapchainProvider;
        private readonly IImageViewProvider _imageViewProvider;
        private readonly IRenderPassProvider _renderPassProvider;
        private readonly IGraphicsPipelineProvider _graphicsPipelineProvider;
        private readonly IFramebufferProvider _framebufferProvider;
        private readonly ICommandBufferProvider _commandBufferProvider;
        private readonly IPipelineLayoutProvider _pipelineLayoutProvider;
        private IDisposable? _subscription;

        public SwapchainRecreationService
        (
            IWindowProvider windowProvider,
            ILogger<SwapchainRecreationService> logger,
            ISwapchainProvider swapchainProvider,
            IImageViewProvider imageViewProvider,
            IRenderPassProvider renderPassProvider,
            IGraphicsPipelineProvider graphicsPipelineProvider,
            IFramebufferProvider framebufferProvider,
            ICommandBufferProvider commandBufferProvider,
            IPipelineLayoutProvider pipelineLayoutProvider
        )
        {
            _windowProvider = windowProvider;
            _logger = logger;
            _swapchainProvider = swapchainProvider;
            _imageViewProvider = imageViewProvider;
            _renderPassProvider = renderPassProvider;
            _graphicsPipelineProvider = graphicsPipelineProvider;
            _framebufferProvider = framebufferProvider;
            _commandBufferProvider = commandBufferProvider;
            _pipelineLayoutProvider = pipelineLayoutProvider;
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

        public void RecreateSwapchain()
        {
            _logger.LogDebug("Recreating swapchain");

            _commandBufferProvider.Dispose();
            _framebufferProvider.Dispose();
            _graphicsPipelineProvider.Dispose();
            _pipelineLayoutProvider.Dispose();
            _renderPassProvider.Dispose();
            _imageViewProvider.Dispose();
            _swapchainProvider.Dispose();
            
            _swapchainProvider.RecreateSwapchain();
            _imageViewProvider.RecreateImageViews();
            _renderPassProvider.RecreateRenderPass();
            _pipelineLayoutProvider.RecreatePipelineLayout();
            _graphicsPipelineProvider.RecreateGraphicsPipeline();
            _framebufferProvider.RecreateFramebuffers();
            _commandBufferProvider.RecreateCommandBuffers();
        }

        public void OnCompleted()
        { }

        public void OnError(Exception error)
        { }

        public void OnNext(WindowResized value)
        {
            RecreateSwapchain();
        }
    }
}
