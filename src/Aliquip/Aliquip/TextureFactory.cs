// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Collections.Generic;
using Silk.NET.Vulkan;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using Image = Silk.NET.Vulkan.Image;

namespace Aliquip
{
    internal sealed class TextureFactory : ITextureFactory
    {
        private readonly Vk _vk;
        private readonly ITransferQueueProvider _transferQueueProvider;
        private readonly IResourceProvider _resourceProvider;
        private readonly ILogicalDeviceProvider _logicalDeviceProvider;
        private readonly IBufferFactory _bufferFactory;
        private readonly IPhysicalDeviceProvider _physicalDeviceProvider;
        private readonly ICommandBufferFactory _commandBufferFactory;
        private readonly IGraphicsQueueProvider _graphicsQueueProvider;
        private readonly Dictionary<string, Texture> _cache = new();
        public Texture this[string name]
        {
            get
            {
                if (_cache.TryGetValue(name, out var t))
                    return t;
                
                t = CreateImage(SixLabors.ImageSharp.Image.Load(_resourceProvider["textures." + name]));
                _cache[name] = t;
                return t;
            }
        }

        public TextureFactory
        (
            Vk vk,
            ITransferQueueProvider transferQueueProvider,
            IResourceProvider resourceProvider,
            ILogicalDeviceProvider logicalDeviceProvider,
            IBufferFactory bufferFactory,
            IPhysicalDeviceProvider physicalDeviceProvider,
            ICommandBufferFactory commandBufferFactory,
            IGraphicsQueueProvider graphicsQueueProvider
        )
        {
            _vk = vk;
            _transferQueueProvider = transferQueueProvider;
            _resourceProvider = resourceProvider;
            _logicalDeviceProvider = logicalDeviceProvider;
            _bufferFactory = bufferFactory;
            _physicalDeviceProvider = physicalDeviceProvider;
            _commandBufferFactory = commandBufferFactory;
            _graphicsQueueProvider = graphicsQueueProvider;
        }

        public Texture CreateImage(Image<Rgba32> src)
        {
            return new(
                src, _vk, _commandBufferFactory, _transferQueueProvider, _logicalDeviceProvider, _physicalDeviceProvider, _graphicsQueueProvider, _bufferFactory
            );
        }
    }
}
