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
    public unsafe readonly struct PfnGetPhysicalDeviceProperties : IDisposable
    {
        private readonly void* _handle;
        public delegate* unmanaged[Cdecl]<PhysicalDevice*, PhysicalDeviceProperties*, void> Handle => (delegate* unmanaged[Cdecl]<PhysicalDevice*, PhysicalDeviceProperties*, void>) _handle;
        public PfnGetPhysicalDeviceProperties
        (
            delegate* unmanaged[Cdecl]<PhysicalDevice*, PhysicalDeviceProperties*, void> ptr
        ) => _handle = ptr;

        public PfnGetPhysicalDeviceProperties
        (
             GetPhysicalDeviceProperties proc
        ) => _handle = (void*) SilkMarshal.DelegateToPtr(proc);

        public static PfnGetPhysicalDeviceProperties From(GetPhysicalDeviceProperties proc) => new PfnGetPhysicalDeviceProperties(proc);
        public void Dispose() => SilkMarshal.Free((IntPtr) _handle);

        public static implicit operator IntPtr(PfnGetPhysicalDeviceProperties pfn) => (IntPtr) pfn.Handle;
        public static explicit operator PfnGetPhysicalDeviceProperties(IntPtr pfn)
            => new PfnGetPhysicalDeviceProperties((delegate* unmanaged[Cdecl]<PhysicalDevice*, PhysicalDeviceProperties*, void>) pfn);

        public static implicit operator PfnGetPhysicalDeviceProperties(GetPhysicalDeviceProperties proc)
            => new PfnGetPhysicalDeviceProperties(proc);

        public static explicit operator GetPhysicalDeviceProperties(PfnGetPhysicalDeviceProperties pfn)
            => SilkMarshal.PtrToDelegate<GetPhysicalDeviceProperties>(pfn);

        public static implicit operator delegate* unmanaged[Cdecl]<PhysicalDevice*, PhysicalDeviceProperties*, void>(PfnGetPhysicalDeviceProperties pfn) => pfn.Handle;
        public static implicit operator PfnGetPhysicalDeviceProperties(delegate* unmanaged[Cdecl]<PhysicalDevice*, PhysicalDeviceProperties*, void> ptr) => new PfnGetPhysicalDeviceProperties(ptr);
    }

    public unsafe delegate void GetPhysicalDeviceProperties(PhysicalDevice* arg0, PhysicalDeviceProperties* arg1);
}

