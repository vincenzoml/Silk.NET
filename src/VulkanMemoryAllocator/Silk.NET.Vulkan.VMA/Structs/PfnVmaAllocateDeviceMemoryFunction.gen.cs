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
    public unsafe readonly struct PfnVmaAllocateDeviceMemoryFunction : IDisposable
    {
        private readonly void* _handle;
        public delegate* unmanaged[Cdecl]<AllocatorT*, uint, ulong, ulong, void*, void> Handle => (delegate* unmanaged[Cdecl]<AllocatorT*, uint, ulong, ulong, void*, void>) _handle;
        public PfnVmaAllocateDeviceMemoryFunction
        (
            delegate* unmanaged[Cdecl]<AllocatorT*, uint, ulong, ulong, void*, void> ptr
        ) => _handle = ptr;

        public PfnVmaAllocateDeviceMemoryFunction
        (
             VmaAllocateDeviceMemoryFunction proc
        ) => _handle = (void*) SilkMarshal.DelegateToPtr(proc);

        public static PfnVmaAllocateDeviceMemoryFunction From(VmaAllocateDeviceMemoryFunction proc) => new PfnVmaAllocateDeviceMemoryFunction(proc);
        public void Dispose() => SilkMarshal.Free((IntPtr) _handle);

        public static implicit operator IntPtr(PfnVmaAllocateDeviceMemoryFunction pfn) => (IntPtr) pfn.Handle;
        public static explicit operator PfnVmaAllocateDeviceMemoryFunction(IntPtr pfn)
            => new PfnVmaAllocateDeviceMemoryFunction((delegate* unmanaged[Cdecl]<AllocatorT*, uint, ulong, ulong, void*, void>) pfn);

        public static implicit operator PfnVmaAllocateDeviceMemoryFunction(VmaAllocateDeviceMemoryFunction proc)
            => new PfnVmaAllocateDeviceMemoryFunction(proc);

        public static explicit operator VmaAllocateDeviceMemoryFunction(PfnVmaAllocateDeviceMemoryFunction pfn)
            => SilkMarshal.PtrToDelegate<VmaAllocateDeviceMemoryFunction>(pfn);

        public static implicit operator delegate* unmanaged[Cdecl]<AllocatorT*, uint, ulong, ulong, void*, void>(PfnVmaAllocateDeviceMemoryFunction pfn) => pfn.Handle;
        public static implicit operator PfnVmaAllocateDeviceMemoryFunction(delegate* unmanaged[Cdecl]<AllocatorT*, uint, ulong, ulong, void*, void> ptr) => new PfnVmaAllocateDeviceMemoryFunction(ptr);
    }

    public unsafe delegate void VmaAllocateDeviceMemoryFunction(AllocatorT* arg0, uint arg1, ulong arg2, ulong arg3, void* arg4);
}

