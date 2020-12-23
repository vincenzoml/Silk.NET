// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using Silk.NET.Vulkan;

namespace Aliquip
{
    internal sealed class FramebufferProvider : IFramebufferProvider, IDisposable
    {
        private readonly Vk _vk;
        private readonly Device _device;
        public Framebuffer[] Framebuffers { get; }

        public unsafe FramebufferProvider(Vk vk, ILogicalDeviceProvider deviceProvider, ISwapchainProvider swapchainProvider, IRenderPassProvider renderPassProvider, IImageViewProvider imageViewProvider)
        {
            _vk = vk;
            _device = deviceProvider.LogicalDevice;
            Framebuffers = new Framebuffer[swapchainProvider.SwapchainImages.Length];
            
            for (int i = 0; i < Framebuffers.Length; i++)
            {
                var attachment = imageViewProvider.ImageViews[i];

                var createInfo = new FramebufferCreateInfo
                (
                    renderPass: renderPassProvider.RenderPass,
                    attachmentCount: 1,
                    pAttachments: &attachment,
                    width: swapchainProvider.SwapchainExtent.Width,
                    height: swapchainProvider.SwapchainExtent.Height,
                    layers: 1
                );

                _vk.CreateFramebuffer(_device, &createInfo, null, out Framebuffers[i]).ThrowCode();
            }
        }

        public unsafe void Dispose()
        {
            foreach (var framebuffer in Framebuffers)
            {
                _vk.DestroyFramebuffer(_device, framebuffer, null);
            }
        }
    }
}
