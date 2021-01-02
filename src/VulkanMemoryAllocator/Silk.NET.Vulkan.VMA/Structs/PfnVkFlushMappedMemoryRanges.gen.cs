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
    public unsafe readonly struct PfnFlushMappedMemoryRanges : IDisposable
    {
        private readonly void* _handle;
        public delegate* unmanaged[Cdecl]<Device, uint, MappedMemoryRange*, Result> Handle => (delegate* unmanaged[Cdecl]<Device, uint, MappedMemoryRange*, Result>) _handle;
        public PfnFlushMappedMemoryRanges
        (
            delegate* unmanaged[Cdecl]<Device, uint, MappedMemoryRange*, Result> ptr
        ) => _handle = ptr;

        public PfnFlushMappedMemoryRanges
        (
             FlushMappedMemoryRanges proc
        ) => _handle = (void*) SilkMarshal.DelegateToPtr(proc);

        public static PfnFlushMappedMemoryRanges From(FlushMappedMemoryRanges proc) => new PfnFlushMappedMemoryRanges(proc);
        public void Dispose() => SilkMarshal.Free((IntPtr) _handle);

        public static implicit operator IntPtr(PfnFlushMappedMemoryRanges pfn) => (IntPtr) pfn.Handle;
        public static explicit operator PfnFlushMappedMemoryRanges(IntPtr pfn)
            => new PfnFlushMappedMemoryRanges((delegate* unmanaged[Cdecl]<Device, uint, MappedMemoryRange*, Result>) pfn);

        public static implicit operator PfnFlushMappedMemoryRanges(FlushMappedMemoryRanges proc)
            => new PfnFlushMappedMemoryRanges(proc);

        public static explicit operator FlushMappedMemoryRanges(PfnFlushMappedMemoryRanges pfn)
            => SilkMarshal.PtrToDelegate<FlushMappedMemoryRanges>(pfn);

        public static implicit operator delegate* unmanaged[Cdecl]<Device, uint, MappedMemoryRange*, Result>(PfnFlushMappedMemoryRanges pfn) => pfn.Handle;
        public static implicit operator PfnFlushMappedMemoryRanges(delegate* unmanaged[Cdecl]<Device, uint, MappedMemoryRange*, Result> ptr) => new PfnFlushMappedMemoryRanges(ptr);
    }

    public unsafe delegate Result FlushMappedMemoryRanges(Device arg0, uint arg1, MappedMemoryRange* arg2);
}

