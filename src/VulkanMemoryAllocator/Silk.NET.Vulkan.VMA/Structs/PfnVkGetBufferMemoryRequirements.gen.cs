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
    public unsafe readonly struct PfnGetBufferMemoryRequirements : IDisposable
    {
        private readonly void* _handle;
        public delegate* unmanaged[Cdecl]<Device, Buffer, MemoryRequirements*, void> Handle => (delegate* unmanaged[Cdecl]<Device, Buffer, MemoryRequirements*, void>) _handle;
        public PfnGetBufferMemoryRequirements
        (
            delegate* unmanaged[Cdecl]<Device, Buffer, MemoryRequirements*, void> ptr
        ) => _handle = ptr;

        public PfnGetBufferMemoryRequirements
        (
             GetBufferMemoryRequirements proc
        ) => _handle = (void*) SilkMarshal.DelegateToPtr(proc);

        public static PfnGetBufferMemoryRequirements From(GetBufferMemoryRequirements proc) => new PfnGetBufferMemoryRequirements(proc);
        public void Dispose() => SilkMarshal.Free((IntPtr) _handle);

        public static implicit operator IntPtr(PfnGetBufferMemoryRequirements pfn) => (IntPtr) pfn.Handle;
        public static explicit operator PfnGetBufferMemoryRequirements(IntPtr pfn)
            => new PfnGetBufferMemoryRequirements((delegate* unmanaged[Cdecl]<Device, Buffer, MemoryRequirements*, void>) pfn);

        public static implicit operator PfnGetBufferMemoryRequirements(GetBufferMemoryRequirements proc)
            => new PfnGetBufferMemoryRequirements(proc);

        public static explicit operator GetBufferMemoryRequirements(PfnGetBufferMemoryRequirements pfn)
            => SilkMarshal.PtrToDelegate<GetBufferMemoryRequirements>(pfn);

        public static implicit operator delegate* unmanaged[Cdecl]<Device, Buffer, MemoryRequirements*, void>(PfnGetBufferMemoryRequirements pfn) => pfn.Handle;
        public static implicit operator PfnGetBufferMemoryRequirements(delegate* unmanaged[Cdecl]<Device, Buffer, MemoryRequirements*, void> ptr) => new PfnGetBufferMemoryRequirements(ptr);
    }

    public unsafe delegate void GetBufferMemoryRequirements(Device arg0, Buffer arg1, MemoryRequirements* arg2);
    
    public unsafe readonly struct PfnGetImageMemoryRequirements : IDisposable
    {
        private readonly void* _handle;
        public delegate* unmanaged[Cdecl]<Device, Image, MemoryRequirements*, void> Handle => (delegate* unmanaged[Cdecl]<Device, Image, MemoryRequirements*, void>) _handle;
        public PfnGetImageMemoryRequirements
        (
            delegate* unmanaged[Cdecl]<Device, Image, MemoryRequirements*, void> ptr
        ) => _handle = ptr;

        public PfnGetImageMemoryRequirements
        (
            GetImageMemoryRequirements proc
        ) => _handle = (void*) SilkMarshal.DelegateToPtr(proc);

        public static PfnGetImageMemoryRequirements From(GetImageMemoryRequirements proc) => new PfnGetImageMemoryRequirements(proc);
        public void Dispose() => SilkMarshal.Free((IntPtr) _handle);

        public static implicit operator IntPtr(PfnGetImageMemoryRequirements pfn) => (IntPtr) pfn.Handle;
        public static explicit operator PfnGetImageMemoryRequirements(IntPtr pfn)
            => new PfnGetImageMemoryRequirements((delegate* unmanaged[Cdecl]<Device, Image, MemoryRequirements*, void>) pfn);

        public static implicit operator PfnGetImageMemoryRequirements(GetImageMemoryRequirements proc)
            => new PfnGetImageMemoryRequirements(proc);

        public static explicit operator GetImageMemoryRequirements(PfnGetImageMemoryRequirements pfn)
            => SilkMarshal.PtrToDelegate<GetImageMemoryRequirements>(pfn);

        public static implicit operator delegate* unmanaged[Cdecl]<Device, Image, MemoryRequirements*, void>(PfnGetImageMemoryRequirements pfn) => pfn.Handle;
        public static implicit operator PfnGetImageMemoryRequirements(delegate* unmanaged[Cdecl]<Device, Image, MemoryRequirements*, void> ptr) => new PfnGetImageMemoryRequirements(ptr);
    }

    public unsafe delegate void GetImageMemoryRequirements(Device arg0, Image arg1, MemoryRequirements* arg2);
}

