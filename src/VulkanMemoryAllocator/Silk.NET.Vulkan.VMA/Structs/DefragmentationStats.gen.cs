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
    [NativeName("Name", "VmaDefragmentationStats")]
    public unsafe partial struct DefragmentationStats
    {
        public DefragmentationStats
        (
            ulong? bytesMoved = null,
            ulong? bytesFreed = null,
            uint? allocationsMoved = null,
            uint? deviceMemoryBlocksFreed = null
        ) : this()
        {
            if (bytesMoved is not null)
            {
                BytesMoved = bytesMoved.Value;
            }

            if (bytesFreed is not null)
            {
                BytesFreed = bytesFreed.Value;
            }

            if (allocationsMoved is not null)
            {
                AllocationsMoved = allocationsMoved.Value;
            }

            if (deviceMemoryBlocksFreed is not null)
            {
                DeviceMemoryBlocksFreed = deviceMemoryBlocksFreed.Value;
            }
        }


        [NativeName("Type", "DeviceSize")]
        [NativeName("Type.Name", "DeviceSize")]
        [NativeName("Name", "bytesMoved")]
        public ulong BytesMoved;

        [NativeName("Type", "DeviceSize")]
        [NativeName("Type.Name", "DeviceSize")]
        [NativeName("Name", "bytesFreed")]
        public ulong BytesFreed;

        [NativeName("Type", "uint32_t")]
        [NativeName("Type.Name", "uint32_t")]
        [NativeName("Name", "allocationsMoved")]
        public uint AllocationsMoved;

        [NativeName("Type", "uint32_t")]
        [NativeName("Type.Name", "uint32_t")]
        [NativeName("Name", "deviceMemoryBlocksFreed")]
        public uint DeviceMemoryBlocksFreed;
    }
}
