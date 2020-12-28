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
        private readonly ILogicalDeviceProvider _deviceProvider;
        private readonly ISwapchainProvider _swapchainProvider;
        private readonly IRenderPassProvider _renderPassProvider;
        private readonly IImageViewProvider _imageViewProvider;
        public Framebuffer[] Framebuffers { get; private set; }

        public unsafe FramebufferProvider(Vk vk, ILogicalDeviceProvider deviceProvider, ISwapchainProvider swapchainProvider, IRenderPassProvider renderPassProvider, IImageViewProvider imageViewProvider)
        {
            _vk = vk;
            _deviceProvider = deviceProvider;
            _swapchainProvider = swapchainProvider;
            _renderPassProvider = renderPassProvider;
            _imageViewProvider = imageViewProvider;
            
            Recreate();
        }

        public unsafe void Recreate()
        {
            Framebuffers = new Framebuffer[_swapchainProvider.SwapchainImages.Length];
            
            for (int i = 0; i < Framebuffers.Length; i++)
            {
                var attachment = _imageViewProvider.ImageViews[i];

                var createInfo = new FramebufferCreateInfo
                (
                    renderPass: _renderPassProvider.RenderPass,
                    attachmentCount: 1,
                    pAttachments: &attachment,
                    width: _swapchainProvider.SwapchainExtent.Width,
                    height: _swapchainProvider.SwapchainExtent.Height,
                    layers: 1
                );

                _vk.CreateFramebuffer(_deviceProvider.LogicalDevice, &createInfo, null, out Framebuffers[i]).ThrowCode();
            }
        }

        public unsafe void Dispose()
        {
            foreach (var framebuffer in Framebuffers)
            {
                _vk.DestroyFramebuffer(_deviceProvider.LogicalDevice, framebuffer, null);
            }
        }
    }
}
