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
    [NativeName("Name", "VmaAllocationCreateInfo")]
    public unsafe partial struct AllocationCreateInfo
    {
        public AllocationCreateInfo
        (
            uint? flags = null,
            MemoryUsage? usage = null,
            uint? requiredFlags = null,
            uint? preferredFlags = null,
            uint? memoryTypeBits = null,
            PoolT* pool = null,
            void* pUserData = null
        ) : this()
        {
            if (flags is not null)
            {
                Flags = flags.Value;
            }

            if (usage is not null)
            {
                Usage = usage.Value;
            }

            if (requiredFlags is not null)
            {
                RequiredFlags = requiredFlags.Value;
            }

            if (preferredFlags is not null)
            {
                PreferredFlags = preferredFlags.Value;
            }

            if (memoryTypeBits is not null)
            {
                MemoryTypeBits = memoryTypeBits.Value;
            }

            if (pool is not null)
            {
                Pool = pool;
            }

            if (pUserData is not null)
            {
                PUserData = pUserData;
            }
        }


        [NativeName("Type", "VmaAllocationCreateFlags")]
        [NativeName("Type.Name", "VmaAllocationCreateFlags")]
        [NativeName("Name", "flags")]
        public uint Flags;

        [NativeName("Type", "VmaMemoryUsage")]
        [NativeName("Type.Name", "VmaMemoryUsage")]
        [NativeName("Name", "usage")]
        public MemoryUsage Usage;

        [NativeName("Type", "MemoryPropertyFlags")]
        [NativeName("Type.Name", "MemoryPropertyFlags")]
        [NativeName("Name", "requiredFlags")]
        public uint RequiredFlags;

        [NativeName("Type", "MemoryPropertyFlags")]
        [NativeName("Type.Name", "MemoryPropertyFlags")]
        [NativeName("Name", "preferredFlags")]
        public uint PreferredFlags;

        [NativeName("Type", "uint32_t")]
        [NativeName("Type.Name", "uint32_t")]
        [NativeName("Name", "memoryTypeBits")]
        public uint MemoryTypeBits;

        [NativeName("Type", "VmaPool _Nullable")]
        [NativeName("Type.Name", "VmaPool _Nullable")]
        [NativeName("Name", "pool")]
        public PoolT* Pool;

        [NativeName("Type", "void * _Nullable")]
        [NativeName("Type.Name", "void * _Nullable")]
        [NativeName("Name", "pUserData")]
        public void* PUserData;
    }
}
