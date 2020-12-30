// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using Silk.NET.Vulkan;
using Buffer = Silk.NET.Vulkan.Buffer;

namespace Aliquip
{
    internal sealed class BufferFactory : IBufferFactory
    {
        private readonly Vk _vk;
        private readonly ILogicalDeviceProvider _logicalDeviceProvider;
        private readonly IPhysicalDeviceProvider _physicalDeviceProvider;

        public BufferFactory(Vk vk, ILogicalDeviceProvider logicalDeviceProvider, IPhysicalDeviceProvider physicalDeviceProvider)
        {
            _vk = vk;
            _logicalDeviceProvider = logicalDeviceProvider;
            _physicalDeviceProvider = physicalDeviceProvider;
        }
        
        public unsafe (Buffer, DeviceMemory) CreateBuffer(ulong size, BufferUsageFlags usage, MemoryPropertyFlags properties, Span<uint> queueFamilyIndices)
        {
            Buffer buffer;
            fixed (uint* pQueueFamilyIndices = queueFamilyIndices)
            {
                var bufferInfo = new BufferCreateInfo
                (
                    size: size, usage: usage,
                    sharingMode: queueFamilyIndices.Length > 1 ? SharingMode.Concurrent : SharingMode.Exclusive, // TODO: Use barriers to transfer ownership instead.
                    queueFamilyIndexCount: (uint) queueFamilyIndices.Length, pQueueFamilyIndices: pQueueFamilyIndices
                );
                _vk.CreateBuffer(_logicalDeviceProvider.LogicalDevice, bufferInfo, null, out buffer).ThrowCode();
            }

            _vk.GetBufferMemoryRequirements
                (_logicalDeviceProvider.LogicalDevice, buffer, out var memoryRequirements);
            
            uint FindMemoryType(uint typeFilter, MemoryPropertyFlags properties)
            {
                _vk.GetPhysicalDeviceMemoryProperties(_physicalDeviceProvider.Device, out var memoryProperties);

                for (int i = 0; i < memoryProperties.MemoryTypeCount; i++)
                {
                    if ((typeFilter & (1 << i)) != 0 && ((memoryProperties.MemoryTypes[i].PropertyFlags & properties) == properties))
                        return (uint)i;
                }

                throw new Exception("Cannot find suitable Memory Type");
            }
            
            var allocInfo = new MemoryAllocateInfo(allocationSize: memoryRequirements.Size, memoryTypeIndex: FindMemoryType(memoryRequirements.MemoryTypeBits, properties));
            _vk.AllocateMemory(_logicalDeviceProvider.LogicalDevice, allocInfo, null, out var memory);
            _vk.BindBufferMemory(_logicalDeviceProvider.LogicalDevice, buffer, memory, 0);

            return (buffer, memory);
        }
    }
}
