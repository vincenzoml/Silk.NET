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
    [NativeName("Name", "VmaAllocationInfo")]
    public unsafe partial struct AllocationInfo
    {
        public AllocationInfo
        (
            uint? memoryType = null,
            ulong? deviceMemory = null,
            ulong? offset = null,
            ulong? size = null,
            void* pMappedData = null,
            void* pUserData = null
        ) : this()
        {
            if (memoryType is not null)
            {
                MemoryType = memoryType.Value;
            }

            if (deviceMemory is not null)
            {
                DeviceMemory = deviceMemory.Value;
            }

            if (offset is not null)
            {
                Offset = offset.Value;
            }

            if (size is not null)
            {
                Size = size.Value;
            }

            if (pMappedData is not null)
            {
                PMappedData = pMappedData;
            }

            if (pUserData is not null)
            {
                PUserData = pUserData;
            }
        }


        [NativeName("Type", "uint32_t")]
        [NativeName("Type.Name", "uint32_t")]
        [NativeName("Name", "memoryType")]
        public uint MemoryType;

        [NativeName("Type", "DeviceMemory")]
        [NativeName("Type.Name", "DeviceMemory")]
        [NativeName("Name", "deviceMemory")]
        public ulong DeviceMemory;

        [NativeName("Type", "DeviceSize")]
        [NativeName("Type.Name", "DeviceSize")]
        [NativeName("Name", "offset")]
        public ulong Offset;

        [NativeName("Type", "DeviceSize")]
        [NativeName("Type.Name", "DeviceSize")]
        [NativeName("Name", "size")]
        public ulong Size;

        [NativeName("Type", "void * _Nullable")]
        [NativeName("Type.Name", "void * _Nullable")]
        [NativeName("Name", "pMappedData")]
        public void* PMappedData;

        [NativeName("Type", "void * _Nullable")]
        [NativeName("Type.Name", "void * _Nullable")]
        [NativeName("Name", "pUserData")]
        public void* PUserData;
    }
}
