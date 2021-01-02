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
        public delegate* unmanaged[Cdecl]<Device*, ulong, ulong, ulong, Result> Handle => (delegate* unmanaged[Cdecl]<Device*, ulong, ulong, ulong, Result>) _handle;
        public PfnBindBufferMemory
        (
            delegate* unmanaged[Cdecl]<Device*, ulong, ulong, ulong, Result> ptr
        ) => _handle = ptr;

        public PfnBindBufferMemory
        (
             BindBufferMemory proc
        ) => _handle = (void*) SilkMarshal.DelegateToPtr(proc);

        public static PfnBindBufferMemory From(BindBufferMemory proc) => new PfnBindBufferMemory(proc);
        public void Dispose() => SilkMarshal.Free((IntPtr) _handle);

        public static implicit operator IntPtr(PfnBindBufferMemory pfn) => (IntPtr) pfn.Handle;
        public static explicit operator PfnBindBufferMemory(IntPtr pfn)
            => new PfnBindBufferMemory((delegate* unmanaged[Cdecl]<Device*, ulong, ulong, ulong, Result>) pfn);

        public static implicit operator PfnBindBufferMemory(BindBufferMemory proc)
            => new PfnBindBufferMemory(proc);

        public static explicit operator BindBufferMemory(PfnBindBufferMemory pfn)
            => SilkMarshal.PtrToDelegate<BindBufferMemory>(pfn);

        public static implicit operator delegate* unmanaged[Cdecl]<Device*, ulong, ulong, ulong, Result>(PfnBindBufferMemory pfn) => pfn.Handle;
        public static implicit operator PfnBindBufferMemory(delegate* unmanaged[Cdecl]<Device*, ulong, ulong, ulong, Result> ptr) => new PfnBindBufferMemory(ptr);
    }

    public unsafe delegate Result BindBufferMemory(Device* arg0, ulong arg1, ulong arg2, ulong arg3);
}

