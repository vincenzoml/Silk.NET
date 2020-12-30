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
        private readonly ILogicalDeviceProvider _logicalDeviceProvider;
        private CommandBuffer[]? _array;
#if DEBUG
        public QueryPool TimeQueryPool { get; }
#endif
        
        public unsafe CommandBuffer* this[int index]
        {
            get
            {
                fixed (CommandBuffer* p = _array)
                    return p + index;
            }   
        }

        public unsafe GraphicsCommandBufferProvider
        (
            Vk vk,
            ICommandBufferFactory commandBufferFactory,
            ISwapchainProvider swapchainProvider,
            IGraphicsQueueProvider graphicsQueueProvider,
            IRenderPassProvider renderPassProvider,
            IFramebufferProvider framebufferProvider,
            IGraphicsPipelineProvider graphicsPipelineProvider,
            IPipelineLayoutProvider pipelineLayoutProvider,
            IDescriptorSetProvider descriptorSetProvider,
            ILogicalDeviceProvider logicalDeviceProvider
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
            _logicalDeviceProvider = logicalDeviceProvider;

#if DEBUG
            var timeQueryCreateInfo = new QueryPoolCreateInfo(queryType: QueryType.Timestamp, queryCount: 1);
            _vk.CreateQueryPool(_logicalDeviceProvider.LogicalDevice, timeQueryCreateInfo, null, out var timeQueryPool);
            TimeQueryPool = timeQueryPool;
#endif
            
            Recreate();
        }

        public unsafe void Recreate()
        {
            _array = _commandBufferFactory.CreateCommandBuffers
            (
                _swapchainProvider.SwapchainImages.Length, _graphicsQueueProvider.GraphicsQueueIndex, null, 
                (commandBuffer, i) =>
                {
#if DEBUG
                    _vk.CmdResetQueryPool(commandBuffer, TimeQueryPool, 0, 1);
#endif
                    var clearColors = stackalloc []
                    {
                        new ClearValue(new ClearColorValue(0f, 0f, 0f, 1f)),
                        new ClearValue(depthStencil: new ClearDepthStencilValue(1, 0))
                    };

                    var renderPassInfo = new RenderPassBeginInfo
                    (
                        renderPass: _renderPassProvider.RenderPass, framebuffer: _framebufferProvider.Framebuffers[i],
                        renderArea: new Rect2D(new Offset2D(0, 0), _swapchainProvider.SwapchainExtent),
                        clearValueCount: 2, pClearValues: clearColors
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
#if DEBUG
                    _vk.CmdWriteTimestamp(commandBuffer, PipelineStageFlags.PipelineStageBottomOfPipeBit, TimeQueryPool, 0);
#endif
                }
            );
        }
        
        public unsafe void Dispose()
        {
#if DEBUG
            _vk.DestroyQueryPool(_logicalDeviceProvider.LogicalDevice, TimeQueryPool, null);
#endif
            
            if (_array != null)
            {
                _commandBufferFactory.FreeCommandBuffers(_array, _graphicsQueueProvider.GraphicsQueueIndex);
                _array = null;
            }
        }
    }
}
