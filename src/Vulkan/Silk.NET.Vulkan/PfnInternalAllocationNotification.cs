﻿// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using Silk.NET.Core.Native;

namespace Silk.NET.Vulkan
{
    public readonly unsafe struct PfnInternalAllocationNotification
    {
        private readonly void* _handle;

        public delegate* unmanaged[Cdecl]<void*, nuint, InternalAllocationType, SystemAllocationScope, void>
            Handle =>
            (delegate* unmanaged[Cdecl]<void*, nuint, InternalAllocationType, SystemAllocationScope, void>) _handle;

        public PfnInternalAllocationNotification
            (delegate* unmanaged[Cdecl]<void*, nuint, InternalAllocationType, SystemAllocationScope, void> ptr) =>
            _handle = ptr;

        public PfnInternalAllocationNotification
            (InternalAllocationNotification func) => _handle =
            (delegate* unmanaged[Cdecl]<void*, nuint, InternalAllocationType, SystemAllocationScope, void>) SilkMarshal
                .DelegateToPtr(func);

        public static implicit operator delegate* unmanaged[Cdecl]<void*, nuint, InternalAllocationType,
            SystemAllocationScope, void>(PfnInternalAllocationNotification pfn) => pfn.Handle;

        public static implicit operator PfnInternalAllocationNotification
            (delegate* unmanaged[Cdecl]<void*, nuint, InternalAllocationType, SystemAllocationScope, void> func) =>
            new(func);

        public static implicit operator PfnInternalAllocationNotification
            (InternalAllocationNotification func) => new(func);

        public static explicit operator InternalAllocationNotification
            (PfnInternalAllocationNotification pfn) => SilkMarshal.PtrToDelegate<InternalAllocationNotification>
            ((nint) pfn.Handle);
    }
}
