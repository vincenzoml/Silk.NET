// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.


using System;
using Silk.NET.Core.Attributes;

#pragma warning disable 1591

namespace Silk.NET.Vulkan.VMA
{
    [NativeName("Name", "VmaRecordFlagBits")]
    public enum RecordFlagBits : int
    {
        [NativeName("Name", "VMA_RECORD_FLUSH_AFTER_CALL_BIT")]
        RecordFlushAfterCallBit = 1,
        [NativeName("Name", "VMA_RECORD_FLAG_BITS_MAX_ENUM")]
        RecordFlagBitsMaxEnum = 0x7FFFFFFF,
    }
}
