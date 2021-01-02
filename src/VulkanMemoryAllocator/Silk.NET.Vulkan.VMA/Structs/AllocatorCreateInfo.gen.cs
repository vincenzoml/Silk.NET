// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.


using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Text;
using Silk.NET.Core;
using Silk.NET.Core.Native;
using Silk.NET.Core.Attributes;
using Silk.NET.Core.Contexts;
using Silk.NET.Core.Loader;

#pragma warning disable 1591

namespace Silk.NET.Vulkan.VMA
{
    [NativeName("Name", "VmaAllocatorCreateInfo")]
    public unsafe partial struct AllocatorCreateInfo
    {
        public AllocatorCreateInfo
        (
            uint? flags = null,
            PhysicalDevice* physicalDevice = null,
            Device* device = null,
            ulong? preferredLargeHeapBlockSize = null,
            AllocationCallbacks* pAllocationCallbacks = null,
            DeviceMemoryCallbacks* pDeviceMemoryCallbacks = null,
            uint? frameInUseCount = null,
            ulong* pHeapSizeLimit = null,
            VulkanFunctions* pVulkanFunctions = null,
            RecordSettings* pRecordSettings = null,
            Instance* instance = null,
            uint? vulkanApiVersion = null
        ) : this()
        {
            if (flags is not null)
            {
                Flags = flags.Value;
            }

            if (physicalDevice is not null)
            {
                PhysicalDevice = physicalDevice;
            }

            if (device is not null)
            {
                Device = device;
            }

            if (preferredLargeHeapBlockSize is not null)
            {
                PreferredLargeHeapBlockSize = preferredLargeHeapBlockSize.Value;
            }

            if (pAllocationCallbacks is not null)
            {
                PAllocationCallbacks = pAllocationCallbacks;
            }

            if (pDeviceMemoryCallbacks is not null)
            {
                PDeviceMemoryCallbacks = pDeviceMemoryCallbacks;
            }

            if (frameInUseCount is not null)
            {
                FrameInUseCount = frameInUseCount.Value;
            }

            if (pHeapSizeLimit is not null)
            {
                PHeapSizeLimit = pHeapSizeLimit;
            }

            if (pVulkanFunctions is not null)
            {
                PVulkanFunctions = pVulkanFunctions;
            }

            if (pRecordSettings is not null)
            {
                PRecordSettings = pRecordSettings;
            }

            if (instance is not null)
            {
                Instance = instance;
            }

            if (vulkanApiVersion is not null)
            {
                VulkanApiVersion = vulkanApiVersion.Value;
            }
        }


        [NativeName("Type", "VmaAllocatorCreateFlags")]
        [NativeName("Type.Name", "VmaAllocatorCreateFlags")]
        [NativeName("Name", "flags")]
        public uint Flags;

        [NativeName("Type", "PhysicalDevice _Nonnull")]
        [NativeName("Type.Name", "PhysicalDevice _Nonnull")]
        [NativeName("Name", "physicalDevice")]
        public PhysicalDevice* PhysicalDevice;

        [NativeName("Type", "Device _Nonnull")]
        [NativeName("Type.Name", "Device _Nonnull")]
        [NativeName("Name", "device")]
        public Device* Device;

        [NativeName("Type", "DeviceSize")]
        [NativeName("Type.Name", "DeviceSize")]
        [NativeName("Name", "preferredLargeHeapBlockSize")]
        public ulong PreferredLargeHeapBlockSize;

        [NativeName("Type", "const AllocationCallbacks * _Nullable")]
        [NativeName("Type.Name", "const AllocationCallbacks * _Nullable")]
        [NativeName("Name", "pAllocationCallbacks")]
        public AllocationCallbacks* PAllocationCallbacks;

        [NativeName("Type", "const VmaDeviceMemoryCallbacks * _Nullable")]
        [NativeName("Type.Name", "const VmaDeviceMemoryCallbacks * _Nullable")]
        [NativeName("Name", "pDeviceMemoryCallbacks")]
        public DeviceMemoryCallbacks* PDeviceMemoryCallbacks;

        [NativeName("Type", "uint32_t")]
        [NativeName("Type.Name", "uint32_t")]
        [NativeName("Name", "frameInUseCount")]
        public uint FrameInUseCount;

        [NativeName("Type", "const DeviceSize * _Nullable")]
        [NativeName("Type.Name", "const DeviceSize * _Nullable")]
        [NativeName("Name", "pHeapSizeLimit")]
        public ulong* PHeapSizeLimit;

        [NativeName("Type", "const VmaVulkanFunctions * _Nullable")]
        [NativeName("Type.Name", "const VmaVulkanFunctions * _Nullable")]
        [NativeName("Name", "pVulkanFunctions")]
        public VulkanFunctions* PVulkanFunctions;

        [NativeName("Type", "const VmaRecordSettings * _Nullable")]
        [NativeName("Type.Name", "const VmaRecordSettings * _Nullable")]
        [NativeName("Name", "pRecordSettings")]
        public RecordSettings* PRecordSettings;

        [NativeName("Type", "Instance _Nonnull")]
        [NativeName("Type.Name", "Instance _Nonnull")]
        [NativeName("Name", "instance")]
        public Instance* Instance;

        [NativeName("Type", "uint32_t")]
        [NativeName("Type.Name", "uint32_t")]
        [NativeName("Name", "vulkanApiVersion")]
        public uint VulkanApiVersion;
    }
}
