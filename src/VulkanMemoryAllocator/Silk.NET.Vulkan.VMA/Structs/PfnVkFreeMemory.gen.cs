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
        public delegate* unmanaged[Cdecl]<Device, DeviceMemory, AllocationCallbacks*, void> Handle => (delegate* unmanaged[Cdecl]<Device, DeviceMemory, AllocationCallbacks*, void>) _handle;
        public PfnFreeMemory
        (
            delegate* unmanaged[Cdecl]<Device, DeviceMemory, AllocationCallbacks*, void> ptr
        ) => _handle = ptr;

        public PfnFreeMemory
        (
             FreeMemory proc
        ) => _handle = (void*) SilkMarshal.DelegateToPtr(proc);

        public static PfnFreeMemory From(FreeMemory proc) => new PfnFreeMemory(proc);
        public void Dispose() => SilkMarshal.Free((IntPtr) _handle);

        public static implicit operator IntPtr(PfnFreeMemory pfn) => (IntPtr) pfn.Handle;
        public static explicit operator PfnFreeMemory(IntPtr pfn)
            => new PfnFreeMemory((delegate* unmanaged[Cdecl]<Device, DeviceMemory, AllocationCallbacks*, void>) pfn);

        public static implicit operator PfnFreeMemory(FreeMemory proc)
            => new PfnFreeMemory(proc);

        public static explicit operator FreeMemory(PfnFreeMemory pfn)
            => SilkMarshal.PtrToDelegate<FreeMemory>(pfn);

        public static implicit operator delegate* unmanaged[Cdecl]<Device, DeviceMemory, AllocationCallbacks*, void>(PfnFreeMemory pfn) => pfn.Handle;
        public static implicit operator PfnFreeMemory(delegate* unmanaged[Cdecl]<Device, DeviceMemory, AllocationCallbacks*, void> ptr) => new PfnFreeMemory(ptr);
    }

    public unsafe delegate void FreeMemory(Device arg0, DeviceMemory arg1, AllocationCallbacks* arg2);
    
    public unsafe readonly struct PfnDestroyBuffer : IDisposable
    {
        private readonly void* _handle;
        public delegate* unmanaged[Cdecl]<Device, Buffer, AllocationCallbacks*, void> Handle => (delegate* unmanaged[Cdecl]<Device, Buffer, AllocationCallbacks*, void>) _handle;
        public PfnDestroyBuffer
        (
            delegate* unmanaged[Cdecl]<Device, Buffer, AllocationCallbacks*, void> ptr
        ) => _handle = ptr;

        public PfnDestroyBuffer
        (
            DestroyBuffer proc
        ) => _handle = (void*) SilkMarshal.DelegateToPtr(proc);

        public static PfnDestroyBuffer From(DestroyBuffer proc) => new PfnDestroyBuffer(proc);
        public void Dispose() => SilkMarshal.Free((IntPtr) _handle);

        public static implicit operator IntPtr(PfnDestroyBuffer pfn) => (IntPtr) pfn.Handle;
        public static explicit operator PfnDestroyBuffer(IntPtr pfn)
            => new PfnDestroyBuffer((delegate* unmanaged[Cdecl]<Device, Buffer, AllocationCallbacks*, void>) pfn);

        public static implicit operator PfnDestroyBuffer(DestroyBuffer proc)
            => new PfnDestroyBuffer(proc);

        public static explicit operator DestroyBuffer(PfnDestroyBuffer pfn)
            => SilkMarshal.PtrToDelegate<DestroyBuffer>(pfn);

        public static implicit operator delegate* unmanaged[Cdecl]<Device, Buffer, AllocationCallbacks*, void>(PfnDestroyBuffer pfn) => pfn.Handle;
        public static implicit operator PfnDestroyBuffer(delegate* unmanaged[Cdecl]<Device, Buffer, AllocationCallbacks*, void> ptr) => new PfnDestroyBuffer(ptr);
    }

    public unsafe delegate void DestroyBuffer(Device arg0, Buffer arg1, AllocationCallbacks* arg2);
    
    public unsafe readonly struct PfnDestroyImage : IDisposable
    {
        private readonly void* _handle;
        public delegate* unmanaged[Cdecl]<Device, Image, AllocationCallbacks*, void> Handle => (delegate* unmanaged[Cdecl]<Device, Image, AllocationCallbacks*, void>) _handle;
        public PfnDestroyImage
        (
            delegate* unmanaged[Cdecl]<Device, Image, AllocationCallbacks*, void> ptr
        ) => _handle = ptr;

        public PfnDestroyImage
        (
            DestroyImage proc
        ) => _handle = (void*) SilkMarshal.DelegateToPtr(proc);

        public static PfnDestroyImage From(DestroyImage proc) => new PfnDestroyImage(proc);
        public void Dispose() => SilkMarshal.Free((IntPtr) _handle);

        public static implicit operator IntPtr(PfnDestroyImage pfn) => (IntPtr) pfn.Handle;
        public static explicit operator PfnDestroyImage(IntPtr pfn)
            => new PfnDestroyImage((delegate* unmanaged[Cdecl]<Device, Image, AllocationCallbacks*, void>) pfn);

        public static implicit operator PfnDestroyImage(DestroyImage proc)
            => new PfnDestroyImage(proc);

        public static explicit operator DestroyImage(PfnDestroyImage pfn)
            => SilkMarshal.PtrToDelegate<DestroyImage>(pfn);

        public static implicit operator delegate* unmanaged[Cdecl]<Device, Image, AllocationCallbacks*, void>(PfnDestroyImage pfn) => pfn.Handle;
        public static implicit operator PfnDestroyImage(delegate* unmanaged[Cdecl]<Device, Image, AllocationCallbacks*, void> ptr) => new PfnDestroyImage(ptr);
    }

    public unsafe delegate void DestroyImage(Device arg0, Image arg1, AllocationCallbacks* arg2);
}

