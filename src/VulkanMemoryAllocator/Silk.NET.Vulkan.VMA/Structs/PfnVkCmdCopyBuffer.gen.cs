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
    public unsafe readonly struct PfnCmdCopyBuffer : IDisposable
    {
        private readonly void* _handle;
        public delegate* unmanaged[Cdecl]<CommandBuffer, Buffer, Buffer, uint, BufferCopy*, void> Handle => (delegate* unmanaged[Cdecl]<CommandBuffer, Buffer, Buffer, uint, BufferCopy*, void>) _handle;
        public PfnCmdCopyBuffer
        (
            delegate* unmanaged[Cdecl]<CommandBuffer, Buffer, Buffer, uint, BufferCopy*, void> ptr
        ) => _handle = ptr;

        public PfnCmdCopyBuffer
        (
             CmdCopyBuffer proc
        ) => _handle = (void*) SilkMarshal.DelegateToPtr(proc);

        public static PfnCmdCopyBuffer From(CmdCopyBuffer proc) => new PfnCmdCopyBuffer(proc);
        public void Dispose() => SilkMarshal.Free((IntPtr) _handle);

        public static implicit operator IntPtr(PfnCmdCopyBuffer pfn) => (IntPtr) pfn.Handle;
        public static explicit operator PfnCmdCopyBuffer(IntPtr pfn)
            => new PfnCmdCopyBuffer((delegate* unmanaged[Cdecl]<CommandBuffer, Buffer, Buffer, uint, BufferCopy*, void>) pfn);

        public static implicit operator PfnCmdCopyBuffer(CmdCopyBuffer proc)
            => new PfnCmdCopyBuffer(proc);

        public static explicit operator CmdCopyBuffer(PfnCmdCopyBuffer pfn)
            => SilkMarshal.PtrToDelegate<CmdCopyBuffer>(pfn);

        public static implicit operator delegate* unmanaged[Cdecl]<CommandBuffer, Buffer, Buffer, uint, BufferCopy*, void>(PfnCmdCopyBuffer pfn) => pfn.Handle;
        public static implicit operator PfnCmdCopyBuffer(delegate* unmanaged[Cdecl]<CommandBuffer, Buffer, Buffer, uint, BufferCopy*, void> ptr) => new PfnCmdCopyBuffer(ptr);
    }

    public unsafe delegate void CmdCopyBuffer(CommandBuffer arg0, Buffer arg1, Buffer arg2, uint arg3, BufferCopy* arg4);
}

