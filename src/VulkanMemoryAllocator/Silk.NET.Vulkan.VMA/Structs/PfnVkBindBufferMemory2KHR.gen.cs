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
    public unsafe readonly struct PfnBindBufferMemory2KHR : IDisposable
    {
        private readonly void* _handle;
        public delegate* unmanaged[Cdecl]<void*, uint, BindBufferMemoryInfo*, Result> Handle => (delegate* unmanaged[Cdecl]<void*, uint, BindBufferMemoryInfo*, Result>) _handle;
        public PfnBindBufferMemory2KHR
        (
            delegate* unmanaged[Cdecl]<void*, uint, BindBufferMemoryInfo*, Result> ptr
        ) => _handle = ptr;

        public PfnBindBufferMemory2KHR
        (
             BindBufferMemory2KHR proc
        ) => _handle = (void*) SilkMarshal.DelegateToPtr(proc);

        public static PfnBindBufferMemory2KHR From(BindBufferMemory2KHR proc) => new PfnBindBufferMemory2KHR(proc);
        public void Dispose() => SilkMarshal.Free((IntPtr) _handle);

        public static implicit operator IntPtr(PfnBindBufferMemory2KHR pfn) => (IntPtr) pfn.Handle;
        public static explicit operator PfnBindBufferMemory2KHR(IntPtr pfn)
            => new PfnBindBufferMemory2KHR((delegate* unmanaged[Cdecl]<void*, uint, BindBufferMemoryInfo*, Result>) pfn);

        public static implicit operator PfnBindBufferMemory2KHR(BindBufferMemory2KHR proc)
            => new PfnBindBufferMemory2KHR(proc);

        public static explicit operator BindBufferMemory2KHR(PfnBindBufferMemory2KHR pfn)
            => SilkMarshal.PtrToDelegate<BindBufferMemory2KHR>(pfn);

        public static implicit operator delegate* unmanaged[Cdecl]<void*, uint, BindBufferMemoryInfo*, Result>(PfnBindBufferMemory2KHR pfn) => pfn.Handle;
        public static implicit operator PfnBindBufferMemory2KHR(delegate* unmanaged[Cdecl]<void*, uint, BindBufferMemoryInfo*, Result> ptr) => new PfnBindBufferMemory2KHR(ptr);
    }

    public unsafe delegate Result BindBufferMemory2KHR(void* arg0, uint arg1, BindBufferMemoryInfo* arg2);
}

