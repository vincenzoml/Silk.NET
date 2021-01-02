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
    public unsafe readonly struct PfnUnmapMemory : IDisposable
    {
        private readonly void* _handle;
        public delegate* unmanaged[Cdecl]<Device*, ulong, void> Handle => (delegate* unmanaged[Cdecl]<Device*, ulong, void>) _handle;
        public PfnUnmapMemory
        (
            delegate* unmanaged[Cdecl]<Device*, ulong, void> ptr
        ) => _handle = ptr;

        public PfnUnmapMemory
        (
             UnmapMemory proc
        ) => _handle = (void*) SilkMarshal.DelegateToPtr(proc);

        public static PfnUnmapMemory From(UnmapMemory proc) => new PfnUnmapMemory(proc);
        public void Dispose() => SilkMarshal.Free((IntPtr) _handle);

        public static implicit operator IntPtr(PfnUnmapMemory pfn) => (IntPtr) pfn.Handle;
        public static explicit operator PfnUnmapMemory(IntPtr pfn)
            => new PfnUnmapMemory((delegate* unmanaged[Cdecl]<Device*, ulong, void>) pfn);

        public static implicit operator PfnUnmapMemory(UnmapMemory proc)
            => new PfnUnmapMemory(proc);

        public static explicit operator UnmapMemory(PfnUnmapMemory pfn)
            => SilkMarshal.PtrToDelegate<UnmapMemory>(pfn);

        public static implicit operator delegate* unmanaged[Cdecl]<Device*, ulong, void>(PfnUnmapMemory pfn) => pfn.Handle;
        public static implicit operator PfnUnmapMemory(delegate* unmanaged[Cdecl]<Device*, ulong, void> ptr) => new PfnUnmapMemory(ptr);
    }

    public unsafe delegate void UnmapMemory(Device* arg0, ulong arg1);
}

