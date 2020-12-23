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
        public ImageView[] ImageViews { get; }

        public unsafe ImageViewProvider(Vk vk, ISwapchainProvider swapchainProvider, ILogicalDeviceProvider logicalDeviceProvider)
        {
            _vk = vk;
            _device = logicalDeviceProvider.LogicalDevice;
            ImageViews = new ImageView[swapchainProvider.SwapchainImages.Length];

            for (int i = 0; i < ImageViews.Length; i++)
            {
                var createInfo = new ImageViewCreateInfo
                (
                    image: swapchainProvider.SwapchainImages[i],
                    viewType: ImageViewType.ImageViewType2D,
                    format: swapchainProvider.SwapchainFormat,
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
