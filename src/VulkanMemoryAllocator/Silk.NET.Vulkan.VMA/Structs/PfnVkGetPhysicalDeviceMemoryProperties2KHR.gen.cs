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
    public unsafe readonly struct PfnGetPhysicalDeviceMemoryProperties2KHR : IDisposable
    {
        private readonly void* _handle;
        public delegate* unmanaged[Cdecl]<PhysicalDevice, PhysicalDeviceMemoryProperties2*, void> Handle => (delegate* unmanaged[Cdecl]<PhysicalDevice, PhysicalDeviceMemoryProperties2*, void>) _handle;
        public PfnGetPhysicalDeviceMemoryProperties2KHR
        (
            delegate* unmanaged[Cdecl]<PhysicalDevice, PhysicalDeviceMemoryProperties2*, void> ptr
        ) => _handle = ptr;

        public PfnGetPhysicalDeviceMemoryProperties2KHR
        (
             GetPhysicalDeviceMemoryProperties2KHR proc
        ) => _handle = (void*) SilkMarshal.DelegateToPtr(proc);

        public static PfnGetPhysicalDeviceMemoryProperties2KHR From(GetPhysicalDeviceMemoryProperties2KHR proc) => new PfnGetPhysicalDeviceMemoryProperties2KHR(proc);
        public void Dispose() => SilkMarshal.Free((IntPtr) _handle);

        public static implicit operator IntPtr(PfnGetPhysicalDeviceMemoryProperties2KHR pfn) => (IntPtr) pfn.Handle;
        public static explicit operator PfnGetPhysicalDeviceMemoryProperties2KHR(IntPtr pfn)
            => new PfnGetPhysicalDeviceMemoryProperties2KHR((delegate* unmanaged[Cdecl]<PhysicalDevice, PhysicalDeviceMemoryProperties2*, void>) pfn);

        public static implicit operator PfnGetPhysicalDeviceMemoryProperties2KHR(GetPhysicalDeviceMemoryProperties2KHR proc)
            => new PfnGetPhysicalDeviceMemoryProperties2KHR(proc);

        public static explicit operator GetPhysicalDeviceMemoryProperties2KHR(PfnGetPhysicalDeviceMemoryProperties2KHR pfn)
            => SilkMarshal.PtrToDelegate<GetPhysicalDeviceMemoryProperties2KHR>(pfn);

        public static implicit operator delegate* unmanaged[Cdecl]<PhysicalDevice, PhysicalDeviceMemoryProperties2*, void>(PfnGetPhysicalDeviceMemoryProperties2KHR pfn) => pfn.Handle;
        public static implicit operator PfnGetPhysicalDeviceMemoryProperties2KHR(delegate* unmanaged[Cdecl]<PhysicalDevice, PhysicalDeviceMemoryProperties2*, void> ptr) => new PfnGetPhysicalDeviceMemoryProperties2KHR(ptr);
    }

    public unsafe delegate void GetPhysicalDeviceMemoryProperties2KHR(PhysicalDevice arg0, PhysicalDeviceMemoryProperties2* arg1);
}

