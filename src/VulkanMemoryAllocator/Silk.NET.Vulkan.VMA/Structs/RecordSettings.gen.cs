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
    [NativeName("Name", "VmaRecordSettings")]
    public unsafe partial struct RecordSettings
    {
        public RecordSettings
        (
            uint? flags = null,
            byte* pFilePath = null
        ) : this()
        {
            if (flags is not null)
            {
                Flags = flags.Value;
            }

            if (pFilePath is not null)
            {
                PFilePath = pFilePath;
            }
        }


        [NativeName("Type", "VmaRecordFlags")]
        [NativeName("Type.Name", "VmaRecordFlags")]
        [NativeName("Name", "flags")]
        public uint Flags;

        [NativeName("Type", "const char * _Nonnull")]
        [NativeName("Type.Name", "const char * _Nonnull")]
        [NativeName("Name", "pFilePath")]
        public byte* PFilePath;
    }
}
