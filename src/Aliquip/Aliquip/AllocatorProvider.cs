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
    internal sealed class AllocatorProvider : IAllocatorProvider, IDisposable
    {
        private readonly Vma _vma;
        private readonly AllocatorT _allocator;

        public unsafe AllocatorT Allocator => _allocator;

        public unsafe AllocatorProvider
        (
            Vk vk,
            Vma vma,
            IPhysicalDeviceProvider physicalDeviceProvider,
            ILogicalDeviceProvider logicalDeviceProvider,
            IInstanceProvider instanceProvider
        )
        {
            _vma = vma;

            var physicalDevice = physicalDeviceProvider.Device;
            var logicalDevice = logicalDeviceProvider.LogicalDevice;
            var instance = instanceProvider.Instance;
            var vulkanFunctions = new VulkanFunctions(
                    getPhysicalDeviceProperties: PfnGetPhysicalDeviceProperties.From(
                        delegate(PhysicalDevice arg0, PhysicalDeviceProperties* properties)
                        {
                            vk.GetPhysicalDeviceProperties(arg0, properties);
                        }
                    ),
                    getPhysicalDeviceMemoryProperties: PfnGetPhysicalDeviceMemoryProperties.From(
                        delegate(PhysicalDevice arg0, PhysicalDeviceMemoryProperties* properties)
                        {
                            vk.GetPhysicalDeviceMemoryProperties(arg0, properties);
                        }
                    ),
                    allocateMemory: PfnAllocateMemory.From(
                        delegate
                            (Device arg0, MemoryAllocateInfo* info, AllocationCallbacks* callbacks, DeviceMemory* arg3)
                        {
                            return vk.AllocateMemory(arg0, info, callbacks, arg3);
                        }
                    ),
                    freeMemory: PfnFreeMemory.From(
                        delegate(Device arg0, DeviceMemory memory, AllocationCallbacks* callbacks)
                        {
                            vk.FreeMemory(arg0, memory, callbacks);
                        }
                    ),
                    mapMemory: PfnMapMemory.From(
                        delegate(Device arg0, DeviceMemory memory, ulong arg2, ulong arg3, uint u, void** arg5)
                        {
                            return vk.MapMemory(arg0, memory, arg2, arg3, u, arg5);
                        }
                    ),
                    unmapMemory: PfnUnmapMemory.From(
                        delegate(Device arg0, DeviceMemory memory) { vk.UnmapMemory(arg0, memory); }
                    ),
                    flushMappedMemoryRanges: PfnFlushMappedMemoryRanges.From(
                        delegate(Device arg0, uint u, MappedMemoryRange* range)
                        {
                            return vk.FlushMappedMemoryRanges(arg0, u, range);
                        }
                    ),
                    invalidateMappedMemoryRanges: PfnFlushMappedMemoryRanges.From(
                        delegate(Device arg0, uint u, MappedMemoryRange* range)
                        {
                            return vk.InvalidateMappedMemoryRanges(arg0, u, range);
                        }
                    ),
                    bindBufferMemory: PfnBindBufferMemory.From(
                        delegate(Device arg0, Buffer buffer, DeviceMemory memory, ulong arg3)
                        {
                            return vk.BindBufferMemory(arg0, buffer, memory, arg3);
                        }
                    ),
                    bindImageMemory: PfnBindImageMemory.From(
                        delegate(Device arg0, Image image, DeviceMemory memory, ulong arg3)
                        {
                            return vk.BindImageMemory(arg0, image, memory, arg3);
                        }
                    ),
                    getBufferMemoryRequirements: PfnGetBufferMemoryRequirements.From(
                        delegate(Device arg0, Buffer buffer, MemoryRequirements* requirements)
                        {
                            vk.GetBufferMemoryRequirements(arg0, buffer, requirements);
                        }
                    ),
                    getImageMemoryRequirements: PfnGetImageMemoryRequirements.From(
                        delegate(Device arg0, Image image, MemoryRequirements* requirements)
                        {
                            vk.GetImageMemoryRequirements(arg0, image, requirements);
                        }
                    ),
                    createBuffer: PfnCreateBuffer.From(
                        delegate(Device arg0, BufferCreateInfo* info, AllocationCallbacks* callbacks, Buffer* arg3)
                        {
                            return vk.CreateBuffer(arg0, info, callbacks, arg3);
                        }
                    ),
                    destroyBuffer: PfnDestroyBuffer.From(
                        delegate(Device arg0, Buffer buffer, AllocationCallbacks* callbacks)
                        {
                            vk.DestroyBuffer(arg0, buffer, callbacks);
                        }
                    ),
                    createImage: PfnCreateImage.From(
                        delegate(Device arg0, ImageCreateInfo* info, AllocationCallbacks* callbacks, Image* arg3)
                        {
                            return vk.CreateImage(arg0, info, callbacks, arg3);
                        }
                    ),
                    destroyImage: PfnDestroyImage.From(
                        delegate(Device arg0, Image image, AllocationCallbacks* callbacks)
                        {
                            vk.DestroyImage(arg0, image, callbacks);
                        }
                    ),
                    cmdCopyBuffer: PfnCmdCopyBuffer.From(
                        delegate(CommandBuffer arg0, Buffer buffer, Buffer buffer1, uint u, BufferCopy* arg4)
                        {
                            vk.CmdCopyBuffer(arg0, buffer, buffer1, u, arg4);
                        }
                    ),
                    getBufferMemoryRequirements2KHR: PfnGetBufferMemoryRequirements2KHR.From(
                        delegate(Device arg0, BufferMemoryRequirementsInfo2* info2, MemoryRequirements2* requirements2)
                        {
                            vk.GetBufferMemoryRequirements2(arg0, info2, requirements2);
                        }
                    ),
                    getImageMemoryRequirements2KHR: PfnGetImageMemoryRequirements2KHR.From(
                        delegate(Device arg0, ImageMemoryRequirementsInfo2* info2, MemoryRequirements2* requirements2)
                        {
                            vk.GetImageMemoryRequirements2(arg0, info2, requirements2);
                        }
                    ),
                    bindBufferMemory2KHR: PfnBindBufferMemory2KHR.From(
                        delegate(Device arg0, uint u, BindBufferMemoryInfo* info)
                        {
                            return vk.BindBufferMemory2(arg0, u, info);
                        }
                    ),
                    bindImageMemory2KHR: PfnBindImageMemory2KHR.From(
                        delegate(Device arg0, uint u, BindImageMemoryInfo* info)
                        {
                            return vk.BindImageMemory2(arg0, u, info);
                        }
                    ),
                    getPhysicalDeviceMemoryProperties2KHR: PfnGetPhysicalDeviceMemoryProperties2KHR.From(
                        delegate(PhysicalDevice arg0, PhysicalDeviceMemoryProperties2* properties2)
                        {
                            vk.GetPhysicalDeviceMemoryProperties2(arg0, properties2);
                        }
                    )
            );
            var createInfo = new AllocatorCreateInfo
            (
                0, physicalDevice, logicalDevice,
                instance: instance, vulkanApiVersion: Vk.Version12,
                pVulkanFunctions: &vulkanFunctions
            );
            fixed(AllocatorT* p = &_allocator)
            {
                var pAllocator = p;
                _vma.CreateAllocator(&createInfo, ref pAllocator);
            }
        }

        public unsafe void Dispose()
        {
            var allocatorT = _allocator;
            _vma.DestroyAllocator(ref allocatorT);
        }
    }
}
