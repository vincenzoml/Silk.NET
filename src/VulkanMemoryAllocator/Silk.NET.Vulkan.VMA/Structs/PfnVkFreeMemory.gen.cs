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
    public unsafe readonly struct PfnFreeMemory : IDisposable
    {
        private readonly void* _handle;
        public delegate* unmanaged[Cdecl]<Device*, ulong, AllocationCallbacks*, void> Handle => (delegate* unmanaged[Cdecl]<Device*, ulong, AllocationCallbacks*, void>) _handle;
        public PfnFreeMemory
        (
            delegate* unmanaged[Cdecl]<Device*, ulong, AllocationCallbacks*, void> ptr
        ) => _handle = ptr;

        public PfnFreeMemory
        (
             FreeMemory proc
        ) => _handle = (void*) SilkMarshal.DelegateToPtr(proc);

        public static PfnFreeMemory From(FreeMemory proc) => new PfnFreeMemory(proc);
        public void Dispose() => SilkMarshal.Free((IntPtr) _handle);

        public static implicit operator IntPtr(PfnFreeMemory pfn) => (IntPtr) pfn.Handle;
        public static explicit operator PfnFreeMemory(IntPtr pfn)
            => new PfnFreeMemory((delegate* unmanaged[Cdecl]<Device*, ulong, AllocationCallbacks*, void>) pfn);

        public static implicit operator PfnFreeMemory(FreeMemory proc)
            => new PfnFreeMemory(proc);

        public static explicit operator FreeMemory(PfnFreeMemory pfn)
            => SilkMarshal.PtrToDelegate<FreeMemory>(pfn);

        public static implicit operator delegate* unmanaged[Cdecl]<Device*, ulong, AllocationCallbacks*, void>(PfnFreeMemory pfn) => pfn.Handle;
        public static implicit operator PfnFreeMemory(delegate* unmanaged[Cdecl]<Device*, ulong, AllocationCallbacks*, void> ptr) => new PfnFreeMemory(ptr);
    }

    public unsafe delegate void FreeMemory(Device* arg0, ulong arg1, AllocationCallbacks* arg2);
}

