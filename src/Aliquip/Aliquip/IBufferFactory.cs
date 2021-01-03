// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using Silk.NET.Vulkan;
using VMASharp;
using Buffer = Silk.NET.Vulkan.Buffer;

namespace Aliquip
{
    public interface IBufferFactory
    {
        (Buffer, Allocation) CreateBuffer
        (
            ulong size,
            AllocationCreateInfo allocationCreateInfo,
            BufferUsageFlags usage,
            Span<uint> queueFamilyIndices
        );
    }
}
