// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.


using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Text;
using Silk.NET.Core;
using Silk.NET.Core.Native;
using Silk.NET.Core.Attributes;
using Silk.NET.Core.Contexts;
using Silk.NET.Core.Loader;

#pragma warning disable 1591

namespace Silk.NET.Vulkan.VMA
{
    [NativeName("Name", "VmaPoolCreateInfo")]
    public unsafe partial struct PoolCreateInfo
    {
        public PoolCreateInfo
        (
            uint? memoryTypeIndex = null,
            uint? flags = null,
            ulong? blockSize = null,
            uint? minBlockCount = null,
            uint? maxBlockCount = null,
            uint? frameInUseCount = null
        ) : this()
        {
            if (memoryTypeIndex is not null)
            {
                MemoryTypeIndex = memoryTypeIndex.Value;
            }

            if (flags is not null)
            {
                Flags = flags.Value;
            }

            if (blockSize is not null)
            {
                BlockSize = blockSize.Value;
            }

            if (minBlockCount is not null)
            {
                MinBlockCount = minBlockCount.Value;
            }

            if (maxBlockCount is not null)
            {
                MaxBlockCount = maxBlockCount.Value;
            }

            if (frameInUseCount is not null)
            {
                FrameInUseCount = frameInUseCount.Value;
            }
        }


        [NativeName("Type", "uint32_t")]
        [NativeName("Type.Name", "uint32_t")]
        [NativeName("Name", "memoryTypeIndex")]
        public uint MemoryTypeIndex;

        [NativeName("Type", "VmaPoolCreateFlags")]
        [NativeName("Type.Name", "VmaPoolCreateFlags")]
        [NativeName("Name", "flags")]
        public uint Flags;

        [NativeName("Type", "DeviceSize")]
        [NativeName("Type.Name", "DeviceSize")]
        [NativeName("Name", "blockSize")]
        public ulong BlockSize;

        [NativeName("Type", "size_t")]
        [NativeName("Type.Name", "size_t")]
        [NativeName("Name", "minBlockCount")]
        public uint MinBlockCount;

        [NativeName("Type", "size_t")]
        [NativeName("Type.Name", "size_t")]
        [NativeName("Name", "maxBlockCount")]
        public uint MaxBlockCount;

        [NativeName("Type", "uint32_t")]
        [NativeName("Type.Name", "uint32_t")]
        [NativeName("Name", "frameInUseCount")]
        public uint FrameInUseCount;
    }
}
