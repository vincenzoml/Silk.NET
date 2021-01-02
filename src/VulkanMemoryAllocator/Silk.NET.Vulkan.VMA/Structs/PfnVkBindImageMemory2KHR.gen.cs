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
    public unsafe readonly struct PfnBindImageMemory2KHR : IDisposable
    {
        private readonly void* _handle;
        public delegate* unmanaged[Cdecl]<Device, uint, BindImageMemoryInfo*, Result> Handle => (delegate* unmanaged[Cdecl]<Device, uint, BindImageMemoryInfo*, Result>) _handle;
        public PfnBindImageMemory2KHR
        (
            delegate* unmanaged[Cdecl]<Device, uint, BindImageMemoryInfo*, Result> ptr
        ) => _handle = ptr;

        public PfnBindImageMemory2KHR
        (
             BindImageMemory2KHR proc
        ) => _handle = (void*) SilkMarshal.DelegateToPtr(proc);

        public static PfnBindImageMemory2KHR From(BindImageMemory2KHR proc) => new PfnBindImageMemory2KHR(proc);
        public void Dispose() => SilkMarshal.Free((IntPtr) _handle);

        public static implicit operator IntPtr(PfnBindImageMemory2KHR pfn) => (IntPtr) pfn.Handle;
        public static explicit operator PfnBindImageMemory2KHR(IntPtr pfn)
            => new PfnBindImageMemory2KHR((delegate* unmanaged[Cdecl]<Device, uint, BindImageMemoryInfo*, Result>) pfn);

        public static implicit operator PfnBindImageMemory2KHR(BindImageMemory2KHR proc)
            => new PfnBindImageMemory2KHR(proc);

        public static explicit operator BindImageMemory2KHR(PfnBindImageMemory2KHR pfn)
            => SilkMarshal.PtrToDelegate<BindImageMemory2KHR>(pfn);

        public static implicit operator delegate* unmanaged[Cdecl]<Device, uint, BindImageMemoryInfo*, Result>(PfnBindImageMemory2KHR pfn) => pfn.Handle;
        public static implicit operator PfnBindImageMemory2KHR(delegate* unmanaged[Cdecl]<Device, uint, BindImageMemoryInfo*, Result> ptr) => new PfnBindImageMemory2KHR(ptr);
    }

    public unsafe delegate Result BindImageMemory2KHR(Device arg0, uint arg1, BindImageMemoryInfo* arg2);
}

