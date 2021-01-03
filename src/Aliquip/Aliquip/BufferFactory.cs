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
    internal sealed class BufferFactory : IBufferFactory
    {
        private readonly VulkanMemoryAllocator _vma;

        public BufferFactory(VulkanMemoryAllocator vma)
        {
            _vma = vma;
        }
        
        public unsafe (Buffer, Allocation) CreateBuffer(ulong size, AllocationCreateInfo allocationCreateInfo, BufferUsageFlags usage, Span<uint> queueFamilyIndices)
        {
            fixed (uint* pQueueFamilyIndices = queueFamilyIndices)
            {
                var bufferInfo = new BufferCreateInfo
                (
                    size: size, usage: usage,
                    sharingMode: queueFamilyIndices.Length > 1 ? SharingMode.Concurrent : SharingMode.Exclusive, // TODO: Use barriers to transfer ownership instead.
                    queueFamilyIndexCount: (uint) queueFamilyIndices.Length, pQueueFamilyIndices: pQueueFamilyIndices
                );
                var buffer = _vma.CreateBuffer(bufferInfo, allocationCreateInfo, out var allocation);
                return (buffer, allocation);
            }
        }
    }
}
