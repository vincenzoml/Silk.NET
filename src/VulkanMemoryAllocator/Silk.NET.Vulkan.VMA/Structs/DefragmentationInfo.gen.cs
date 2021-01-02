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
    [NativeName("Name", "VmaDefragmentationInfo")]
    public unsafe partial struct DefragmentationInfo
    {
        public DefragmentationInfo
        (
            ulong? maxBytesToMove = null,
            uint? maxAllocationsToMove = null
        ) : this()
        {
            if (maxBytesToMove is not null)
            {
                MaxBytesToMove = maxBytesToMove.Value;
            }

            if (maxAllocationsToMove is not null)
            {
                MaxAllocationsToMove = maxAllocationsToMove.Value;
            }
        }


        [NativeName("Type", "DeviceSize")]
        [NativeName("Type.Name", "DeviceSize")]
        [NativeName("Name", "maxBytesToMove")]
        public ulong MaxBytesToMove;

        [NativeName("Type", "uint32_t")]
        [NativeName("Type.Name", "uint32_t")]
        [NativeName("Name", "maxAllocationsToMove")]
        public uint MaxAllocationsToMove;
    }
}
