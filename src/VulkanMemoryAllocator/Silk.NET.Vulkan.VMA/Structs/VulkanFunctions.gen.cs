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
    [NativeName("Name", "VmaVulkanFunctions")]
    public unsafe partial struct VulkanFunctions
    {
        public VulkanFunctions
        (
            PfnGetPhysicalDeviceProperties? getPhysicalDeviceProperties = null,
            PfnGetPhysicalDeviceMemoryProperties? getPhysicalDeviceMemoryProperties = null,
            PfnAllocateMemory? allocateMemory = null,
            PfnFreeMemory? freeMemory = null,
            PfnMapMemory? mapMemory = null,
            PfnUnmapMemory? unmapMemory = null,
            PfnFlushMappedMemoryRanges? flushMappedMemoryRanges = null,
            PfnFlushMappedMemoryRanges? invalidateMappedMemoryRanges = null,
            PfnBindBufferMemory? bindBufferMemory = null,
            PfnBindImageMemory? bindImageMemory = null,
            PfnGetBufferMemoryRequirements? getBufferMemoryRequirements = null,
            PfnGetImageMemoryRequirements? getImageMemoryRequirements = null,
            PfnCreateBuffer? createBuffer = null,
            PfnDestroyBuffer? destroyBuffer = null,
            PfnCreateImage? createImage = null,
            PfnDestroyImage? destroyImage = null,
            PfnCmdCopyBuffer? cmdCopyBuffer = null,
            PfnGetBufferMemoryRequirements2KHR? getBufferMemoryRequirements2KHR = null,
            PfnGetImageMemoryRequirements2KHR? getImageMemoryRequirements2KHR = null,
            PfnBindBufferMemory2KHR? bindBufferMemory2KHR = null,
            PfnBindImageMemory2KHR? bindImageMemory2KHR = null,
            PfnGetPhysicalDeviceMemoryProperties2KHR? getPhysicalDeviceMemoryProperties2KHR = null
        ) : this()
        {
            if (getPhysicalDeviceProperties is not null)
            {
                GetPhysicalDeviceProperties = getPhysicalDeviceProperties.Value;
            }

            if (getPhysicalDeviceMemoryProperties is not null)
            {
                GetPhysicalDeviceMemoryProperties = getPhysicalDeviceMemoryProperties.Value;
            }

            if (allocateMemory is not null)
            {
                AllocateMemory = allocateMemory.Value;
            }

            if (freeMemory is not null)
            {
                FreeMemory = freeMemory.Value;
            }

            if (mapMemory is not null)
            {
                MapMemory = mapMemory.Value;
            }

            if (unmapMemory is not null)
            {
                UnmapMemory = unmapMemory.Value;
            }

            if (flushMappedMemoryRanges is not null)
            {
                FlushMappedMemoryRanges = flushMappedMemoryRanges.Value;
            }

            if (invalidateMappedMemoryRanges is not null)
            {
                InvalidateMappedMemoryRanges = invalidateMappedMemoryRanges.Value;
            }

            if (bindBufferMemory is not null)
            {
                BindBufferMemory = bindBufferMemory.Value;
            }

            if (bindImageMemory is not null)
            {
                BindImageMemory = bindImageMemory.Value;
            }

            if (getBufferMemoryRequirements is not null)
            {
                GetBufferMemoryRequirements = getBufferMemoryRequirements.Value;
            }

            if (getImageMemoryRequirements is not null)
            {
                GetImageMemoryRequirements = getImageMemoryRequirements.Value;
            }

            if (createBuffer is not null)
            {
                CreateBuffer = createBuffer.Value;
            }

            if (destroyBuffer is not null)
            {
                DestroyBuffer = destroyBuffer.Value;
            }

            if (createImage is not null)
            {
                CreateImage = createImage.Value;
            }

            if (destroyImage is not null)
            {
                DestroyImage = destroyImage.Value;
            }

            if (cmdCopyBuffer is not null)
            {
                CmdCopyBuffer = cmdCopyBuffer.Value;
            }

            if (getBufferMemoryRequirements2KHR is not null)
            {
                GetBufferMemoryRequirements2KHR = getBufferMemoryRequirements2KHR.Value;
            }

            if (getImageMemoryRequirements2KHR is not null)
            {
                GetImageMemoryRequirements2KHR = getImageMemoryRequirements2KHR.Value;
            }

            if (bindBufferMemory2KHR is not null)
            {
                BindBufferMemory2KHR = bindBufferMemory2KHR.Value;
            }

            if (bindImageMemory2KHR is not null)
            {
                BindImageMemory2KHR = bindImageMemory2KHR.Value;
            }

            if (getPhysicalDeviceMemoryProperties2KHR is not null)
            {
                GetPhysicalDeviceMemoryProperties2KHR = getPhysicalDeviceMemoryProperties2KHR.Value;
            }
        }


        [NativeName("Type", "PFN_GetPhysicalDeviceProperties _Nullable")]
        [NativeName("Type.Name", "PFN_GetPhysicalDeviceProperties _Nullable")]
        [NativeName("Name", "GetPhysicalDeviceProperties")]
        public PfnGetPhysicalDeviceProperties GetPhysicalDeviceProperties;

        [NativeName("Type", "PFN_GetPhysicalDeviceMemoryProperties _Nullable")]
        [NativeName("Type.Name", "PFN_GetPhysicalDeviceMemoryProperties _Nullable")]
        [NativeName("Name", "GetPhysicalDeviceMemoryProperties")]
        public PfnGetPhysicalDeviceMemoryProperties GetPhysicalDeviceMemoryProperties;

        [NativeName("Type", "PFN_AllocateMemory _Nullable")]
        [NativeName("Type.Name", "PFN_AllocateMemory _Nullable")]
        [NativeName("Name", "AllocateMemory")]
        public PfnAllocateMemory AllocateMemory;

        [NativeName("Type", "PFN_FreeMemory _Nullable")]
        [NativeName("Type.Name", "PFN_FreeMemory _Nullable")]
        [NativeName("Name", "FreeMemory")]
        public PfnFreeMemory FreeMemory;

        [NativeName("Type", "PFN_MapMemory _Nullable")]
        [NativeName("Type.Name", "PFN_MapMemory _Nullable")]
        [NativeName("Name", "MapMemory")]
        public PfnMapMemory MapMemory;

        [NativeName("Type", "PFN_UnmapMemory _Nullable")]
        [NativeName("Type.Name", "PFN_UnmapMemory _Nullable")]
        [NativeName("Name", "UnmapMemory")]
        public PfnUnmapMemory UnmapMemory;

        [NativeName("Type", "PFN_FlushMappedMemoryRanges _Nullable")]
        [NativeName("Type.Name", "PFN_FlushMappedMemoryRanges _Nullable")]
        [NativeName("Name", "FlushMappedMemoryRanges")]
        public PfnFlushMappedMemoryRanges FlushMappedMemoryRanges;

        [NativeName("Type", "PFN_InvalidateMappedMemoryRanges _Nullable")]
        [NativeName("Type.Name", "PFN_InvalidateMappedMemoryRanges _Nullable")]
        [NativeName("Name", "InvalidateMappedMemoryRanges")]
        public PfnFlushMappedMemoryRanges InvalidateMappedMemoryRanges;

        [NativeName("Type", "PFN_BindBufferMemory _Nullable")]
        [NativeName("Type.Name", "PFN_BindBufferMemory _Nullable")]
        [NativeName("Name", "BindBufferMemory")]
        public PfnBindBufferMemory BindBufferMemory;

        [NativeName("Type", "PFN_BindImageMemory _Nullable")]
        [NativeName("Type.Name", "PFN_BindImageMemory _Nullable")]
        [NativeName("Name", "BindImageMemory")]
        public PfnBindImageMemory BindImageMemory;

        [NativeName("Type", "PFN_GetBufferMemoryRequirements _Nullable")]
        [NativeName("Type.Name", "PFN_GetBufferMemoryRequirements _Nullable")]
        [NativeName("Name", "GetBufferMemoryRequirements")]
        public PfnGetBufferMemoryRequirements GetBufferMemoryRequirements;

        [NativeName("Type", "PFN_GetImageMemoryRequirements _Nullable")]
        [NativeName("Type.Name", "PFN_GetImageMemoryRequirements _Nullable")]
        [NativeName("Name", "GetImageMemoryRequirements")]
        public PfnGetImageMemoryRequirements GetImageMemoryRequirements;

        [NativeName("Type", "PFN_CreateBuffer _Nullable")]
        [NativeName("Type.Name", "PFN_CreateBuffer _Nullable")]
        [NativeName("Name", "CreateBuffer")]
        public PfnCreateBuffer CreateBuffer;

        [NativeName("Type", "PFN_DestroyBuffer _Nullable")]
        [NativeName("Type.Name", "PFN_DestroyBuffer _Nullable")]
        [NativeName("Name", "DestroyBuffer")]
        public PfnDestroyBuffer DestroyBuffer;

        [NativeName("Type", "PFN_CreateImage _Nullable")]
        [NativeName("Type.Name", "PFN_CreateImage _Nullable")]
        [NativeName("Name", "CreateImage")]
        public PfnCreateImage CreateImage;

        [NativeName("Type", "PFN_DestroyImage _Nullable")]
        [NativeName("Type.Name", "PFN_DestroyImage _Nullable")]
        [NativeName("Name", "DestroyImage")]
        public PfnDestroyImage DestroyImage;

        [NativeName("Type", "PFN_CmdCopyBuffer _Nullable")]
        [NativeName("Type.Name", "PFN_CmdCopyBuffer _Nullable")]
        [NativeName("Name", "CmdCopyBuffer")]
        public PfnCmdCopyBuffer CmdCopyBuffer;

        [NativeName("Type", "PFN_GetBufferMemoryRequirements2KHR _Nullable")]
        [NativeName("Type.Name", "PFN_GetBufferMemoryRequirements2KHR _Nullable")]
        [NativeName("Name", "GetBufferMemoryRequirements2KHR")]
        public PfnGetBufferMemoryRequirements2KHR GetBufferMemoryRequirements2KHR;

        [NativeName("Type", "PFN_GetImageMemoryRequirements2KHR _Nullable")]
        [NativeName("Type.Name", "PFN_GetImageMemoryRequirements2KHR _Nullable")]
        [NativeName("Name", "GetImageMemoryRequirements2KHR")]
        public PfnGetImageMemoryRequirements2KHR GetImageMemoryRequirements2KHR;

        [NativeName("Type", "PFN_BindBufferMemory2KHR _Nullable")]
        [NativeName("Type.Name", "PFN_BindBufferMemory2KHR _Nullable")]
        [NativeName("Name", "BindBufferMemory2KHR")]
        public PfnBindBufferMemory2KHR BindBufferMemory2KHR;

        [NativeName("Type", "PFN_BindImageMemory2KHR _Nullable")]
        [NativeName("Type.Name", "PFN_BindImageMemory2KHR _Nullable")]
        [NativeName("Name", "BindImageMemory2KHR")]
        public PfnBindImageMemory2KHR BindImageMemory2KHR;

        [NativeName("Type", "PFN_GetPhysicalDeviceMemoryProperties2KHR _Nullable")]
        [NativeName("Type.Name", "PFN_GetPhysicalDeviceMemoryProperties2KHR _Nullable")]
        [NativeName("Name", "GetPhysicalDeviceMemoryProperties2KHR")]
        public PfnGetPhysicalDeviceMemoryProperties2KHR GetPhysicalDeviceMemoryProperties2KHR;
    }
}
