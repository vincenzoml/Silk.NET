// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Collections.Generic;
using Silk.NET.Vulkan;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using VMASharp;
using Image = Silk.NET.Vulkan.Image;

namespace Aliquip
{
    internal sealed class TextureFactory : ITextureFactory, IDisposable
    {
        private readonly Vk _vk;
        private readonly ITransferQueueProvider _transferQueueProvider;
        private readonly IResourceProvider _resourceProvider;
        private readonly ILogicalDeviceProvider _logicalDeviceProvider;
        private readonly IBufferFactory _bufferFactory;
        private readonly IPhysicalDeviceProvider _physicalDeviceProvider;
        private readonly ICommandBufferFactory _commandBufferFactory;
        private readonly IGraphicsQueueProvider _graphicsQueueProvider;
        private readonly VulkanMemoryAllocator _vma;
        private readonly IAllocationCallbacksProvider _allocationCallbacksProvider;
        private readonly Dictionary<string, Texture> _cache = new();
        public Texture this[string name]
        {
            get
            {
                if (_cache.TryGetValue(name, out var t))
                    return t;
                
                t = CreateImage(SixLabors.ImageSharp.Image.Load(_resourceProvider["textures." + name]), true, true, SampleCountFlags.SampleCount1Bit, ImageAspectFlags.ImageAspectColorBit);
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
            IGraphicsQueueProvider graphicsQueueProvider,
            VulkanMemoryAllocator vma,
            IAllocationCallbacksProvider allocationCallbacksProvider
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
            _vma = vma;
            _allocationCallbacksProvider = allocationCallbacksProvider;
        }

        public unsafe Texture CreateImage(Image<Rgba32> src, bool createSampler, bool useMipmaps, SampleCountFlags numSamples, ImageAspectFlags aspectFlags, ImageUsageFlags imageUsageFlags = default)
        {
            var texture = new Texture
            (
                (uint) src.Width, (uint) src.Height, Format.R8G8B8A8Srgb, numSamples, _vk, _commandBufferFactory,
                _transferQueueProvider, _logicalDeviceProvider, _physicalDeviceProvider, _graphicsQueueProvider,
                _bufferFactory, _vma, createSampler, useMipmaps, aspectFlags,
                imageUsageFlags | ImageUsageFlags.ImageUsageTransferDstBit | ImageUsageFlags.ImageUsageSampledBit |
                ImageUsageFlags.ImageUsageTransferSrcBit,
                _allocationCallbacksProvider
            );
            
            var pixelCount = src.Width * src.Height;
            var totalImageSize = pixelCount * 4;
            var (stagingBuffer, stagingAllocation) = _bufferFactory.CreateBuffer
            (
                (ulong) totalImageSize,new AllocationCreateInfo(AllocationCreateFlags.Mapped, usage: MemoryUsage.CPU_Only), BufferUsageFlags.BufferUsageTransferSrcBit,
                stackalloc[] {_transferQueueProvider.TransferQueueIndex, _graphicsQueueProvider.GraphicsQueueIndex}
            );

            void* data = stagingAllocation.MappedData.ToPointer();
            
            var s = new Span<Rgba32>(data, pixelCount);
            if (src.TryGetSinglePixelSpan(out var s2))
                s2.CopyTo(s);
            else
            {
                for (int r = 0; r < src.Height; r++)
                {
                    s2 = src.GetPixelRowSpan(r);
                    s2.CopyTo(s.Slice(r * pixelCount, src.Width));
                }
            }

            texture.TransitionImageLayout(ImageLayout.TransferDstOptimal);
            texture.CopyBufferToImage(stagingBuffer);
            _vma.FreeMemory(stagingAllocation);
            // implicitly transitions to ShaderReadOnlyOptimal
            texture.GenerateMipmaps();
            
            return texture;
        }
        
        public Texture CreateImage
            (uint width, uint height, Format format, bool createSampler, bool useMipmaps, SampleCountFlags numSamples, ImageAspectFlags aspectFlags, ImageUsageFlags imageUsageFlags)
        {
            return new
            (
                width, height, format, numSamples, _vk, _commandBufferFactory, _transferQueueProvider,
                _logicalDeviceProvider, _physicalDeviceProvider, _graphicsQueueProvider, _bufferFactory, _vma,
                createSampler, useMipmaps, aspectFlags, imageUsageFlags,
                _allocationCallbacksProvider
            );
        }

        public void Dispose()
        {
            foreach (var texture in _cache)
            {
                texture.Value.Dispose();
            }
            
            _cache.Clear();
        }
    }
}
