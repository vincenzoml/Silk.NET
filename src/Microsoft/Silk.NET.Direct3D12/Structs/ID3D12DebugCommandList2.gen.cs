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

namespace Silk.NET.Direct3D12
{
    [Guid("aeb575cf-4e06-48be-ba3b-c450fc96652e")]
    [NativeName("Name", "ID3D12DebugCommandList2")]
    public unsafe partial struct ID3D12DebugCommandList2
    {
        public static readonly Guid Guid = new("aeb575cf-4e06-48be-ba3b-c450fc96652e");

        public static implicit operator ID3D12DebugCommandList(ID3D12DebugCommandList2 val)
            => Unsafe.As<ID3D12DebugCommandList2, ID3D12DebugCommandList>(ref val);

        public static implicit operator Silk.NET.Core.Native.IUnknown(ID3D12DebugCommandList2 val)
            => Unsafe.As<ID3D12DebugCommandList2, Silk.NET.Core.Native.IUnknown>(ref val);

        public ID3D12DebugCommandList2
        (
            void** lpVtbl = null
        ) : this()
        {
            if (lpVtbl is not null)
            {
                LpVtbl = lpVtbl;
            }
        }


        [NativeName("Type", "")]
        [NativeName("Type.Name", "")]
        [NativeName("Name", "lpVtbl")]
        public void** LpVtbl;
        /// <summary>To be documented.</summary>
        public readonly unsafe int QueryInterface(Guid* riid, void** ppvObject)
        {
            var @this = (ID3D12DebugCommandList2*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            ret = ((delegate* unmanaged[Cdecl]<ID3D12DebugCommandList2*, Guid*, void**, int>)LpVtbl[0])(@this, riid, ppvObject);
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int QueryInterface(Guid* riid, ref void* ppvObject)
        {
            var @this = (ID3D12DebugCommandList2*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (void** ppvObjectPtr = &ppvObject)
            {
                ret = ((delegate* unmanaged[Cdecl]<ID3D12DebugCommandList2*, Guid*, void**, int>)LpVtbl[0])(@this, riid, ppvObjectPtr);
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int QueryInterface(ref Guid riid, void** ppvObject)
        {
            var @this = (ID3D12DebugCommandList2*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (Guid* riidPtr = &riid)
            {
                ret = ((delegate* unmanaged[Cdecl]<ID3D12DebugCommandList2*, Guid*, void**, int>)LpVtbl[0])(@this, riidPtr, ppvObject);
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int QueryInterface(ref Guid riid, ref void* ppvObject)
        {
            var @this = (ID3D12DebugCommandList2*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (Guid* riidPtr = &riid)
            {
                fixed (void** ppvObjectPtr = &ppvObject)
                {
                    ret = ((delegate* unmanaged[Cdecl]<ID3D12DebugCommandList2*, Guid*, void**, int>)LpVtbl[0])(@this, riidPtr, ppvObjectPtr);
                }
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly uint AddRef()
        {
            var @this = (ID3D12DebugCommandList2*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            uint ret = default;
            ret = ((delegate* unmanaged[Stdcall]<ID3D12DebugCommandList2*, uint>)LpVtbl[1])(@this);
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly uint Release()
        {
            var @this = (ID3D12DebugCommandList2*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            uint ret = default;
            ret = ((delegate* unmanaged[Stdcall]<ID3D12DebugCommandList2*, uint>)LpVtbl[2])(@this);
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int AssertResourceState(ID3D12Resource* pResource, uint Subresource, uint State)
        {
            var @this = (ID3D12DebugCommandList2*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            ret = ((delegate* unmanaged[Cdecl]<ID3D12DebugCommandList2*, ID3D12Resource*, uint, uint, int>)LpVtbl[3])(@this, pResource, Subresource, State);
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly int AssertResourceState(ref ID3D12Resource pResource, uint Subresource, uint State)
        {
            var @this = (ID3D12DebugCommandList2*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (ID3D12Resource* pResourcePtr = &pResource)
            {
                ret = ((delegate* unmanaged[Cdecl]<ID3D12DebugCommandList2*, ID3D12Resource*, uint, uint, int>)LpVtbl[3])(@this, pResourcePtr, Subresource, State);
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly int SetFeatureMask(DebugFeature Mask)
        {
            var @this = (ID3D12DebugCommandList2*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            ret = ((delegate* unmanaged[Cdecl]<ID3D12DebugCommandList2*, DebugFeature, int>)LpVtbl[4])(@this, Mask);
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly DebugFeature GetFeatureMask()
        {
            var @this = (ID3D12DebugCommandList2*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            DebugFeature ret = default;
            ret = ((delegate* unmanaged[Stdcall]<ID3D12DebugCommandList2*, DebugFeature>)LpVtbl[5])(@this);
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int SetDebugParameter(DebugCommandListParameterType Type, void* pData, uint DataSize)
        {
            var @this = (ID3D12DebugCommandList2*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            ret = ((delegate* unmanaged[Cdecl]<ID3D12DebugCommandList2*, DebugCommandListParameterType, void*, uint, int>)LpVtbl[6])(@this, Type, pData, DataSize);
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly int SetDebugParameter<T0>(DebugCommandListParameterType Type, ref T0 pData, uint DataSize) where T0 : unmanaged
        {
            var @this = (ID3D12DebugCommandList2*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (T0* pDataPtr = &pData)
            {
                ret = ((delegate* unmanaged[Cdecl]<ID3D12DebugCommandList2*, DebugCommandListParameterType, T0*, uint, int>)LpVtbl[6])(@this, Type, pDataPtr, DataSize);
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int GetDebugParameter(DebugCommandListParameterType Type, void* pData, uint DataSize)
        {
            var @this = (ID3D12DebugCommandList2*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            ret = ((delegate* unmanaged[Cdecl]<ID3D12DebugCommandList2*, DebugCommandListParameterType, void*, uint, int>)LpVtbl[7])(@this, Type, pData, DataSize);
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly int GetDebugParameter<T0>(DebugCommandListParameterType Type, ref T0 pData, uint DataSize) where T0 : unmanaged
        {
            var @this = (ID3D12DebugCommandList2*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (T0* pDataPtr = &pData)
            {
                ret = ((delegate* unmanaged[Cdecl]<ID3D12DebugCommandList2*, DebugCommandListParameterType, T0*, uint, int>)LpVtbl[7])(@this, Type, pDataPtr, DataSize);
            }
            return ret;
        }

    }
}
