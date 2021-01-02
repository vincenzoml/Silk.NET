// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using Silk.NET.Vulkan;
using Silk.NET.Vulkan.VMA;
using Buffer = Silk.NET.Vulkan.Buffer;

namespace Aliquip
{
    public interface IBufferFactory
    {
        (Buffer, AllocationT, AllocationInfo) CreateBuffer
        (
            ulong size,
            MemoryUsage memoryUsage,
            BufferUsageFlags usage,
            MemoryPropertyFlags properties,
            Span<uint> queueFamilyIndices,
            AllocationCreateFlagBits createFlags
        );

        void FreeBuffer(Buffer buffer, AllocationT allocation);
    }
}
