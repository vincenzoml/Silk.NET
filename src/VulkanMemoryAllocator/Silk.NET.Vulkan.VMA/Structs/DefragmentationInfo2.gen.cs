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
    [NativeName("Name", "VmaDefragmentationInfo2")]
    public unsafe partial struct DefragmentationInfo2
    {
        public DefragmentationInfo2
        (
            uint? flags = null,
            uint? allocationCount = null,
            AllocationT** pAllocations = null,
            uint* pAllocationsChanged = null,
            uint? poolCount = null,
            PoolT** pPools = null,
            ulong? maxCpuBytesToMove = null,
            uint? maxCpuAllocationsToMove = null,
            ulong? maxGpuBytesToMove = null,
            uint? maxGpuAllocationsToMove = null,
            CommandBuffer* commandBuffer = null
        ) : this()
        {
            if (flags is not null)
            {
                Flags = flags.Value;
            }

            if (allocationCount is not null)
            {
                AllocationCount = allocationCount.Value;
            }

            if (pAllocations is not null)
            {
                PAllocations = pAllocations;
            }

            if (pAllocationsChanged is not null)
            {
                PAllocationsChanged = pAllocationsChanged;
            }

            if (poolCount is not null)
            {
                PoolCount = poolCount.Value;
            }

            if (pPools is not null)
            {
                PPools = pPools;
            }

            if (maxCpuBytesToMove is not null)
            {
                MaxCpuBytesToMove = maxCpuBytesToMove.Value;
            }

            if (maxCpuAllocationsToMove is not null)
            {
                MaxCpuAllocationsToMove = maxCpuAllocationsToMove.Value;
            }

            if (maxGpuBytesToMove is not null)
            {
                MaxGpuBytesToMove = maxGpuBytesToMove.Value;
            }

            if (maxGpuAllocationsToMove is not null)
            {
                MaxGpuAllocationsToMove = maxGpuAllocationsToMove.Value;
            }

            if (commandBuffer is not null)
            {
                CommandBuffer = commandBuffer;
            }
        }


        [NativeName("Type", "VmaDefragmentationFlags")]
        [NativeName("Type.Name", "VmaDefragmentationFlags")]
        [NativeName("Name", "flags")]
        public uint Flags;

        [NativeName("Type", "uint32_t")]
        [NativeName("Type.Name", "uint32_t")]
        [NativeName("Name", "allocationCount")]
        public uint AllocationCount;

        [NativeName("Type", "VmaAllocation  _Nonnull const * _Nullable")]
        [NativeName("Type.Name", "VmaAllocation  _Nonnull const * _Nullable")]
        [NativeName("Name", "pAllocations")]
        public AllocationT** PAllocations;

        [NativeName("Type", "Bool32 * _Nullable")]
        [NativeName("Type.Name", "Bool32 * _Nullable")]
        [NativeName("Name", "pAllocationsChanged")]
        public uint* PAllocationsChanged;

        [NativeName("Type", "uint32_t")]
        [NativeName("Type.Name", "uint32_t")]
        [NativeName("Name", "poolCount")]
        public uint PoolCount;

        [NativeName("Type", "VmaPool  _Nonnull const * _Nullable")]
        [NativeName("Type.Name", "VmaPool  _Nonnull const * _Nullable")]
        [NativeName("Name", "pPools")]
        public PoolT** PPools;

        [NativeName("Type", "DeviceSize")]
        [NativeName("Type.Name", "DeviceSize")]
        [NativeName("Name", "maxCpuBytesToMove")]
        public ulong MaxCpuBytesToMove;

        [NativeName("Type", "uint32_t")]
        [NativeName("Type.Name", "uint32_t")]
        [NativeName("Name", "maxCpuAllocationsToMove")]
        public uint MaxCpuAllocationsToMove;

        [NativeName("Type", "DeviceSize")]
        [NativeName("Type.Name", "DeviceSize")]
        [NativeName("Name", "maxGpuBytesToMove")]
        public ulong MaxGpuBytesToMove;

        [NativeName("Type", "uint32_t")]
        [NativeName("Type.Name", "uint32_t")]
        [NativeName("Name", "maxGpuAllocationsToMove")]
        public uint MaxGpuAllocationsToMove;

        [NativeName("Type", "CommandBuffer _Nullable")]
        [NativeName("Type.Name", "CommandBuffer _Nullable")]
        [NativeName("Name", "commandBuffer")]
        public CommandBuffer* CommandBuffer;
    }
}
