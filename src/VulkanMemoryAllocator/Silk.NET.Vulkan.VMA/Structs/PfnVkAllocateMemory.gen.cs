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
    public unsafe readonly struct PfnAllocateMemory : IDisposable
    {
        private readonly void* _handle;
        public delegate* unmanaged[Cdecl]<Device*, MemoryAllocateInfo*, AllocationCallbacks*, ulong*, Result> Handle => (delegate* unmanaged[Cdecl]<Device*, MemoryAllocateInfo*, AllocationCallbacks*, ulong*, Result>) _handle;
        public PfnAllocateMemory
        (
            delegate* unmanaged[Cdecl]<Device*, MemoryAllocateInfo*, AllocationCallbacks*, ulong*, Result> ptr
        ) => _handle = ptr;

        public PfnAllocateMemory
        (
             AllocateMemory proc
        ) => _handle = (void*) SilkMarshal.DelegateToPtr(proc);

        public static PfnAllocateMemory From(AllocateMemory proc) => new PfnAllocateMemory(proc);
        public void Dispose() => SilkMarshal.Free((IntPtr) _handle);

        public static implicit operator IntPtr(PfnAllocateMemory pfn) => (IntPtr) pfn.Handle;
        public static explicit operator PfnAllocateMemory(IntPtr pfn)
            => new PfnAllocateMemory((delegate* unmanaged[Cdecl]<Device*, MemoryAllocateInfo*, AllocationCallbacks*, ulong*, Result>) pfn);

        public static implicit operator PfnAllocateMemory(AllocateMemory proc)
            => new PfnAllocateMemory(proc);

        public static explicit operator AllocateMemory(PfnAllocateMemory pfn)
            => SilkMarshal.PtrToDelegate<AllocateMemory>(pfn);

        public static implicit operator delegate* unmanaged[Cdecl]<Device*, MemoryAllocateInfo*, AllocationCallbacks*, ulong*, Result>(PfnAllocateMemory pfn) => pfn.Handle;
        public static implicit operator PfnAllocateMemory(delegate* unmanaged[Cdecl]<Device*, MemoryAllocateInfo*, AllocationCallbacks*, ulong*, Result> ptr) => new PfnAllocateMemory(ptr);
    }

    public unsafe delegate Result AllocateMemory(Device* arg0, MemoryAllocateInfo* arg1, AllocationCallbacks* arg2, ulong* arg3);
}

