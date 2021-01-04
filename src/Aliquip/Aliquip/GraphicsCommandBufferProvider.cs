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
        private readonly IGraphicsPipelineFactory _graphicsPipelineFactory;
        private readonly IPipelineLayoutFactory _pipelineLayoutFactory;
        private readonly IDescriptorSetFactory _descriptorSetFactory;
        private readonly ILogicalDeviceProvider _logicalDeviceProvider;
        private readonly IScene _scene;
        private readonly IAllocationCallbacksProvider _allocationCallbacksProvider;
        private CommandBuffer[]? _primaryCommandBuffers;
        private CommandBuffer[][]? _secondaryCommandBuffers;
        
        public unsafe CommandBuffer* this[int index]
        {
            get
            {
                if (_scene.CommandBufferNeedsRebuild)
                {
                    Recreate();
                }
                
                fixed (CommandBuffer* p = _primaryCommandBuffers)
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
            IGraphicsPipelineFactory graphicsPipelineFactory,
            IPipelineLayoutFactory pipelineLayoutFactory,
            IDescriptorSetFactory descriptorSetFactory,
            ILogicalDeviceProvider logicalDeviceProvider,
            IScene scene,
            IAllocationCallbacksProvider allocationCallbacksProvider
        )
        {
            _vk = vk;
            _commandBufferFactory = commandBufferFactory;
            _swapchainProvider = swapchainProvider;
            _graphicsQueueProvider = graphicsQueueProvider;
            _renderPassProvider = renderPassProvider;
            _framebufferProvider = framebufferProvider;
            _graphicsPipelineFactory = graphicsPipelineFactory;
            _pipelineLayoutFactory = pipelineLayoutFactory;
            _descriptorSetFactory = descriptorSetFactory;
            _logicalDeviceProvider = logicalDeviceProvider;
            _scene = scene;
            _allocationCallbacksProvider = allocationCallbacksProvider;

            Recreate();
        }

        public unsafe void Recreate()
        {
            _scene.CommandBufferCount = _swapchainProvider.SwapchainImages.Length;
            _scene.CommandBufferNeedsRebuild = false;
            
            _secondaryCommandBuffers = new CommandBuffer[1][]; // one scene only for now
            var inheritanceInfo = new CommandBufferInheritanceInfo(renderPass: _renderPassProvider.RenderPass,
                // TODO: possibly specify framebuffer?
                pipelineStatistics: (QueryPipelineStatisticFlags) 0);
            _secondaryCommandBuffers[0] = _commandBufferFactory.CreateCommandBuffers
            (
                _scene.CommandBufferCount, _graphicsQueueProvider.GraphicsQueueIndex,
                new CommandBufferBeginInfo
                (
                    flags: CommandBufferUsageFlags.CommandBufferUsageRenderPassContinueBit,
                    pInheritanceInfo: &inheritanceInfo
                ),
                CommandBufferLevel.Secondary,
                _scene.RecordCommandBuffer
            );

            _primaryCommandBuffers = _commandBufferFactory.CreateCommandBuffers
            (
                _swapchainProvider.SwapchainImages.Length, _graphicsQueueProvider.GraphicsQueueIndex, null,
                CommandBufferLevel.Primary, (commandBuffer, i) =>
                {
                    var clearColors = stackalloc[]
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

                    _vk.CmdBeginRenderPass(commandBuffer, renderPassInfo, SubpassContents.SecondaryCommandBuffers);

                    _vk.CmdExecuteCommands(commandBuffer, 1, _secondaryCommandBuffers[0][i]);

                    _vk.CmdEndRenderPass(commandBuffer);
                }
            );
        }
        
        public unsafe void Dispose()
        {
            foreach (var secondaryCommandBuffer in _secondaryCommandBuffers)
            {
                _commandBufferFactory.FreeCommandBuffers(secondaryCommandBuffer, _graphicsQueueProvider.GraphicsQueueIndex);
            }
            
            if (_primaryCommandBuffers != null)
            {
                _commandBufferFactory.FreeCommandBuffers(_primaryCommandBuffers, _graphicsQueueProvider.GraphicsQueueIndex);
                _primaryCommandBuffers = null;
            }
        }
    }
}
