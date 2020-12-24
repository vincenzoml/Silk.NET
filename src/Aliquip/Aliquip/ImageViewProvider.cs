// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using Silk.NET.Vulkan;

namespace Aliquip
{
    internal sealed class ImageViewProvider : IImageViewProvider, IDisposable
    {
        private readonly Vk _vk;
        private readonly Device _device;
        private readonly ISwapchainProvider _swapchainProvider;
        public ImageView[] ImageViews { get; private set; }

        public unsafe ImageViewProvider(Vk vk, ISwapchainProvider swapchainProvider, ILogicalDeviceProvider logicalDeviceProvider)
        {
            _vk = vk;
            _device = logicalDeviceProvider.LogicalDevice;
            _swapchainProvider = swapchainProvider;
            
            RecreateImageViews();
        }
        
        public unsafe void RecreateImageViews()
        {
            ImageViews = new ImageView[_swapchainProvider.SwapchainImages.Length];

            for (int i = 0; i < ImageViews.Length; i++)
            {
                var createInfo = new ImageViewCreateInfo
                (
                    image: _swapchainProvider.SwapchainImages[i],
                    viewType: ImageViewType.ImageViewType2D,
                    format: _swapchainProvider.SwapchainFormat,
                    components: new ComponentMapping
                    (
                        ComponentSwizzle.Identity,
                        ComponentSwizzle.Identity,
                        ComponentSwizzle.Identity,
                        ComponentSwizzle.Identity
                    ),
                    subresourceRange: new ImageSubresourceRange(ImageAspectFlags.ImageAspectColorBit, 0, 1, 0, 1)
                );

                _vk.CreateImageView(_device, createInfo, null, out ImageViews[i]).ThrowCode();
            }
        }

        public unsafe void Dispose()
        {
            foreach (var imageView in ImageViews)
                _vk.DestroyImageView(_device, imageView, null);
        }
    }
}
