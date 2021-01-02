// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.


using System;
using Silk.NET.Core.Attributes;

#pragma warning disable 1591

namespace Silk.NET.Vulkan.VMA
{
    [NativeName("Name", "VmaPoolCreateFlagBits")]
    public enum PoolCreateFlagBits : int
    {
        [NativeName("Name", "VMA_POOL_CREATE_IGNORE_BUFFER_IMAGE_GRANULARITY_BIT")]
        PoolCreateIgnoreBufferImageGranularityBit = 2,
        [NativeName("Name", "VMA_POOL_CREATE_LINEAR_ALGORITHM_BIT")]
        PoolCreateLinearAlgorithmBit = 4,
        [NativeName("Name", "VMA_POOL_CREATE_BUDDY_ALGORITHM_BIT")]
        PoolCreateBuddyAlgorithmBit = 8,
        [NativeName("Name", "VMA_POOL_CREATE_ALGORITHM_MASK")]
        PoolCreateAlgorithmMask = 0xC,
        [NativeName("Name", "VMA_POOL_CREATE_FLAG_BITS_MAX_ENUM")]
        PoolCreateFlagBitsMaxEnum = 0x7FFFFFFF,
    }
}
