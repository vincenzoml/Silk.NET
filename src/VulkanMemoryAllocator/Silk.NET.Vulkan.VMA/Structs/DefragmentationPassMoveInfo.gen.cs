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
    [NativeName("Name", "VmaDefragmentationPassMoveInfo")]
    public unsafe partial struct DefragmentationPassMoveInfo
    {
        public DefragmentationPassMoveInfo
        (
            AllocationT* allocation = null,
            ulong? memory = null,
            ulong? offset = null
        ) : this()
        {
            if (allocation is not null)
            {
                Allocation = allocation;
            }

            if (memory is not null)
            {
                Memory = memory.Value;
            }

            if (offset is not null)
            {
                Offset = offset.Value;
            }
        }


        [NativeName("Type", "VmaAllocation _Nonnull")]
        [NativeName("Type.Name", "VmaAllocation _Nonnull")]
        [NativeName("Name", "allocation")]
        public AllocationT* Allocation;

        [NativeName("Type", "DeviceMemory")]
        [NativeName("Type.Name", "DeviceMemory")]
        [NativeName("Name", "memory")]
        public ulong Memory;

        [NativeName("Type", "DeviceSize")]
        [NativeName("Type.Name", "DeviceSize")]
        [NativeName("Name", "offset")]
        public ulong Offset;
    }
}
