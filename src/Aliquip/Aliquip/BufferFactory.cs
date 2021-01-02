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
    internal sealed class BufferFactory : IBufferFactory
    {
        private readonly Vk _vk;
        private readonly ILogicalDeviceProvider _logicalDeviceProvider;
        private readonly IPhysicalDeviceProvider _physicalDeviceProvider;
        private readonly Vma _vma;
        private readonly IAllocatorProvider _allocatorProvider;

        public BufferFactory(Vk vk, ILogicalDeviceProvider logicalDeviceProvider, IPhysicalDeviceProvider physicalDeviceProvider, Vma vma, IAllocatorProvider allocatorProvider)
        {
            _vk = vk;
            _logicalDeviceProvider = logicalDeviceProvider;
            _physicalDeviceProvider = physicalDeviceProvider;
            _vma = vma;
            _allocatorProvider = allocatorProvider;
        }
        
        public unsafe (Buffer, AllocationT, AllocationInfo) CreateBuffer(ulong size, MemoryUsage memoryUsage, BufferUsageFlags usage, MemoryPropertyFlags properties, Span<uint> queueFamilyIndices, AllocationCreateFlagBits createFlags)
        {
            fixed (uint* pQueueFamilyIndices = queueFamilyIndices)
            {
                var bufferCreateInfo = new BufferCreateInfo
                (
                    size: size, usage: usage,
                    sharingMode: queueFamilyIndices.Length > 1 ? SharingMode.Concurrent : SharingMode.Exclusive, // TODO: Use barriers to transfer ownership instead.
                    queueFamilyIndexCount: (uint) queueFamilyIndices.Length, pQueueFamilyIndices: pQueueFamilyIndices
                );
                var allocator = _allocatorProvider.Allocator;
                var allocationCreateInfo = new AllocationCreateInfo
                    ((uint) createFlags, memoryUsage, (uint) properties, 0, 0, null, null);
                ulong bufferHandle = default;
                AllocationT* allocation = default;
                AllocationInfo allocationInfo = default;
                _vma.CreateBuffer(&allocator, &bufferCreateInfo, &allocationCreateInfo, &bufferHandle, &allocation, &allocationInfo).ThrowCode();
                var buffer = new Buffer(bufferHandle);
                return (buffer, *allocation, allocationInfo);
            }
        }

        public unsafe void FreeBuffer(Buffer buffer, AllocationT allocation)
        {
            var allocator = _allocatorProvider.Allocator;
            _vma.DestroyBuffer(&allocator, buffer.Handle, ref allocation);
        }
    }
}
