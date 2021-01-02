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
    public unsafe readonly struct PfnBindBufferMemory : IDisposable
    {
        private readonly void* _handle;
        public delegate* unmanaged[Cdecl]<Device, Buffer, DeviceMemory, ulong, Result> Handle => (delegate* unmanaged[Cdecl]<Device, Buffer, DeviceMemory, ulong, Result>) _handle;
        public PfnBindBufferMemory
        (
            delegate* unmanaged[Cdecl]<Device, Buffer, DeviceMemory, ulong, Result> ptr
        ) => _handle = ptr;

        public PfnBindBufferMemory
        (
            BindBufferMemory proc
        ) => _handle = (void*) SilkMarshal.DelegateToPtr(proc);

        public static PfnBindBufferMemory From(BindBufferMemory proc) => new PfnBindBufferMemory(proc);
        public void Dispose() => SilkMarshal.Free((IntPtr) _handle);

        public static implicit operator IntPtr(PfnBindBufferMemory pfn) => (IntPtr) pfn.Handle;
        public static explicit operator PfnBindBufferMemory(IntPtr pfn)
            => new PfnBindBufferMemory((delegate* unmanaged[Cdecl]<Device, Buffer, DeviceMemory, ulong, Result>) pfn);

        public static implicit operator PfnBindBufferMemory(BindBufferMemory proc)
            => new PfnBindBufferMemory(proc);

        public static explicit operator BindBufferMemory(PfnBindBufferMemory pfn)
            => SilkMarshal.PtrToDelegate<BindBufferMemory>(pfn);

        public static implicit operator delegate* unmanaged[Cdecl]<Device, Buffer, DeviceMemory, ulong, Result>(PfnBindBufferMemory pfn) => pfn.Handle;
        public static implicit operator PfnBindBufferMemory(delegate* unmanaged[Cdecl]<Device, Buffer, DeviceMemory, ulong, Result> ptr) => new PfnBindBufferMemory(ptr);
    }

    public unsafe delegate Result BindBufferMemory(Device arg0, Buffer arg1, DeviceMemory arg2, ulong arg3);
    
    public unsafe readonly struct PfnBindImageMemory : IDisposable
    {
        private readonly void* _handle;
        public delegate* unmanaged[Cdecl]<Device, Image, DeviceMemory, ulong, Result> Handle => (delegate* unmanaged[Cdecl]<Device, Image, DeviceMemory, ulong, Result>) _handle;
        public PfnBindImageMemory
        (
            delegate* unmanaged[Cdecl]<Device, Image, DeviceMemory, ulong, Result> ptr
        ) => _handle = ptr;

        public PfnBindImageMemory
        (
            BindImageMemory proc
        ) => _handle = (void*) SilkMarshal.DelegateToPtr(proc);

        public static PfnBindImageMemory From(BindImageMemory proc) => new PfnBindImageMemory(proc);
        public void Dispose() => SilkMarshal.Free((IntPtr) _handle);

        public static implicit operator IntPtr(PfnBindImageMemory pfn) => (IntPtr) pfn.Handle;
        public static explicit operator PfnBindImageMemory(IntPtr pfn)
            => new PfnBindImageMemory((delegate* unmanaged[Cdecl]<Device, Image, DeviceMemory, ulong, Result>) pfn);

        public static implicit operator PfnBindImageMemory(BindImageMemory proc)
            => new PfnBindImageMemory(proc);

        public static explicit operator BindImageMemory(PfnBindImageMemory pfn)
            => SilkMarshal.PtrToDelegate<BindImageMemory>(pfn);

        public static implicit operator delegate* unmanaged[Cdecl]<Device, Image, DeviceMemory, ulong, Result>(PfnBindImageMemory pfn) => pfn.Handle;
        public static implicit operator PfnBindImageMemory(delegate* unmanaged[Cdecl]<Device, Image, DeviceMemory, ulong, Result> ptr) => new PfnBindImageMemory(ptr);
    }

    public unsafe delegate Result BindImageMemory(Device arg0, Image arg1, DeviceMemory arg2, ulong arg3);
}

