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
        private readonly IDepthImageProvider _depthImageProvider;
        private readonly IColorImageProvider _colorImageProvider;
        private readonly IMsaaProvider _msaaProvider;
        private readonly IPhysicalDeviceProvider _physicalDeviceProvider;
        public RenderPass RenderPass { get; private set; }

        public unsafe RenderPassProvider(Vk vk, ILogicalDeviceProvider logicalDeviceProvider, ISwapchainProvider swapchainProvider, IDepthImageProvider depthImageProvider, IColorImageProvider colorImageProvider, IMsaaProvider msaaProvider, IPhysicalDeviceProvider physicalDeviceProvider)
        {
            _vk = vk;
            _logicalDeviceProvider = logicalDeviceProvider;
            _swapchainProvider = swapchainProvider;
            _depthImageProvider = depthImageProvider;
            _colorImageProvider = colorImageProvider;
            _msaaProvider = msaaProvider;
            _physicalDeviceProvider = physicalDeviceProvider;
            Recreate();
        }

        public unsafe void Recreate()
        {
            var msaa = _msaaProvider.MsaaSamples(_physicalDeviceProvider.Device);
            var useMsaa = msaa != SampleCountFlags.SampleCount1Bit;
            
            var colorAttachment = new AttachmentDescription
            (
                format: _swapchainProvider.SwapchainFormat, // this is the only external dependency, and as it doesn't change when recreating the swapchain, there is no need to rebuild all this.
                samples: msaa,
                loadOp: AttachmentLoadOp.Clear,
                storeOp: AttachmentStoreOp.Store,
                stencilLoadOp: AttachmentLoadOp.DontCare,
                stencilStoreOp: AttachmentStoreOp.DontCare,
                initialLayout: ImageLayout.Undefined,
                finalLayout: useMsaa ? ImageLayout.ColorAttachmentOptimal : ImageLayout.PresentSrcKhr
            );

            var colorAttachmentRef = new AttachmentReference(attachment: 0, layout: ImageLayout.ColorAttachmentOptimal);
            
            var depthAttachment = new AttachmentDescription
            (
                format: _depthImageProvider.Texture.Format, samples: msaa,
                loadOp: AttachmentLoadOp.Clear, storeOp: AttachmentStoreOp.DontCare,
                stencilLoadOp: AttachmentLoadOp.DontCare, stencilStoreOp: AttachmentStoreOp.DontCare,
                initialLayout: ImageLayout.Undefined, finalLayout: ImageLayout.DepthStencilAttachmentOptimal
            );

            var depthAttachmentRef = new AttachmentReference(attachment: 1, layout: ImageLayout.DepthStencilAttachmentOptimal);

            AttachmentDescription colorAttachmentResolve = default;
            AttachmentReference colorAttachmentResolveRef = default;
            if (useMsaa)
            {
                colorAttachmentResolve = new AttachmentDescription
                (
                    format: _swapchainProvider.SwapchainFormat, samples: SampleCountFlags.SampleCount1Bit,
                    loadOp: AttachmentLoadOp.DontCare, storeOp: AttachmentStoreOp.DontCare,
                    stencilLoadOp: AttachmentLoadOp.DontCare, stencilStoreOp: AttachmentStoreOp.DontCare,
                    initialLayout: ImageLayout.Undefined, finalLayout: ImageLayout.PresentSrcKhr
                );

                colorAttachmentResolveRef = new AttachmentReference
                    (attachment: 2, layout: ImageLayout.ColorAttachmentOptimal);
            }

            var subpass = new SubpassDescription
            (
                pipelineBindPoint: PipelineBindPoint.Graphics,
                colorAttachmentCount: 1,
                pColorAttachments: &colorAttachmentRef,
                pDepthStencilAttachment: &depthAttachmentRef,
                pResolveAttachments: useMsaa ? &colorAttachmentResolveRef : null
            );

            var dependency = new SubpassDependency
            (
                srcSubpass: Vk.SubpassExternal,
                dstSubpass: 0,
                srcStageMask: PipelineStageFlags.PipelineStageColorAttachmentOutputBit | PipelineStageFlags.PipelineStageEarlyFragmentTestsBit,
                srcAccessMask: 0,
                dstStageMask: PipelineStageFlags.PipelineStageColorAttachmentOutputBit | PipelineStageFlags.PipelineStageEarlyFragmentTestsBit,
                dstAccessMask: AccessFlags.AccessColorAttachmentWriteBit | AccessFlags.AccessDepthStencilAttachmentWriteBit
            );

            RenderPassCreateInfo renderPassInfo;
            if (useMsaa)
            {
                var attachments = stackalloc[] {colorAttachment, depthAttachment, colorAttachmentResolve};

                renderPassInfo = new RenderPassCreateInfo
                (
                    attachmentCount: 3, pAttachments: attachments, subpassCount: 1, pSubpasses: &subpass,
                    dependencyCount: 1, pDependencies: &dependency
                );
            }
            else
            {
                var attachments = stackalloc[] {colorAttachment, depthAttachment};

                renderPassInfo = new RenderPassCreateInfo
                (
                    attachmentCount: 2, pAttachments: attachments, subpassCount: 1, pSubpasses: &subpass,
                    dependencyCount: 1, pDependencies: &dependency
                );
            }

            _vk.CreateRenderPass(_logicalDeviceProvider.LogicalDevice, &renderPassInfo, null, out var renderPass).ThrowCode();
            RenderPass = renderPass;
        }

        public unsafe void Dispose()
        {
            _vk.DestroyRenderPass(_logicalDeviceProvider.LogicalDevice, RenderPass, null);
        }
    }
}
