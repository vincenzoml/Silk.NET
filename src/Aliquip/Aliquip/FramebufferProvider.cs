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
        private readonly IDepthImageProvider _depthImageProvider;
        private readonly IColorImageProvider _colorImageProvider;
        private readonly IMsaaProvider _msaaProvider;
        private readonly IPhysicalDeviceProvider _physicalDeviceProvider;
        private readonly IAllocationCallbacksProvider _allocationCallbacksProvider;
        public Framebuffer[] Framebuffers { get; private set; }

        public unsafe FramebufferProvider
        (
            Vk vk,
            ILogicalDeviceProvider deviceProvider,
            ISwapchainProvider swapchainProvider,
            IRenderPassProvider renderPassProvider,
            IImageViewProvider imageViewProvider,
            IDepthImageProvider depthImageProvider,
            IColorImageProvider colorImageProvider,
            IMsaaProvider msaaProvider,
            IPhysicalDeviceProvider physicalDeviceProvider,
            IAllocationCallbacksProvider allocationCallbacksProvider
        )
        {
            _vk = vk;
            _deviceProvider = deviceProvider;
            _swapchainProvider = swapchainProvider;
            _renderPassProvider = renderPassProvider;
            _imageViewProvider = imageViewProvider;
            _depthImageProvider = depthImageProvider;
            _colorImageProvider = colorImageProvider;
            _msaaProvider = msaaProvider;
            _physicalDeviceProvider = physicalDeviceProvider;
            _allocationCallbacksProvider = allocationCallbacksProvider;

            Recreate();
        }

        public unsafe void Recreate()
        {
            Framebuffers = new Framebuffer[_swapchainProvider.SwapchainImages.Length];
            
            for (int i = 0; i < Framebuffers.Length; i++)
            {
                FramebufferCreateInfo createInfo;
                if (_msaaProvider.MsaaSamples(_physicalDeviceProvider.Device) != SampleCountFlags.SampleCount1Bit)
                {
                    var attachments = stackalloc[]
                    {
                        _colorImageProvider.ColorImage!.ImageView, _depthImageProvider.Texture.ImageView,
                        _imageViewProvider.ImageViews[i]
                    };

                    createInfo = new FramebufferCreateInfo
                    (
                        renderPass: _renderPassProvider.RenderPass, attachmentCount: 3, pAttachments: attachments,
                        width: _swapchainProvider.SwapchainExtent.Width,
                        height: _swapchainProvider.SwapchainExtent.Height, layers: 1
                    );
                }
                else
                {
                    var attachments = stackalloc[]
                    {
                        _imageViewProvider.ImageViews[i],
                        _depthImageProvider.Texture.ImageView
                    };

                    createInfo = new FramebufferCreateInfo
                    (
                        renderPass: _renderPassProvider.RenderPass, attachmentCount: 2, pAttachments: attachments,
                        width: _swapchainProvider.SwapchainExtent.Width,
                        height: _swapchainProvider.SwapchainExtent.Height, layers: 1
                    );
                }

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
