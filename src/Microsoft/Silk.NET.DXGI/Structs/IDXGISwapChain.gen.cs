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

namespace Silk.NET.DXGI
{
    [Guid("310d36a0-d2e7-4c0a-aa04-6a9d23b8886a")]
    [NativeName("Name", "IDXGISwapChain")]
    public unsafe partial struct IDXGISwapChain
    {
        public static readonly Guid Guid = new("310d36a0-d2e7-4c0a-aa04-6a9d23b8886a");

        public static implicit operator IDXGIDeviceSubObject(IDXGISwapChain val)
            => Unsafe.As<IDXGISwapChain, IDXGIDeviceSubObject>(ref val);

        public static implicit operator IDXGIObject(IDXGISwapChain val)
            => Unsafe.As<IDXGISwapChain, IDXGIObject>(ref val);

        public static implicit operator Silk.NET.Core.Native.IUnknown(IDXGISwapChain val)
            => Unsafe.As<IDXGISwapChain, Silk.NET.Core.Native.IUnknown>(ref val);

        public IDXGISwapChain
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
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, Guid*, void**, int>)LpVtbl[0])(@this, riid, ppvObject);
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int QueryInterface(Guid* riid, ref void* ppvObject)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (void** ppvObjectPtr = &ppvObject)
            {
                ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, Guid*, void**, int>)LpVtbl[0])(@this, riid, ppvObjectPtr);
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int QueryInterface(ref Guid riid, void** ppvObject)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (Guid* riidPtr = &riid)
            {
                ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, Guid*, void**, int>)LpVtbl[0])(@this, riidPtr, ppvObject);
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int QueryInterface(ref Guid riid, ref void* ppvObject)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (Guid* riidPtr = &riid)
            {
                fixed (void** ppvObjectPtr = &ppvObject)
                {
                    ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, Guid*, void**, int>)LpVtbl[0])(@this, riidPtr, ppvObjectPtr);
                }
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly uint AddRef()
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            uint ret = default;
            ret = ((delegate* unmanaged[Stdcall]<IDXGISwapChain*, uint>)LpVtbl[1])(@this);
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly uint Release()
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            uint ret = default;
            ret = ((delegate* unmanaged[Stdcall]<IDXGISwapChain*, uint>)LpVtbl[2])(@this);
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int SetPrivateData(Guid* Name, uint DataSize, void* pData)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, Guid*, uint, void*, int>)LpVtbl[3])(@this, Name, DataSize, pData);
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int SetPrivateData<T0>(Guid* Name, uint DataSize, ref T0 pData) where T0 : unmanaged
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (T0* pDataPtr = &pData)
            {
                ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, Guid*, uint, T0*, int>)LpVtbl[3])(@this, Name, DataSize, pDataPtr);
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int SetPrivateData(ref Guid Name, uint DataSize, void* pData)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (Guid* NamePtr = &Name)
            {
                ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, Guid*, uint, void*, int>)LpVtbl[3])(@this, NamePtr, DataSize, pData);
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly int SetPrivateData<T0>(ref Guid Name, uint DataSize, ref T0 pData) where T0 : unmanaged
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (Guid* NamePtr = &Name)
            {
                fixed (T0* pDataPtr = &pData)
                {
                    ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, Guid*, uint, T0*, int>)LpVtbl[3])(@this, NamePtr, DataSize, pDataPtr);
                }
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int SetPrivateDataInterface(Guid* Name, [Flow(FlowDirection.In)] Silk.NET.Core.Native.IUnknown* pUnknown)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, Guid*, Silk.NET.Core.Native.IUnknown*, int>)LpVtbl[4])(@this, Name, pUnknown);
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int SetPrivateDataInterface(Guid* Name, [Flow(FlowDirection.In)] in Silk.NET.Core.Native.IUnknown pUnknown)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (Silk.NET.Core.Native.IUnknown* pUnknownPtr = &pUnknown)
            {
                ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, Guid*, Silk.NET.Core.Native.IUnknown*, int>)LpVtbl[4])(@this, Name, pUnknownPtr);
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int SetPrivateDataInterface(ref Guid Name, [Flow(FlowDirection.In)] Silk.NET.Core.Native.IUnknown* pUnknown)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (Guid* NamePtr = &Name)
            {
                ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, Guid*, Silk.NET.Core.Native.IUnknown*, int>)LpVtbl[4])(@this, NamePtr, pUnknown);
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly int SetPrivateDataInterface(ref Guid Name, [Flow(FlowDirection.In)] in Silk.NET.Core.Native.IUnknown pUnknown)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (Guid* NamePtr = &Name)
            {
                fixed (Silk.NET.Core.Native.IUnknown* pUnknownPtr = &pUnknown)
                {
                    ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, Guid*, Silk.NET.Core.Native.IUnknown*, int>)LpVtbl[4])(@this, NamePtr, pUnknownPtr);
                }
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int GetPrivateData(Guid* Name, uint* pDataSize, void* pData)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, Guid*, uint*, void*, int>)LpVtbl[5])(@this, Name, pDataSize, pData);
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int GetPrivateData<T0>(Guid* Name, uint* pDataSize, ref T0 pData) where T0 : unmanaged
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (T0* pDataPtr = &pData)
            {
                ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, Guid*, uint*, T0*, int>)LpVtbl[5])(@this, Name, pDataSize, pDataPtr);
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int GetPrivateData(Guid* Name, ref uint pDataSize, void* pData)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (uint* pDataSizePtr = &pDataSize)
            {
                ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, Guid*, uint*, void*, int>)LpVtbl[5])(@this, Name, pDataSizePtr, pData);
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int GetPrivateData<T0>(Guid* Name, ref uint pDataSize, ref T0 pData) where T0 : unmanaged
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (uint* pDataSizePtr = &pDataSize)
            {
                fixed (T0* pDataPtr = &pData)
                {
                    ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, Guid*, uint*, T0*, int>)LpVtbl[5])(@this, Name, pDataSizePtr, pDataPtr);
                }
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int GetPrivateData(ref Guid Name, uint* pDataSize, void* pData)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (Guid* NamePtr = &Name)
            {
                ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, Guid*, uint*, void*, int>)LpVtbl[5])(@this, NamePtr, pDataSize, pData);
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int GetPrivateData<T0>(ref Guid Name, uint* pDataSize, ref T0 pData) where T0 : unmanaged
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (Guid* NamePtr = &Name)
            {
                fixed (T0* pDataPtr = &pData)
                {
                    ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, Guid*, uint*, T0*, int>)LpVtbl[5])(@this, NamePtr, pDataSize, pDataPtr);
                }
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int GetPrivateData(ref Guid Name, ref uint pDataSize, void* pData)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (Guid* NamePtr = &Name)
            {
                fixed (uint* pDataSizePtr = &pDataSize)
                {
                    ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, Guid*, uint*, void*, int>)LpVtbl[5])(@this, NamePtr, pDataSizePtr, pData);
                }
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly int GetPrivateData<T0>(ref Guid Name, ref uint pDataSize, ref T0 pData) where T0 : unmanaged
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (Guid* NamePtr = &Name)
            {
                fixed (uint* pDataSizePtr = &pDataSize)
                {
                    fixed (T0* pDataPtr = &pData)
                    {
                        ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, Guid*, uint*, T0*, int>)LpVtbl[5])(@this, NamePtr, pDataSizePtr, pDataPtr);
                    }
                }
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int GetParent(Guid* riid, void** ppParent)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, Guid*, void**, int>)LpVtbl[6])(@this, riid, ppParent);
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int GetParent(Guid* riid, ref void* ppParent)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (void** ppParentPtr = &ppParent)
            {
                ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, Guid*, void**, int>)LpVtbl[6])(@this, riid, ppParentPtr);
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int GetParent(ref Guid riid, void** ppParent)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (Guid* riidPtr = &riid)
            {
                ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, Guid*, void**, int>)LpVtbl[6])(@this, riidPtr, ppParent);
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int GetParent(ref Guid riid, ref void* ppParent)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (Guid* riidPtr = &riid)
            {
                fixed (void** ppParentPtr = &ppParent)
                {
                    ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, Guid*, void**, int>)LpVtbl[6])(@this, riidPtr, ppParentPtr);
                }
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int GetDevice(Guid* riid, void** ppDevice)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, Guid*, void**, int>)LpVtbl[7])(@this, riid, ppDevice);
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int GetDevice(Guid* riid, ref void* ppDevice)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (void** ppDevicePtr = &ppDevice)
            {
                ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, Guid*, void**, int>)LpVtbl[7])(@this, riid, ppDevicePtr);
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int GetDevice(ref Guid riid, void** ppDevice)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (Guid* riidPtr = &riid)
            {
                ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, Guid*, void**, int>)LpVtbl[7])(@this, riidPtr, ppDevice);
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int GetDevice(ref Guid riid, ref void* ppDevice)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (Guid* riidPtr = &riid)
            {
                fixed (void** ppDevicePtr = &ppDevice)
                {
                    ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, Guid*, void**, int>)LpVtbl[7])(@this, riidPtr, ppDevicePtr);
                }
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly int Present(uint SyncInterval, uint Flags)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, uint, uint, int>)LpVtbl[8])(@this, SyncInterval, Flags);
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int GetBuffer(uint Buffer, Guid* riid, void** ppSurface)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, uint, Guid*, void**, int>)LpVtbl[9])(@this, Buffer, riid, ppSurface);
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int GetBuffer(uint Buffer, Guid* riid, ref void* ppSurface)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (void** ppSurfacePtr = &ppSurface)
            {
                ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, uint, Guid*, void**, int>)LpVtbl[9])(@this, Buffer, riid, ppSurfacePtr);
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int GetBuffer(uint Buffer, ref Guid riid, void** ppSurface)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (Guid* riidPtr = &riid)
            {
                ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, uint, Guid*, void**, int>)LpVtbl[9])(@this, Buffer, riidPtr, ppSurface);
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int GetBuffer(uint Buffer, ref Guid riid, ref void* ppSurface)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (Guid* riidPtr = &riid)
            {
                fixed (void** ppSurfacePtr = &ppSurface)
                {
                    ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, uint, Guid*, void**, int>)LpVtbl[9])(@this, Buffer, riidPtr, ppSurfacePtr);
                }
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int SetFullscreenState(int Fullscreen, IDXGIOutput* pTarget)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, int, IDXGIOutput*, int>)LpVtbl[10])(@this, Fullscreen, pTarget);
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly int SetFullscreenState(int Fullscreen, ref IDXGIOutput pTarget)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (IDXGIOutput* pTargetPtr = &pTarget)
            {
                ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, int, IDXGIOutput*, int>)LpVtbl[10])(@this, Fullscreen, pTargetPtr);
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int GetFullscreenState(int* pFullscreen, IDXGIOutput** ppTarget)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, int*, IDXGIOutput**, int>)LpVtbl[11])(@this, pFullscreen, ppTarget);
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int GetFullscreenState(int* pFullscreen, ref IDXGIOutput* ppTarget)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (IDXGIOutput** ppTargetPtr = &ppTarget)
            {
                ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, int*, IDXGIOutput**, int>)LpVtbl[11])(@this, pFullscreen, ppTargetPtr);
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int GetFullscreenState(ref int pFullscreen, IDXGIOutput** ppTarget)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (int* pFullscreenPtr = &pFullscreen)
            {
                ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, int*, IDXGIOutput**, int>)LpVtbl[11])(@this, pFullscreenPtr, ppTarget);
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int GetFullscreenState(ref int pFullscreen, ref IDXGIOutput* ppTarget)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (int* pFullscreenPtr = &pFullscreen)
            {
                fixed (IDXGIOutput** ppTargetPtr = &ppTarget)
                {
                    ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, int*, IDXGIOutput**, int>)LpVtbl[11])(@this, pFullscreenPtr, ppTargetPtr);
                }
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int GetDesc(SwapChainDesc* pDesc)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, SwapChainDesc*, int>)LpVtbl[12])(@this, pDesc);
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly int GetDesc(ref SwapChainDesc pDesc)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (SwapChainDesc* pDescPtr = &pDesc)
            {
                ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, SwapChainDesc*, int>)LpVtbl[12])(@this, pDescPtr);
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly int ResizeBuffers(uint BufferCount, uint Width, uint Height, Silk.NET.DXGI.Format NewFormat, uint SwapChainFlags)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, uint, uint, uint, Silk.NET.DXGI.Format, uint, int>)LpVtbl[13])(@this, BufferCount, Width, Height, NewFormat, SwapChainFlags);
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int ResizeTarget(ModeDesc* pNewTargetParameters)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, ModeDesc*, int>)LpVtbl[14])(@this, pNewTargetParameters);
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly int ResizeTarget(ref ModeDesc pNewTargetParameters)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (ModeDesc* pNewTargetParametersPtr = &pNewTargetParameters)
            {
                ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, ModeDesc*, int>)LpVtbl[14])(@this, pNewTargetParametersPtr);
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int GetContainingOutput(IDXGIOutput** ppOutput)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, IDXGIOutput**, int>)LpVtbl[15])(@this, ppOutput);
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int GetContainingOutput(ref IDXGIOutput* ppOutput)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (IDXGIOutput** ppOutputPtr = &ppOutput)
            {
                ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, IDXGIOutput**, int>)LpVtbl[15])(@this, ppOutputPtr);
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int GetFrameStatistics(FrameStatistics* pStats)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, FrameStatistics*, int>)LpVtbl[16])(@this, pStats);
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly int GetFrameStatistics(ref FrameStatistics pStats)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (FrameStatistics* pStatsPtr = &pStats)
            {
                ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, FrameStatistics*, int>)LpVtbl[16])(@this, pStatsPtr);
            }
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly unsafe int GetLastPresentCount(uint* pLastPresentCount)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, uint*, int>)LpVtbl[17])(@this, pLastPresentCount);
            return ret;
        }

        /// <summary>To be documented.</summary>
        public readonly int GetLastPresentCount(ref uint pLastPresentCount)
        {
            var @this = (IDXGISwapChain*) Unsafe.AsPointer(ref Unsafe.AsRef(in this));
            int ret = default;
            fixed (uint* pLastPresentCountPtr = &pLastPresentCount)
            {
                ret = ((delegate* unmanaged[Cdecl]<IDXGISwapChain*, uint*, int>)LpVtbl[17])(@this, pLastPresentCountPtr);
            }
            return ret;
        }

    }
}
