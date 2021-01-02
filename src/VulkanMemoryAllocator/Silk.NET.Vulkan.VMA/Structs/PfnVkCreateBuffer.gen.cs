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
    public unsafe readonly struct PfnCreateBuffer : IDisposable
    {
        private readonly void* _handle;
        public delegate* unmanaged[Cdecl]<Device, BufferCreateInfo*, AllocationCallbacks*, Buffer*, Result> Handle => (delegate* unmanaged[Cdecl]<Device, BufferCreateInfo*, AllocationCallbacks*, Buffer*, Result>) _handle;
        public PfnCreateBuffer
        (
            delegate* unmanaged[Cdecl]<Device, BufferCreateInfo*, AllocationCallbacks*, Buffer*, Result> ptr
        ) => _handle = ptr;

        public PfnCreateBuffer
        (
             CreateBuffer proc
        ) => _handle = (void*) SilkMarshal.DelegateToPtr(proc);

        public static PfnCreateBuffer From(CreateBuffer proc) => new PfnCreateBuffer(proc);
        public void Dispose() => SilkMarshal.Free((IntPtr) _handle);

        public static implicit operator IntPtr(PfnCreateBuffer pfn) => (IntPtr) pfn.Handle;
        public static explicit operator PfnCreateBuffer(IntPtr pfn)
            => new PfnCreateBuffer((delegate* unmanaged[Cdecl]<Device, BufferCreateInfo*, AllocationCallbacks*, Buffer*, Result>) pfn);

        public static implicit operator PfnCreateBuffer(CreateBuffer proc)
            => new PfnCreateBuffer(proc);

        public static explicit operator CreateBuffer(PfnCreateBuffer pfn)
            => SilkMarshal.PtrToDelegate<CreateBuffer>(pfn);

        public static implicit operator delegate* unmanaged[Cdecl]<Device, BufferCreateInfo*, AllocationCallbacks*, Buffer*, Result>(PfnCreateBuffer pfn) => pfn.Handle;
        public static implicit operator PfnCreateBuffer(delegate* unmanaged[Cdecl]<Device, BufferCreateInfo*, AllocationCallbacks*, Buffer*, Result> ptr) => new PfnCreateBuffer(ptr);
    }

    public unsafe delegate Result CreateBuffer(Device arg0, BufferCreateInfo* arg1, AllocationCallbacks* arg2, Buffer* arg3);
}

