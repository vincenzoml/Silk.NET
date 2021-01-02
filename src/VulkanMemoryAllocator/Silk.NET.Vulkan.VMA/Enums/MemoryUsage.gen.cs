// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.


using System;
using Silk.NET.Core.Attributes;

#pragma warning disable 1591

namespace Silk.NET.Vulkan.VMA
{
    [NativeName("Name", "VmaMemoryUsage")]
    public enum MemoryUsage : int
    {
        [NativeName("Name", "VMA_MEMORY_USAGE_UNKNOWN")]
        MemoryUsageUnknown = 0,
        [NativeName("Name", "VMA_MEMORY_USAGE_GPU_ONLY")]
        MemoryUsageGpuOnly = 1,
        [NativeName("Name", "VMA_MEMORY_USAGE_CPU_ONLY")]
        MemoryUsageCpuOnly = 2,
        [NativeName("Name", "VMA_MEMORY_USAGE_CPU_TO_GPU")]
        MemoryUsageCpuToGpu = 3,
        [NativeName("Name", "VMA_MEMORY_USAGE_GPU_TO_CPU")]
        MemoryUsageGpuToCpu = 4,
        [NativeName("Name", "VMA_MEMORY_USAGE_CPU_COPY")]
        MemoryUsageCpuCopy = 5,
        [NativeName("Name", "VMA_MEMORY_USAGE_GPU_LAZILY_ALLOCATED")]
        MemoryUsageGpuLazilyAllocated = 6,
        [NativeName("Name", "VMA_MEMORY_USAGE_MAX_ENUM")]
        MemoryUsageMaxEnum = 0x7FFFFFFF,
    }
}
