// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.


using System;
using Silk.NET.Core.Attributes;

#pragma warning disable 1591

namespace Silk.NET.Vulkan
{
    [NativeName("Name", "VkSemaphoreType")]
    public enum SemaphoreType : int
    {
        [NativeName("Name", "VK_SEMAPHORE_TYPE_BINARY")]
        Binary = 0,
        [NativeName("Name", "VK_SEMAPHORE_TYPE_TIMELINE")]
        Timeline = 1,
    }
}
