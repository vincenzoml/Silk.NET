// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.


using System;
using Silk.NET.Core.Attributes;

#pragma warning disable 1591

namespace Silk.NET.Vulkan.VMA
{
    [NativeName("Name", "VmaAllocationCreateFlagBits")]
    public enum AllocationCreateFlagBits : int
    {
        [NativeName("Name", "VMA_ALLOCATION_CREATE_DEDICATED_MEMORY_BIT")]
        AllocationCreateDedicatedMemoryBit = 1,
        [NativeName("Name", "VMA_ALLOCATION_CREATE_NEVER_ALLOCATE_BIT")]
        AllocationCreateNeverAllocateBit = 2,
        [NativeName("Name", "VMA_ALLOCATION_CREATE_MAPPED_BIT")]
        AllocationCreateMappedBit = 4,
        [NativeName("Name", "VMA_ALLOCATION_CREATE_CAN_BECOME_LOST_BIT")]
        AllocationCreateCanBecomeLostBit = 8,
        [NativeName("Name", "VMA_ALLOCATION_CREATE_CAN_MAKE_OTHER_LOST_BIT")]
        AllocationCreateCanMakeOtherLostBit = 10,
        [NativeName("Name", "VMA_ALLOCATION_CREATE_USER_DATA_COPY_STRING_BIT")]
        AllocationCreateUserDataCopyStringBit = 20,
        [NativeName("Name", "VMA_ALLOCATION_CREATE_UPPER_ADDRESS_BIT")]
        AllocationCreateUpperAddressBit = 40,
        [NativeName("Name", "VMA_ALLOCATION_CREATE_DONT_BIND_BIT")]
        AllocationCreateDontBindBit = 80,
        [NativeName("Name", "VMA_ALLOCATION_CREATE_WITHIN_BUDGET_BIT")]
        AllocationCreateWithinBudgetBit = 100,
        [NativeName("Name", "VMA_ALLOCATION_CREATE_STRATEGY_BEST_FIT_BIT")]
        AllocationCreateStrategyBestFitBit = 10000,
        [NativeName("Name", "VMA_ALLOCATION_CREATE_STRATEGY_WORST_FIT_BIT")]
        AllocationCreateStrategyWorstFitBit = 20000,
        [NativeName("Name", "VMA_ALLOCATION_CREATE_STRATEGY_FIRST_FIT_BIT")]
        AllocationCreateStrategyFirstFitBit = 40000,
        [NativeName("Name", "VMA_ALLOCATION_CREATE_STRATEGY_MIN_MEMORY_BIT")]
        AllocationCreateStrategyMinMemoryBit = 10000,
        [NativeName("Name", "VMA_ALLOCATION_CREATE_STRATEGY_MIN_TIME_BIT")]
        AllocationCreateStrategyMinTimeBit = 40000,
        [NativeName("Name", "VMA_ALLOCATION_CREATE_STRATEGY_MIN_FRAGMENTATION_BIT")]
        AllocationCreateStrategyMinFragmentationBit = 20000,
        [NativeName("Name", "VMA_ALLOCATION_CREATE_STRATEGY_MASK")]
        AllocationCreateStrategyMask = 70000,
        [NativeName("Name", "VMA_ALLOCATION_CREATE_FLAG_BITS_MAX_ENUM")]
        AllocationCreateFlagBitsMaxEnum = 0x7FFFFFFF,
    }
}
