// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Diagnostics;
using System.Numerics;
using Silk.NET.Maths;
using Silk.NET.Vulkan;
using Silk.NET.Vulkan.VMA;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using Buffer = Silk.NET.Vulkan.Buffer;
using Image = Silk.NET.Vulkan.Image;

namespace Aliquip
{
    public sealed class Texture : IDisposable
    {
        private readonly Vk _vk;
        private readonly ICommandBufferFactory _commandBufferFactory;
        private readonly ITransferQueueProvider _transferQueueProvider;
        private readonly ILogicalDeviceProvider _logicalDeviceProvider;
        private readonly IPhysicalDeviceProvider _physicalDeviceProvider;
        private readonly IGraphicsQueueProvider _graphicsQueueProvider;
        private readonly IBufferFactory _bufferFactory;
        private readonly IAllocatorProvider _allocatorProvider;
        private readonly Vma _vma;
        private readonly uint _width;
        private readonly uint _height;
        private readonly ImageAspectFlags _aspectFlags;
        private unsafe AllocationT* _imageAllocation;
        private readonly AllocationInfo _imageAllocationInfo;
        public uint MipLevels { get; }
        public Image Image { get; }
        private ImageLayout _layout = ImageLayout.Undefined;
        public Format Format { get; }
        public ImageView ImageView { get; }
        public Sampler Sampler { get; }

        public unsafe Texture
        (
            uint width,
            uint height,
            Format format,
            SampleCountFlags numSamples,
            Vk vk,
            ICommandBufferFactory commandBufferFactory,
            ITransferQueueProvider transferQueueProvider,
            ILogicalDeviceProvider logicalDeviceProvider,
            IPhysicalDeviceProvider physicalDeviceProvider,
            IGraphicsQueueProvider graphicsQueueProvider,
            IBufferFactory bufferFactory,
            IAllocatorProvider allocatorProvider,
            Vma vma,
            bool createSampler,
            bool useMipmaps,
            ImageAspectFlags aspectFlags,
            ImageUsageFlags imageUsageFlags
        )
        {
            _vk = vk;
            _commandBufferFactory = commandBufferFactory;
            _transferQueueProvider = transferQueueProvider;
            _logicalDeviceProvider = logicalDeviceProvider;
            _physicalDeviceProvider = physicalDeviceProvider;
            _graphicsQueueProvider = graphicsQueueProvider;
            _bufferFactory = bufferFactory;
            _allocatorProvider = allocatorProvider;
            _vma = vma;
            _aspectFlags = aspectFlags;
            Format = format;
            _width = width;
            _height = height;

            if (useMipmaps)
            {
                MipLevels = Scalar.Floor((uint)BitOperations.Log2(Scalar.Max(width, height))) + 1;
            }
            else
            {
                MipLevels = 1;
            }

            var imageInfo = new ImageCreateInfo
            (
                imageType: ImageType.ImageType2D,
                extent: new Extent3D(width: width, height: height, depth: 1), 
                mipLevels: MipLevels,
                arrayLayers: 1,
                format: Format,
                tiling: ImageTiling.Optimal,
                initialLayout: ImageLayout.Undefined,
                sharingMode: SharingMode.Exclusive,
                usage: imageUsageFlags,
                samples: numSamples
            );

            var allocator = _allocatorProvider.Allocator;
            var allocationCreateInfo = new AllocationCreateInfo(0, MemoryUsage.MemoryUsageGpuOnly, 0, 0, 0, null, null);
            ulong imageHandle = default;
            AllocationT* allocation = default;
            AllocationInfo resAllocationInfo = default;
            _vma.CreateImage(&allocator, &imageInfo, &allocationCreateInfo, &imageHandle, &allocation, &resAllocationInfo).ThrowCode();
            Image = new Image(imageHandle);
            _imageAllocation = allocation;
            _imageAllocationInfo = resAllocationInfo;

            ImageViewCreateInfo viewInfo = new ImageViewCreateInfo
            (
                image: Image, viewType: ImageViewType.ImageViewType2D, format: Format,
                subresourceRange: new ImageSubresourceRange
                (
                    aspectMask: _aspectFlags, baseMipLevel: 0, levelCount: MipLevels, baseArrayLayer: 0,
                    layerCount: 1
                )
            );

            _vk.CreateImageView(_logicalDeviceProvider.LogicalDevice, viewInfo, null, out var imageView).ThrowCode();
            ImageView = imageView;

            if (createSampler)
            {
                _vk.GetPhysicalDeviceProperties(_physicalDeviceProvider.Device, out var properties);

                var samplerInfo = new SamplerCreateInfo
                (
                    magFilter: Filter.Linear, minFilter: Filter.Linear, addressModeU: SamplerAddressMode.Repeat,
                    addressModeV: SamplerAddressMode.Repeat, addressModeW: SamplerAddressMode.Repeat,
                    anisotropyEnable: true, maxAnisotropy: properties.Limits.MaxSamplerAnisotropy,
                    borderColor: BorderColor.FloatOpaqueBlack, unnormalizedCoordinates: false, compareEnable: false,
                    compareOp: CompareOp.Never, mipmapMode: SamplerMipmapMode.Linear, mipLodBias: 0.0f, minLod: 0.0f,
                    maxLod: MipLevels
                );

                _vk.CreateSampler(_logicalDeviceProvider.LogicalDevice, samplerInfo, null, out var sampler);
                Sampler = sampler;
            }
        }
        
        public unsafe void CopyBufferToImage(Buffer src)
        {
            Debug.Assert(_layout == ImageLayout.TransferDstOptimal);
            _commandBufferFactory.RunSingleTime
            (
                _transferQueueProvider.TransferQueueIndex, _transferQueueProvider.TransferQueue,
                cmd =>
                {
                    var region = new BufferImageCopy
                    (
                        bufferOffset: 0, bufferRowLength: 0, bufferImageHeight: 0,
                        imageSubresource: new ImageSubresourceLayers
                            (aspectMask: _aspectFlags, mipLevel: 0, baseArrayLayer: 0, layerCount: 1),
                        imageOffset: new Offset3D(0, 0, 0), imageExtent: new(_width, _height, 1)
                    );
                    
                    _vk.CmdCopyBufferToImage(cmd, src, Image, ImageLayout.TransferDstOptimal, 1, &region);
                }
            );
        }
        
        public unsafe void TransitionImageLayout(ImageLayout @new)
        {
            if (_layout == @new)
                return;
            
            uint srcFamilyIndex;
            uint dstFamilyIndex;
            PipelineStageFlags sourceStage;
            PipelineStageFlags destinationStage;
            AccessFlags srcAccessMask;
            AccessFlags dstAccessMask;
            Queue srcQueue;
            Queue dstQueue;
            
            switch (@new)
            {
                case ImageLayout.TransferDstOptimal when _layout is ImageLayout.Undefined:
                    srcAccessMask = 0;
                    dstAccessMask = AccessFlags.AccessTransferWriteBit;

                    sourceStage = PipelineStageFlags.PipelineStageTopOfPipeBit;
                    destinationStage = PipelineStageFlags.PipelineStageTransferBit;

                    srcFamilyIndex = Vk.QueueFamilyExternal;
                    srcQueue = default;
                    dstFamilyIndex = _transferQueueProvider.TransferQueueIndex;
                    dstQueue = _transferQueueProvider.TransferQueue;
                    break;
                case ImageLayout.ShaderReadOnlyOptimal when _layout is ImageLayout.TransferDstOptimal:
                    srcAccessMask = AccessFlags.AccessTransferWriteBit;
                    dstAccessMask = AccessFlags.AccessShaderReadBit;

                    sourceStage = PipelineStageFlags.PipelineStageTransferBit;
                    destinationStage = PipelineStageFlags.PipelineStageFragmentShaderBit;

                    srcFamilyIndex = _transferQueueProvider.TransferQueueIndex;
                    srcQueue = _transferQueueProvider.TransferQueue;
                    dstFamilyIndex = _graphicsQueueProvider.GraphicsQueueIndex;
                    dstQueue = _graphicsQueueProvider.GraphicsQueue;
                    break;
                case ImageLayout.DepthStencilAttachmentOptimal when _layout is ImageLayout.Undefined:
                    srcAccessMask = 0;
                    dstAccessMask = AccessFlags.AccessDepthStencilAttachmentReadBit | AccessFlags.AccessDepthStencilAttachmentWriteBit;

                    sourceStage = PipelineStageFlags.PipelineStageTopOfPipeBit;
                    destinationStage = PipelineStageFlags.PipelineStageEarlyFragmentTestsBit;

                    srcFamilyIndex = Vk.QueueFamilyExternal;
                    srcQueue = default;
                    dstFamilyIndex = _graphicsQueueProvider.GraphicsQueueIndex;
                    dstQueue = _graphicsQueueProvider.GraphicsQueue;
                    break;
                default:
                    throw new Exception("Could not find transition combination");
            }

            if (srcFamilyIndex != dstFamilyIndex && srcFamilyIndex != Vk.QueueFamilyExternal)
            {
                _commandBufferFactory.RunSingleTime
                (
                    srcFamilyIndex, srcQueue, cmd =>
                    {
                        var releaseBarrier = new ImageMemoryBarrier
                        (
                            oldLayout: _layout, newLayout: _layout, srcQueueFamilyIndex: srcFamilyIndex,
                            dstQueueFamilyIndex: dstFamilyIndex, image: Image,
                            subresourceRange: new ImageSubresourceRange
                            (
                                aspectMask: _aspectFlags, baseMipLevel: 0, levelCount: MipLevels,
                                baseArrayLayer: 0, layerCount: 1
                            ), srcAccessMask: srcAccessMask, dstAccessMask: srcAccessMask
                        );

                        _vk.CmdPipelineBarrier(cmd,
                            sourceStage, sourceStage,
                            0,
                            0, null,
                            0, null,
                            1, &releaseBarrier);
                    }
                );
            }

            _commandBufferFactory.RunSingleTime(dstFamilyIndex, dstQueue,
                cmd =>
                {
                    var barrier = new ImageMemoryBarrier
                    (
                        oldLayout: _layout, newLayout: @new, srcQueueFamilyIndex: srcFamilyIndex,
                        dstQueueFamilyIndex: dstFamilyIndex, image: Image,
                        subresourceRange: new ImageSubresourceRange
                        (
                            aspectMask: _aspectFlags, baseMipLevel: 0, levelCount: MipLevels,
                            baseArrayLayer: 0, layerCount: 1
                        ), srcAccessMask: srcAccessMask, dstAccessMask: dstAccessMask
                    );

                    _vk.CmdPipelineBarrier(cmd,
                        sourceStage, destinationStage,
                        0, 
                        0, null,
                        0, null,
                        1, &barrier);
                });

            _layout = @new;
        }

        public unsafe void Dispose()
        {
            _vk.DestroyImageView(_logicalDeviceProvider.LogicalDevice, ImageView, null);
            var allocator = _allocatorProvider.Allocator;
            _vma.DestroyImage(&allocator, Image.Handle, _imageAllocation);
        }

        // TODO: Mipmaps should be generated at compile time and loaded.
        public unsafe void GenerateMipmaps()
        {
            // check if image format supports linear blitting
             _vk.GetPhysicalDeviceFormatProperties(_physicalDeviceProvider.Device, Format, out var formatProperties);
             
             if ((formatProperties.OptimalTilingFeatures & FormatFeatureFlags.FormatFeatureSampledImageFilterLinearBit) == 0)
                 throw new Exception("Texture image format does not support linear blitting!");

            // release ownership from transfer queue to graphics queue
            _commandBufferFactory.RunSingleTime(_transferQueueProvider.TransferQueueIndex, _transferQueueProvider.TransferQueue,
                cmd =>
                {
                    var releaseBarrier = new ImageMemoryBarrier
                    (
                        oldLayout: _layout, newLayout: _layout, srcQueueFamilyIndex: _transferQueueProvider.TransferQueueIndex,
                        dstQueueFamilyIndex: _graphicsQueueProvider.GraphicsQueueIndex, image: Image,
                        subresourceRange: new ImageSubresourceRange
                        (
                            aspectMask: _aspectFlags, baseMipLevel: 0, levelCount: MipLevels,
                            baseArrayLayer: 0, layerCount: 1
                        ), srcAccessMask: AccessFlags.AccessTransferWriteBit, dstAccessMask: AccessFlags.AccessTransferReadBit
                    );
                    
                    _vk.CmdPipelineBarrier(cmd,
                        PipelineStageFlags.PipelineStageTransferBit, PipelineStageFlags.PipelineStageTransferBit,
                        0,
                        0, null,
                        0, null,
                        1, &releaseBarrier);
                });
            
            _commandBufferFactory.RunSingleTime
                (_graphicsQueueProvider.GraphicsQueueIndex, _graphicsQueueProvider.GraphicsQueue, cmd =>
            {
                // transfer ownership of all levels at once
                var releaseBarrier = new ImageMemoryBarrier
                (
                    oldLayout: _layout, newLayout: _layout, srcQueueFamilyIndex: _transferQueueProvider.TransferQueueIndex,
                    dstQueueFamilyIndex: _graphicsQueueProvider.GraphicsQueueIndex, image: Image,
                    subresourceRange: new ImageSubresourceRange
                    (
                        aspectMask: _aspectFlags, baseMipLevel: 0, levelCount: MipLevels,
                        baseArrayLayer: 0, layerCount: 1
                    ), srcAccessMask: AccessFlags.AccessTransferWriteBit, dstAccessMask: AccessFlags.AccessTransferReadBit
                );
                    
                _vk.CmdPipelineBarrier(cmd,
                    PipelineStageFlags.PipelineStageTransferBit, PipelineStageFlags.PipelineStageTransferBit,
                    0,
                    0, null,
                    0, null,
                    1, &releaseBarrier);
                
                
                var barrier = new ImageMemoryBarrier
                (
                    image: Image,
                    subresourceRange: new ImageSubresourceRange
                        (aspectMask: _aspectFlags, baseArrayLayer: 0, layerCount: 1, levelCount: 1));
                
                var mipWidth = _width;
                var mipHeight = _height;

                for (int i = 1; i < MipLevels; i++)
                {
                    barrier.SubresourceRange.BaseMipLevel = (uint) (i - 1);
                    barrier.OldLayout = ImageLayout.TransferDstOptimal;
                    barrier.NewLayout = ImageLayout.TransferSrcOptimal;
                    barrier.SrcAccessMask = AccessFlags.AccessTransferWriteBit;
                    barrier.DstAccessMask = AccessFlags.AccessTransferReadBit;
                    barrier.SrcQueueFamilyIndex = _graphicsQueueProvider.GraphicsQueueIndex;
                    barrier.DstQueueFamilyIndex = _graphicsQueueProvider.GraphicsQueueIndex;
                    
                    _vk.CmdPipelineBarrier
                    (
                        cmd, PipelineStageFlags.PipelineStageTransferBit, PipelineStageFlags.PipelineStageTransferBit, 0, 0,
                        null, 0, null, 1, &barrier
                    );

                    var blit = new ImageBlit();
                    blit.SrcOffsets[0] = new Offset3D(0, 0, 0);
                    blit.SrcOffsets[1] = new Offset3D((int)mipWidth, (int)mipHeight, 1);
                    blit.SrcSubresource.MipLevel = (uint) (i - 1);
                    blit.SrcSubresource.AspectMask = _aspectFlags;
                    blit.SrcSubresource.BaseArrayLayer = 0;
                    blit.SrcSubresource.LayerCount = 1;
                    
                    if (mipWidth > 1) mipWidth /= 2;
                    if (mipHeight > 1) mipHeight /= 2;
                    
                    blit.DstOffsets[0] = new Offset3D(0, 0, 0);
                    blit.DstOffsets[1] = new Offset3D((int)mipWidth, (int)mipHeight, 1);
                    blit.DstSubresource.AspectMask = _aspectFlags;
                    blit.DstSubresource.MipLevel = (uint)i;
                    blit.DstSubresource.BaseArrayLayer = 0;
                    blit.DstSubresource.LayerCount = 1;
                    
                    _vk.CmdBlitImage(cmd,
                        Image, ImageLayout.TransferSrcOptimal,
                        Image, ImageLayout.TransferDstOptimal,
                        1, &blit,
                        Filter.Linear);
                
                    barrier.SrcQueueFamilyIndex = Vk.QueueFamilyIgnored;
                    barrier.DstQueueFamilyIndex = Vk.QueueFamilyIgnored;
                    barrier.OldLayout = ImageLayout.TransferSrcOptimal;
                    barrier.NewLayout = ImageLayout.ShaderReadOnlyOptimal;
                    barrier.SrcAccessMask = AccessFlags.AccessTransferReadBit;
                    barrier.DstAccessMask = AccessFlags.AccessShaderReadBit;

                    _vk.CmdPipelineBarrier
                    (
                        cmd, PipelineStageFlags.PipelineStageTransferBit,
                        PipelineStageFlags.PipelineStageFragmentShaderBit, 0, 0, null, 0, null, 1, &barrier
                    );
                }
                
                barrier.SubresourceRange.BaseMipLevel = MipLevels - 1;
                barrier.OldLayout = ImageLayout.TransferDstOptimal;
                barrier.NewLayout = ImageLayout.ShaderReadOnlyOptimal;
                barrier.SrcAccessMask = AccessFlags.AccessTransferWriteBit;
                barrier.DstAccessMask = AccessFlags.AccessShaderReadBit;

                _vk.CmdPipelineBarrier
                (
                    cmd, PipelineStageFlags.PipelineStageTransferBit,
                    PipelineStageFlags.PipelineStageFragmentShaderBit, 0, 0, null, 0, null, 1, &barrier
                );
            });

            _layout = ImageLayout.ShaderReadOnlyOptimal;
        }
    }
}
