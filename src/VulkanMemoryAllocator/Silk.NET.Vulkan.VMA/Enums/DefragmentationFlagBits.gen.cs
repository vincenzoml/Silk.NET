// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.


using System;
using Silk.NET.Core.Attributes;

#pragma warning disable 1591

namespace Silk.NET.Vulkan.VMA
{
    [NativeName("Name", "VmaDefragmentationFlagBits")]
    public enum DefragmentationFlagBits : int
    {
        [NativeName("Name", "VMA_DEFRAGMENTATION_FLAG_INCREMENTAL")]
        DefragmentationFlagIncremental = 1,
        [NativeName("Name", "VMA_DEFRAGMENTATION_FLAG_BITS_MAX_ENUM")]
        DefragmentationFlagBitsMaxEnum = 0x7FFFFFFF,
    }
}
