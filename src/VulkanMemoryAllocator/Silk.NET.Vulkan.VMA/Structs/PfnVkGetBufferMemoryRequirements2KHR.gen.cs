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
    public unsafe readonly struct PfnGetBufferMemoryRequirements2KHR : IDisposable
    {
        private readonly void* _handle;
        public delegate* unmanaged[Cdecl]<Device*, BufferMemoryRequirementsInfo2*, MemoryRequirements2*, void> Handle => (delegate* unmanaged[Cdecl]<Device*, BufferMemoryRequirementsInfo2*, MemoryRequirements2*, void>) _handle;
        public PfnGetBufferMemoryRequirements2KHR
        (
            delegate* unmanaged[Cdecl]<Device*, BufferMemoryRequirementsInfo2*, MemoryRequirements2*, void> ptr
        ) => _handle = ptr;

        public PfnGetBufferMemoryRequirements2KHR
        (
             GetBufferMemoryRequirements2KHR proc
        ) => _handle = (void*) SilkMarshal.DelegateToPtr(proc);

        public static PfnGetBufferMemoryRequirements2KHR From(GetBufferMemoryRequirements2KHR proc) => new PfnGetBufferMemoryRequirements2KHR(proc);
        public void Dispose() => SilkMarshal.Free((IntPtr) _handle);

        public static implicit operator IntPtr(PfnGetBufferMemoryRequirements2KHR pfn) => (IntPtr) pfn.Handle;
        public static explicit operator PfnGetBufferMemoryRequirements2KHR(IntPtr pfn)
            => new PfnGetBufferMemoryRequirements2KHR((delegate* unmanaged[Cdecl]<Device*, BufferMemoryRequirementsInfo2*, MemoryRequirements2*, void>) pfn);

        public static implicit operator PfnGetBufferMemoryRequirements2KHR(GetBufferMemoryRequirements2KHR proc)
            => new PfnGetBufferMemoryRequirements2KHR(proc);

        public static explicit operator GetBufferMemoryRequirements2KHR(PfnGetBufferMemoryRequirements2KHR pfn)
            => SilkMarshal.PtrToDelegate<GetBufferMemoryRequirements2KHR>(pfn);

        public static implicit operator delegate* unmanaged[Cdecl]<Device*, BufferMemoryRequirementsInfo2*, MemoryRequirements2*, void>(PfnGetBufferMemoryRequirements2KHR pfn) => pfn.Handle;
        public static implicit operator PfnGetBufferMemoryRequirements2KHR(delegate* unmanaged[Cdecl]<Device*, BufferMemoryRequirementsInfo2*, MemoryRequirements2*, void> ptr) => new PfnGetBufferMemoryRequirements2KHR(ptr);
    }

    public unsafe delegate void GetBufferMemoryRequirements2KHR(Device* arg0, BufferMemoryRequirementsInfo2* arg1, MemoryRequirements2* arg2);
}

