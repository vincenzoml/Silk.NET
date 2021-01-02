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
    [NativeName("Name", "VmaStats")]
    public unsafe partial struct Stats
    {
        public Stats
        (
            StatInfo? total = null
        ) : this()
        {
            if (total is not null)
            {
                Total = total.Value;
            }
        }

        
        [NativeName("Type", "VmaStatInfo [32]")]
        [NativeName("Type.Name", "VmaStatInfo [32]")]
        [NativeName("Name", "memoryType")]
        public MemoryTypeBuffer MemoryType;

        public struct MemoryTypeBuffer
        {
            public StatInfo Element0;
            public StatInfo Element1;
            public StatInfo Element2;
            public StatInfo Element3;
            public StatInfo Element4;
            public StatInfo Element5;
            public StatInfo Element6;
            public StatInfo Element7;
            public StatInfo Element8;
            public StatInfo Element9;
            public StatInfo Element10;
            public StatInfo Element11;
            public StatInfo Element12;
            public StatInfo Element13;
            public StatInfo Element14;
            public StatInfo Element15;
            public StatInfo Element16;
            public StatInfo Element17;
            public StatInfo Element18;
            public StatInfo Element19;
            public StatInfo Element20;
            public StatInfo Element21;
            public StatInfo Element22;
            public StatInfo Element23;
            public StatInfo Element24;
            public StatInfo Element25;
            public StatInfo Element26;
            public StatInfo Element27;
            public StatInfo Element28;
            public StatInfo Element29;
            public StatInfo Element30;
            public StatInfo Element31;
            public ref StatInfo this[int index]
            {
                get
                {
                    if (index > 31 || index < 0)
                    {
                        throw new ArgumentOutOfRangeException(nameof(index));
                    }

                    fixed (StatInfo* ptr = &Element0)
                    {
                        return ref ptr[index];
                    }
                }
            }

#if NETSTANDARD2_1
            public Span<StatInfo> AsSpan()
                => MemoryMarshal.CreateSpan(ref Element0, 32);
#endif
        }

        
        [NativeName("Type", "VmaStatInfo [16]")]
        [NativeName("Type.Name", "VmaStatInfo [16]")]
        [NativeName("Name", "memoryHeap")]
        public MemoryHeapBuffer MemoryHeap;

        public struct MemoryHeapBuffer
        {
            public StatInfo Element0;
            public StatInfo Element1;
            public StatInfo Element2;
            public StatInfo Element3;
            public StatInfo Element4;
            public StatInfo Element5;
            public StatInfo Element6;
            public StatInfo Element7;
            public StatInfo Element8;
            public StatInfo Element9;
            public StatInfo Element10;
            public StatInfo Element11;
            public StatInfo Element12;
            public StatInfo Element13;
            public StatInfo Element14;
            public StatInfo Element15;
            public ref StatInfo this[int index]
            {
                get
                {
                    if (index > 15 || index < 0)
                    {
                        throw new ArgumentOutOfRangeException(nameof(index));
                    }

                    fixed (StatInfo* ptr = &Element0)
                    {
                        return ref ptr[index];
                    }
                }
            }

#if NETSTANDARD2_1
            public Span<StatInfo> AsSpan()
                => MemoryMarshal.CreateSpan(ref Element0, 16);
#endif
        }


        [NativeName("Type", "VmaStatInfo")]
        [NativeName("Type.Name", "VmaStatInfo")]
        [NativeName("Name", "total")]
        public StatInfo Total;
    }
}
