// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.


using System;
using Silk.NET.Core.Attributes;

#pragma warning disable 1591

namespace Silk.NET.Vulkan.VMA
{
    [NativeName("Name", "VmaAllocatorCreateFlagBits")]
    public enum AllocatorCreateFlagBits : int
    {
        [NativeName("Name", "VMA_ALLOCATOR_CREATE_EXTERNALLY_SYNCHRONIZED_BIT")]
        AllocatorCreateExternallySynchronizedBit = 1,
        [NativeName("Name", "VMA_ALLOCATOR_CREATE_KHR_DEDICATED_ALLOCATION_BIT")]
        AllocatorCreateKhrDedicatedAllocationBit = 2,
        [NativeName("Name", "VMA_ALLOCATOR_CREATE_KHR_BIND_MEMORY2_BIT")]
        AllocatorCreateKhrBindMemory2Bit = 4,
        [NativeName("Name", "VMA_ALLOCATOR_CREATE_EXT_MEMORY_BUDGET_BIT")]
        AllocatorCreateExtMemoryBudgetBit = 8,
        [NativeName("Name", "VMA_ALLOCATOR_CREATE_AMD_DEVICE_COHERENT_MEMORY_BIT")]
        AllocatorCreateAmdDeviceCoherentMemoryBit = 10,
        [NativeName("Name", "VMA_ALLOCATOR_CREATE_BUFFER_DEVICE_ADDRESS_BIT")]
        AllocatorCreateBufferDeviceAddressBit = 20,
        [NativeName("Name", "VMA_ALLOCATOR_CREATE_FLAG_BITS_MAX_ENUM")]
        AllocatorCreateFlagBitsMaxEnum = 0x7FFFFFFF,
    }
}
