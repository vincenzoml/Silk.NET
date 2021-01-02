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
        public delegate* unmanaged[Cdecl]<Device*, ulong, MemoryRequirements*, void> Handle => (delegate* unmanaged[Cdecl]<Device*, ulong, MemoryRequirements*, void>) _handle;
        public PfnGetBufferMemoryRequirements
        (
            delegate* unmanaged[Cdecl]<Device*, ulong, MemoryRequirements*, void> ptr
        ) => _handle = ptr;

        public PfnGetBufferMemoryRequirements
        (
             GetBufferMemoryRequirements proc
        ) => _handle = (void*) SilkMarshal.DelegateToPtr(proc);

        public static PfnGetBufferMemoryRequirements From(GetBufferMemoryRequirements proc) => new PfnGetBufferMemoryRequirements(proc);
        public void Dispose() => SilkMarshal.Free((IntPtr) _handle);

        public static implicit operator IntPtr(PfnGetBufferMemoryRequirements pfn) => (IntPtr) pfn.Handle;
        public static explicit operator PfnGetBufferMemoryRequirements(IntPtr pfn)
            => new PfnGetBufferMemoryRequirements((delegate* unmanaged[Cdecl]<Device*, ulong, MemoryRequirements*, void>) pfn);

        public static implicit operator PfnGetBufferMemoryRequirements(GetBufferMemoryRequirements proc)
            => new PfnGetBufferMemoryRequirements(proc);

        public static explicit operator GetBufferMemoryRequirements(PfnGetBufferMemoryRequirements pfn)
            => SilkMarshal.PtrToDelegate<GetBufferMemoryRequirements>(pfn);

        public static implicit operator delegate* unmanaged[Cdecl]<Device*, ulong, MemoryRequirements*, void>(PfnGetBufferMemoryRequirements pfn) => pfn.Handle;
        public static implicit operator PfnGetBufferMemoryRequirements(delegate* unmanaged[Cdecl]<Device*, ulong, MemoryRequirements*, void> ptr) => new PfnGetBufferMemoryRequirements(ptr);
    }

    public unsafe delegate void GetBufferMemoryRequirements(Device* arg0, ulong arg1, MemoryRequirements* arg2);
}

