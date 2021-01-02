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
    public unsafe readonly struct PfnGetImageMemoryRequirements2KHR : IDisposable
    {
        private readonly void* _handle;
        public delegate* unmanaged[Cdecl]<Device*, ImageMemoryRequirementsInfo2*, MemoryRequirements2*, void> Handle => (delegate* unmanaged[Cdecl]<Device*, ImageMemoryRequirementsInfo2*, MemoryRequirements2*, void>) _handle;
        public PfnGetImageMemoryRequirements2KHR
        (
            delegate* unmanaged[Cdecl]<Device*, ImageMemoryRequirementsInfo2*, MemoryRequirements2*, void> ptr
        ) => _handle = ptr;

        public PfnGetImageMemoryRequirements2KHR
        (
             GetImageMemoryRequirements2KHR proc
        ) => _handle = (void*) SilkMarshal.DelegateToPtr(proc);

        public static PfnGetImageMemoryRequirements2KHR From(GetImageMemoryRequirements2KHR proc) => new PfnGetImageMemoryRequirements2KHR(proc);
        public void Dispose() => SilkMarshal.Free((IntPtr) _handle);

        public static implicit operator IntPtr(PfnGetImageMemoryRequirements2KHR pfn) => (IntPtr) pfn.Handle;
        public static explicit operator PfnGetImageMemoryRequirements2KHR(IntPtr pfn)
            => new PfnGetImageMemoryRequirements2KHR((delegate* unmanaged[Cdecl]<Device*, ImageMemoryRequirementsInfo2*, MemoryRequirements2*, void>) pfn);

        public static implicit operator PfnGetImageMemoryRequirements2KHR(GetImageMemoryRequirements2KHR proc)
            => new PfnGetImageMemoryRequirements2KHR(proc);

        public static explicit operator GetImageMemoryRequirements2KHR(PfnGetImageMemoryRequirements2KHR pfn)
            => SilkMarshal.PtrToDelegate<GetImageMemoryRequirements2KHR>(pfn);

        public static implicit operator delegate* unmanaged[Cdecl]<Device*, ImageMemoryRequirementsInfo2*, MemoryRequirements2*, void>(PfnGetImageMemoryRequirements2KHR pfn) => pfn.Handle;
        public static implicit operator PfnGetImageMemoryRequirements2KHR(delegate* unmanaged[Cdecl]<Device*, ImageMemoryRequirementsInfo2*, MemoryRequirements2*, void> ptr) => new PfnGetImageMemoryRequirements2KHR(ptr);
    }

    public unsafe delegate void GetImageMemoryRequirements2KHR(Device* arg0, ImageMemoryRequirementsInfo2* arg1, MemoryRequirements2* arg2);
}

