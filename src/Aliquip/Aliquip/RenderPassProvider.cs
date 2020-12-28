// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using Silk.NET.Vulkan;

namespace Aliquip
{
    internal sealed class RenderPassProvider : IRenderPassProvider, IDisposable
    {
        private readonly Vk _vk;
        private readonly ILogicalDeviceProvider _logicalDeviceProvider;
        private readonly ISwapchainProvider _swapchainProvider;
        public RenderPass RenderPass { get; private set; }

        public unsafe RenderPassProvider(Vk vk, ILogicalDeviceProvider logicalDeviceProvider, ISwapchainProvider swapchainProvider)
        {
            _vk = vk;
            _logicalDeviceProvider = logicalDeviceProvider;
            _swapchainProvider = swapchainProvider;
            Recreate();
        }

        public unsafe void Recreate()
        {
            var colorAttachment = new AttachmentDescription
            (
                format: _swapchainProvider.SwapchainFormat, // this is the only external dependency, and as it doesn't change when recreating the swapchain, there is no need to rebuild all this.
                samples: SampleCountFlags.SampleCount1Bit,
                loadOp: AttachmentLoadOp.Clear,
                storeOp: AttachmentStoreOp.Store,
                stencilLoadOp: AttachmentLoadOp.DontCare,
                stencilStoreOp: AttachmentStoreOp.DontCare,
                initialLayout: ImageLayout.Undefined,
                finalLayout: ImageLayout.PresentSrcKhr
            );

            var colorAttachmentRef = new AttachmentReference(attachment: 0, layout: ImageLayout.ColorAttachmentOptimal);

            var subpass = new SubpassDescription
            (
                pipelineBindPoint: PipelineBindPoint.Graphics,
                colorAttachmentCount: 1,
                pColorAttachments: &colorAttachmentRef
            );

            var dependency = new SubpassDependency
            (
                srcSubpass: Vk.SubpassExternal,
                dstSubpass: 0,
                srcStageMask: PipelineStageFlags.PipelineStageColorAttachmentOutputBit,
                srcAccessMask: 0,
                dstStageMask: PipelineStageFlags.PipelineStageColorAttachmentOutputBit,
                dstAccessMask: AccessFlags.AccessColorAttachmentWriteBit | AccessFlags.AccessColorAttachmentReadBit // is read needed?
            );
            
            var renderPassInfo = new RenderPassCreateInfo
            (
                attachmentCount: 1,
                pAttachments: &colorAttachment,
                subpassCount: 1,
                pSubpasses: &subpass,
                dependencyCount: 1,
                pDependencies: &dependency
            );
            
            _vk.CreateRenderPass(_logicalDeviceProvider.LogicalDevice, &renderPassInfo, null, out var renderPass).ThrowCode();
            RenderPass = renderPass;
        }

        public unsafe void Dispose()
        {
            _vk.DestroyRenderPass(_logicalDeviceProvider.LogicalDevice, RenderPass, null);
        }
    }
}
