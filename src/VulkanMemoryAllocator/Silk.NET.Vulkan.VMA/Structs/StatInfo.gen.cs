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
    [NativeName("Name", "VmaStatInfo")]
    public unsafe partial struct StatInfo
    {
        public StatInfo
        (
            uint? blockCount = null,
            uint? allocationCount = null,
            uint? unusedRangeCount = null,
            ulong? usedBytes = null,
            ulong? unusedBytes = null,
            ulong? allocationSizeMin = null,
            ulong? allocationSizeAvg = null,
            ulong? allocationSizeMax = null,
            ulong? unusedRangeSizeMin = null,
            ulong? unusedRangeSizeAvg = null,
            ulong? unusedRangeSizeMax = null
        ) : this()
        {
            if (blockCount is not null)
            {
                BlockCount = blockCount.Value;
            }

            if (allocationCount is not null)
            {
                AllocationCount = allocationCount.Value;
            }

            if (unusedRangeCount is not null)
            {
                UnusedRangeCount = unusedRangeCount.Value;
            }

            if (usedBytes is not null)
            {
                UsedBytes = usedBytes.Value;
            }

            if (unusedBytes is not null)
            {
                UnusedBytes = unusedBytes.Value;
            }

            if (allocationSizeMin is not null)
            {
                AllocationSizeMin = allocationSizeMin.Value;
            }

            if (allocationSizeAvg is not null)
            {
                AllocationSizeAvg = allocationSizeAvg.Value;
            }

            if (allocationSizeMax is not null)
            {
                AllocationSizeMax = allocationSizeMax.Value;
            }

            if (unusedRangeSizeMin is not null)
            {
                UnusedRangeSizeMin = unusedRangeSizeMin.Value;
            }

            if (unusedRangeSizeAvg is not null)
            {
                UnusedRangeSizeAvg = unusedRangeSizeAvg.Value;
            }

            if (unusedRangeSizeMax is not null)
            {
                UnusedRangeSizeMax = unusedRangeSizeMax.Value;
            }
        }


        [NativeName("Type", "uint32_t")]
        [NativeName("Type.Name", "uint32_t")]
        [NativeName("Name", "blockCount")]
        public uint BlockCount;

        [NativeName("Type", "uint32_t")]
        [NativeName("Type.Name", "uint32_t")]
        [NativeName("Name", "allocationCount")]
        public uint AllocationCount;

        [NativeName("Type", "uint32_t")]
        [NativeName("Type.Name", "uint32_t")]
        [NativeName("Name", "unusedRangeCount")]
        public uint UnusedRangeCount;

        [NativeName("Type", "DeviceSize")]
        [NativeName("Type.Name", "DeviceSize")]
        [NativeName("Name", "usedBytes")]
        public ulong UsedBytes;

        [NativeName("Type", "DeviceSize")]
        [NativeName("Type.Name", "DeviceSize")]
        [NativeName("Name", "unusedBytes")]
        public ulong UnusedBytes;

        [NativeName("Type", "DeviceSize")]
        [NativeName("Type.Name", "DeviceSize")]
        [NativeName("Name", "allocationSizeMin")]
        public ulong AllocationSizeMin;

        [NativeName("Type", "DeviceSize")]
        [NativeName("Type.Name", "DeviceSize")]
        [NativeName("Name", "allocationSizeAvg")]
        public ulong AllocationSizeAvg;

        [NativeName("Type", "DeviceSize")]
        [NativeName("Type.Name", "DeviceSize")]
        [NativeName("Name", "allocationSizeMax")]
        public ulong AllocationSizeMax;

        [NativeName("Type", "DeviceSize")]
        [NativeName("Type.Name", "DeviceSize")]
        [NativeName("Name", "unusedRangeSizeMin")]
        public ulong UnusedRangeSizeMin;

        [NativeName("Type", "DeviceSize")]
        [NativeName("Type.Name", "DeviceSize")]
        [NativeName("Name", "unusedRangeSizeAvg")]
        public ulong UnusedRangeSizeAvg;

        [NativeName("Type", "DeviceSize")]
        [NativeName("Type.Name", "DeviceSize")]
        [NativeName("Name", "unusedRangeSizeMax")]
        public ulong UnusedRangeSizeMax;
    }
}
