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
    public unsafe readonly struct PfnMapMemory : IDisposable
    {
        private readonly void* _handle;
        public delegate* unmanaged[Cdecl]<Device, DeviceMemory, ulong, ulong, uint, void**, Result> Handle => (delegate* unmanaged[Cdecl]<Device, DeviceMemory, ulong, ulong, uint, void**, Result>) _handle;
        public PfnMapMemory
        (
            delegate* unmanaged[Cdecl]<Device, DeviceMemory, ulong, ulong, uint, void**, Result> ptr
        ) => _handle = ptr;

        public PfnMapMemory
        (
             MapMemory proc
        ) => _handle = (void*) SilkMarshal.DelegateToPtr(proc);

        public static PfnMapMemory From(MapMemory proc) => new PfnMapMemory(proc);
        public void Dispose() => SilkMarshal.Free((IntPtr) _handle);

        public static implicit operator IntPtr(PfnMapMemory pfn) => (IntPtr) pfn.Handle;
        public static explicit operator PfnMapMemory(IntPtr pfn)
            => new PfnMapMemory((delegate* unmanaged[Cdecl]<Device, DeviceMemory, ulong, ulong, uint, void**, Result>) pfn);

        public static implicit operator PfnMapMemory(MapMemory proc)
            => new PfnMapMemory(proc);

        public static explicit operator MapMemory(PfnMapMemory pfn)
            => SilkMarshal.PtrToDelegate<MapMemory>(pfn);

        public static implicit operator delegate* unmanaged[Cdecl]<Device, DeviceMemory, ulong, ulong, uint, void**, Result>(PfnMapMemory pfn) => pfn.Handle;
        public static implicit operator PfnMapMemory(delegate* unmanaged[Cdecl]<Device, DeviceMemory, ulong, ulong, uint, void**, Result> ptr) => new PfnMapMemory(ptr);
    }

    public unsafe delegate Result MapMemory(Device arg0, DeviceMemory arg1, ulong arg2, ulong arg3, uint arg4, void** arg5);
}

