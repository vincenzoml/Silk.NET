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
    [NativeName("Name", "VmaDeviceMemoryCallbacks")]
    public unsafe partial struct DeviceMemoryCallbacks
    {
        public DeviceMemoryCallbacks
        (
            PfnVmaAllocateDeviceMemoryFunction? pfnAllocate = null,
            PfnVmaAllocateDeviceMemoryFunction? pfnFree = null,
            void* pUserData = null
        ) : this()
        {
            if (pfnAllocate is not null)
            {
                PfnAllocate = pfnAllocate.Value;
            }

            if (pfnFree is not null)
            {
                PfnFree = pfnFree.Value;
            }

            if (pUserData is not null)
            {
                PUserData = pUserData;
            }
        }


        [NativeName("Type", "PFN_vmaAllocateDeviceMemoryFunction _Nullable")]
        [NativeName("Type.Name", "PFN_vmaAllocateDeviceMemoryFunction _Nullable")]
        [NativeName("Name", "pfnAllocate")]
        public PfnVmaAllocateDeviceMemoryFunction PfnAllocate;

        [NativeName("Type", "PFN_vmaFreeDeviceMemoryFunction _Nullable")]
        [NativeName("Type.Name", "PFN_vmaFreeDeviceMemoryFunction _Nullable")]
        [NativeName("Name", "pfnFree")]
        public PfnVmaAllocateDeviceMemoryFunction PfnFree;

        [NativeName("Type", "void * _Nullable")]
        [NativeName("Type.Name", "void * _Nullable")]
        [NativeName("Name", "pUserData")]
        public void* PUserData;
    }
}
