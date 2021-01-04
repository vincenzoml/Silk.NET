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
        private readonly ISwapchainProvider _swapchainProvider;
        private readonly ILogicalDeviceProvider _logicalDeviceProvider;
        private readonly IAllocationCallbacksProvider _allocationCallbacksProvider;
        public ImageView[] ImageViews { get; private set; }

        public unsafe ImageViewProvider(Vk vk, ISwapchainProvider swapchainProvider, ILogicalDeviceProvider logicalDeviceProvider, IAllocationCallbacksProvider allocationCallbacksProvider)
        {
            _vk = vk;
            _swapchainProvider = swapchainProvider;
            _logicalDeviceProvider = logicalDeviceProvider;
            _allocationCallbacksProvider = allocationCallbacksProvider;

            Recreate();
        }
        
        public unsafe void Recreate()
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

                _vk.CreateImageView(_logicalDeviceProvider.LogicalDevice, createInfo, null, out ImageViews[i]).ThrowCode();
            }
        }

        public unsafe void Dispose()
        {
            foreach (var imageView in ImageViews)
                _vk.DestroyImageView(_logicalDeviceProvider.LogicalDevice, imageView, null);
        }
    }
}
