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
    public unsafe readonly struct PfnCreateImage : IDisposable
    {
        private readonly void* _handle;
        public delegate* unmanaged[Cdecl]<Device, ImageCreateInfo*, AllocationCallbacks*, Image*, Result> Handle => (delegate* unmanaged[Cdecl]<Device, ImageCreateInfo*, AllocationCallbacks*, Image*, Result>) _handle;
        public PfnCreateImage
        (
            delegate* unmanaged[Cdecl]<Device, ImageCreateInfo*, AllocationCallbacks*, Image*, Result> ptr
        ) => _handle = ptr;

        public PfnCreateImage
        (
             CreateImage proc
        ) => _handle = (void*) SilkMarshal.DelegateToPtr(proc);

        public static PfnCreateImage From(CreateImage proc) => new PfnCreateImage(proc);
        public void Dispose() => SilkMarshal.Free((IntPtr) _handle);

        public static implicit operator IntPtr(PfnCreateImage pfn) => (IntPtr) pfn.Handle;
        public static explicit operator PfnCreateImage(IntPtr pfn)
            => new PfnCreateImage((delegate* unmanaged[Cdecl]<Device, ImageCreateInfo*, AllocationCallbacks*, Image*, Result>) pfn);

        public static implicit operator PfnCreateImage(CreateImage proc)
            => new PfnCreateImage(proc);

        public static explicit operator CreateImage(PfnCreateImage pfn)
            => SilkMarshal.PtrToDelegate<CreateImage>(pfn);

        public static implicit operator delegate* unmanaged[Cdecl]<Device, ImageCreateInfo*, AllocationCallbacks*, Image*, Result>(PfnCreateImage pfn) => pfn.Handle;
        public static implicit operator PfnCreateImage(delegate* unmanaged[Cdecl]<Device, ImageCreateInfo*, AllocationCallbacks*, Image*, Result> ptr) => new PfnCreateImage(ptr);
    }

    public unsafe delegate Result CreateImage(Device arg0, ImageCreateInfo* arg1, AllocationCallbacks* arg2, Image* arg3);
}

