// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using Silk.NET.Vulkan;

namespace Aliquip
{
    internal sealed class GraphicsCommandBufferProvider : IGraphicsCommandBufferProvider
    {
        private readonly Vk _vk;
        private readonly ICommandBufferFactory _commandBufferFactory;
        private readonly ISwapchainProvider _swapchainProvider;
        private readonly IGraphicsQueueProvider _graphicsQueueProvider;
        private readonly IRenderPassProvider _renderPassProvider;
        private readonly IFramebufferProvider _framebufferProvider;
        private readonly IGraphicsPipelineProvider _graphicsPipelineProvider;
        private readonly IPipelineLayoutProvider _pipelineLayoutProvider;
        private readonly IDescriptorSetProvider _descriptorSetProvider;
        private CommandBuffer[]? _array;

        public unsafe CommandBuffer* this[int index]
        {
            get
            {
                fixed (CommandBuffer* p = _array)
                    return p + index;
            }   
        }

        public GraphicsCommandBufferProvider
        (
            Vk vk,
            ICommandBufferFactory commandBufferFactory,
            ISwapchainProvider swapchainProvider,
            IGraphicsQueueProvider graphicsQueueProvider,
            IRenderPassProvider renderPassProvider,
            IFramebufferProvider framebufferProvider,
            IGraphicsPipelineProvider graphicsPipelineProvider,
            IPipelineLayoutProvider pipelineLayoutProvider,
            IDescriptorSetProvider descriptorSetProvider
        )
        {
            _vk = vk;
            _commandBufferFactory = commandBufferFactory;
            _swapchainProvider = swapchainProvider;
            _graphicsQueueProvider = graphicsQueueProvider;
            _renderPassProvider = renderPassProvider;
            _framebufferProvider = framebufferProvider;
            _graphicsPipelineProvider = graphicsPipelineProvider;
            _pipelineLayoutProvider = pipelineLayoutProvider;
            _descriptorSetProvider = descriptorSetProvider;

            Recreate();
        }

        public unsafe void Recreate()
        {
            _array = _commandBufferFactory.CreateCommandBuffers
            (
                _swapchainProvider.SwapchainImages.Length, _graphicsQueueProvider.GraphicsQueueIndex, null, 
                (commandBuffer, i) =>
                {
                    var clearColor = new ClearValue(new ClearColorValue(0f, 0f, 0f, 1f));

                    var renderPassInfo = new RenderPassBeginInfo
                    (
                        renderPass: _renderPassProvider.RenderPass, framebuffer: _framebufferProvider.Framebuffers[i],
                        renderArea: new Rect2D(new Offset2D(0, 0), _swapchainProvider.SwapchainExtent),
                        clearValueCount: 1, pClearValues: &clearColor
                    );

                    _vk.CmdBeginRenderPass(commandBuffer, renderPassInfo, SubpassContents.Inline);

                    _graphicsPipelineProvider.Bind(commandBuffer);
                    _vk.CmdBindDescriptorSets
                    (
                        commandBuffer, PipelineBindPoint.Graphics, _pipelineLayoutProvider.PipelineLayout, 0, 1,
                        _descriptorSetProvider.DescriptorSets[i], 0, null
                    );

                    _vk.CmdDrawIndexed(commandBuffer, _graphicsPipelineProvider.IndexCount, 1, 0, 0, 0);

                    _vk.CmdEndRenderPass(commandBuffer);
                }
            );
        }
        
        public void Dispose()
        {
            if (_array != null)
            {
                _commandBufferFactory.FreeCommandBuffers(_array, _graphicsQueueProvider.GraphicsQueueIndex);
                _array = null;
            }
        }
    }
}
