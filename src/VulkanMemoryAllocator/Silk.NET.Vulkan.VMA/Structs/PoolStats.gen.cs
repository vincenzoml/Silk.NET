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
    [NativeName("Name", "VmaPoolStats")]
    public unsafe partial struct PoolStats
    {
        public PoolStats
        (
            ulong? size = null,
            ulong? unusedSize = null,
            uint? allocationCount = null,
            uint? unusedRangeCount = null,
            ulong? unusedRangeSizeMax = null,
            uint? blockCount = null
        ) : this()
        {
            if (size is not null)
            {
                Size = size.Value;
            }

            if (unusedSize is not null)
            {
                UnusedSize = unusedSize.Value;
            }

            if (allocationCount is not null)
            {
                AllocationCount = allocationCount.Value;
            }

            if (unusedRangeCount is not null)
            {
                UnusedRangeCount = unusedRangeCount.Value;
            }

            if (unusedRangeSizeMax is not null)
            {
                UnusedRangeSizeMax = unusedRangeSizeMax.Value;
            }

            if (blockCount is not null)
            {
                BlockCount = blockCount.Value;
            }
        }


        [NativeName("Type", "DeviceSize")]
        [NativeName("Type.Name", "DeviceSize")]
        [NativeName("Name", "size")]
        public ulong Size;

        [NativeName("Type", "DeviceSize")]
        [NativeName("Type.Name", "DeviceSize")]
        [NativeName("Name", "unusedSize")]
        public ulong UnusedSize;

        [NativeName("Type", "size_t")]
        [NativeName("Type.Name", "size_t")]
        [NativeName("Name", "allocationCount")]
        public uint AllocationCount;

        [NativeName("Type", "size_t")]
        [NativeName("Type.Name", "size_t")]
        [NativeName("Name", "unusedRangeCount")]
        public uint UnusedRangeCount;

        [NativeName("Type", "DeviceSize")]
        [NativeName("Type.Name", "DeviceSize")]
        [NativeName("Name", "unusedRangeSizeMax")]
        public ulong UnusedRangeSizeMax;

        [NativeName("Type", "size_t")]
        [NativeName("Type.Name", "size_t")]
        [NativeName("Name", "blockCount")]
        public uint BlockCount;
    }
}
