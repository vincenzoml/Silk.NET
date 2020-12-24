// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using Silk.NET.Vulkan;

namespace Aliquip
{
    internal sealed class CommandBufferProvider : ICommandBufferProvider, IDisposable
    {
        private readonly Vk _vk;
        private readonly ICommandPoolProvider _commandPoolProvider;
        private readonly IFramebufferProvider _framebufferProvider;
        private readonly IRenderPassProvider _renderPassProvider;
        private readonly ISwapchainProvider _swapchainProvider;
        private readonly IGraphicsPipelineProvider _graphicsPipelineProvider;
        private readonly Device _device;
        public CommandBuffer[] CommandBuffers { get; private set; }

        public unsafe CommandBufferProvider
        (
            Vk vk,
            ICommandPoolProvider commandPoolProvider,
            IFramebufferProvider framebufferProvider,
            ILogicalDeviceProvider logicalDeviceProvider,
            IRenderPassProvider renderPassProvider,
            ISwapchainProvider swapchainProvider,
            IGraphicsPipelineProvider graphicsPipelineProvider
        )
        {
            _vk = vk;
            _commandPoolProvider = commandPoolProvider;
            _framebufferProvider = framebufferProvider;
            _renderPassProvider = renderPassProvider;
            _swapchainProvider = swapchainProvider;
            _graphicsPipelineProvider = graphicsPipelineProvider;
            _device = logicalDeviceProvider.LogicalDevice;
            
            RecreateCommandBuffers();
        }

        public unsafe void RecreateCommandBuffers()
        {
            CommandBuffers = new CommandBuffer[_framebufferProvider.Framebuffers.Length];

            var allocInfo = new CommandBufferAllocateInfo
            (
                commandPool: _commandPoolProvider.CommandPool, level: CommandBufferLevel.Primary,
                commandBufferCount: (uint) CommandBuffers.Length
            );

            _vk.AllocateCommandBuffers(_device, &allocInfo, CommandBuffers).ThrowCode();

            // TODO: rework this to be more modular!

            for (int i = 0; i < CommandBuffers.Length; i++)
            {
                var beginInfo = new CommandBufferBeginInfo(sType: StructureType.CommandBufferBeginInfo);
                _vk.BeginCommandBuffer(CommandBuffers[i], beginInfo).ThrowCode();
                
                var clearColor = new ClearValue(new ClearColorValue(0f, 0f, 0f, 1f));
                
                var renderPassInfo = new RenderPassBeginInfo
                (
                    renderPass: _renderPassProvider.RenderPass,
                    framebuffer: _framebufferProvider.Framebuffers[i],
                    renderArea: new Rect2D(new Offset2D(0, 0), _swapchainProvider.SwapchainExtent),
                    clearValueCount: 1,
                    pClearValues: &clearColor
                );
                
                _vk.CmdBeginRenderPass(CommandBuffers[i], renderPassInfo, SubpassContents.Inline);
                
                _vk.CmdBindPipeline(CommandBuffers[i], PipelineBindPoint.Graphics, _graphicsPipelineProvider.GraphicsPipeline);
                _vk.CmdDraw(CommandBuffers[i], 3, 1, 0, 0);
                
                _vk.CmdEndRenderPass(CommandBuffers[i]);

                _vk.EndCommandBuffer(CommandBuffers[i]).ThrowCode();
            }
        }

        public void Dispose()
        {
            _vk.FreeCommandBuffers(_device, _commandPoolProvider.CommandPool, (uint) CommandBuffers.Length, CommandBuffers);
        }
    }
}
