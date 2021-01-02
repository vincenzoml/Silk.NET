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
    public unsafe readonly struct PfnGetPhysicalDeviceMemoryProperties : IDisposable
    {
        private readonly void* _handle;
        public delegate* unmanaged[Cdecl]<PhysicalDevice, PhysicalDeviceMemoryProperties*, void> Handle => (delegate* unmanaged[Cdecl]<PhysicalDevice, PhysicalDeviceMemoryProperties*, void>) _handle;
        public PfnGetPhysicalDeviceMemoryProperties
        (
            delegate* unmanaged[Cdecl]<PhysicalDevice, PhysicalDeviceMemoryProperties*, void> ptr
        ) => _handle = ptr;

        public PfnGetPhysicalDeviceMemoryProperties
        (
             GetPhysicalDeviceMemoryProperties proc
        ) => _handle = (void*) SilkMarshal.DelegateToPtr(proc);

        public static PfnGetPhysicalDeviceMemoryProperties From(GetPhysicalDeviceMemoryProperties proc) => new PfnGetPhysicalDeviceMemoryProperties(proc);
        public void Dispose() => SilkMarshal.Free((IntPtr) _handle);

        public static implicit operator IntPtr(PfnGetPhysicalDeviceMemoryProperties pfn) => (IntPtr) pfn.Handle;
        public static explicit operator PfnGetPhysicalDeviceMemoryProperties(IntPtr pfn)
            => new PfnGetPhysicalDeviceMemoryProperties((delegate* unmanaged[Cdecl]<PhysicalDevice, PhysicalDeviceMemoryProperties*, void>) pfn);

        public static implicit operator PfnGetPhysicalDeviceMemoryProperties(GetPhysicalDeviceMemoryProperties proc)
            => new PfnGetPhysicalDeviceMemoryProperties(proc);

        public static explicit operator GetPhysicalDeviceMemoryProperties(PfnGetPhysicalDeviceMemoryProperties pfn)
            => SilkMarshal.PtrToDelegate<GetPhysicalDeviceMemoryProperties>(pfn);

        public static implicit operator delegate* unmanaged[Cdecl]<PhysicalDevice, PhysicalDeviceMemoryProperties*, void>(PfnGetPhysicalDeviceMemoryProperties pfn) => pfn.Handle;
        public static implicit operator PfnGetPhysicalDeviceMemoryProperties(delegate* unmanaged[Cdecl]<PhysicalDevice, PhysicalDeviceMemoryProperties*, void> ptr) => new PfnGetPhysicalDeviceMemoryProperties(ptr);
    }

    public unsafe delegate void GetPhysicalDeviceMemoryProperties(PhysicalDevice arg0, PhysicalDeviceMemoryProperties* arg1);
}

