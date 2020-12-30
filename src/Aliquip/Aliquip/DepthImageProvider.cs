// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Collections;
using System.Collections.Generic;
using Silk.NET.Vulkan;

namespace Aliquip
{
    internal sealed class DepthImageProvider : IDepthImageProvider, IDisposable
    {
        private readonly Vk _vk;
        private readonly IPhysicalDeviceProvider _physicalDeviceProvider;
        private readonly ILogicalDeviceProvider _logicalDeviceProvider;
        private readonly ITextureFactory _textureFactory;
        private readonly ISwapchainProvider _swapchainProvider;
        public Texture Texture { get; private set; }

        public DepthImageProvider(Vk vk, IPhysicalDeviceProvider physicalDeviceProvider, ILogicalDeviceProvider logicalDeviceProvider, ITextureFactory textureFactory, ISwapchainProvider swapchainProvider)
        {
            _vk = vk;
            _physicalDeviceProvider = physicalDeviceProvider;
            _logicalDeviceProvider = logicalDeviceProvider;
            _textureFactory = textureFactory;
            _swapchainProvider = swapchainProvider;
            
            Recreate();
        }

        public void Recreate()
        {
            Format FindSupportedFormat(IEnumerable<Format> candidates, ImageTiling tiling, FormatFeatureFlags features)
            {
                foreach (var format in candidates)
                {
                    _vk.GetPhysicalDeviceFormatProperties(_physicalDeviceProvider.Device, format, out var properties);
                    
                    if (tiling == ImageTiling.Linear && (properties.LinearTilingFeatures & features) == features) {
                        return format;
                    } else if (tiling == ImageTiling.Optimal && (properties.OptimalTilingFeatures & features) == features) {
                        return format;
                    }
                }

                throw new Exception("No supported format found");
            }
            
            Format FindDepthFormat()
            {
                return FindSupportedFormat
                (
                    new[] {Format.D32Sfloat, Format.D32SfloatS8Uint, Format.D24UnormS8Uint}, ImageTiling.Optimal,
                    FormatFeatureFlags.FormatFeatureDepthStencilAttachmentBit
                );
            }

            var depthFormat = FindDepthFormat();
            Texture = _textureFactory.CreateImage
            (
                _swapchainProvider.SwapchainExtent.Width, _swapchainProvider.SwapchainExtent.Height, depthFormat, false,
                ImageAspectFlags.ImageAspectDepthBit, ImageUsageFlags.ImageUsageDepthStencilAttachmentBit
            );
            
            Texture.TransitionImageLayout(ImageLayout.DepthStencilAttachmentOptimal);
        }

        public void Dispose()
        {
            Texture.Dispose();
        }
    }
}
