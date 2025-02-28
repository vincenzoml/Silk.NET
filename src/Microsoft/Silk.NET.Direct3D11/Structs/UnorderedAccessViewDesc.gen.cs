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

namespace Silk.NET.Direct3D11
{
    [NativeName("Name", "D3D11_UNORDERED_ACCESS_VIEW_DESC")]
    public unsafe partial struct UnorderedAccessViewDesc
    {
        public UnorderedAccessViewDesc
        (
            Silk.NET.DXGI.Format? format = null,
            UavDimension? viewDimension = null,
            UnorderedAccessViewDescUnion? anonymous = null,
            BufferUav? buffer = null,
            Tex1DUav? texture1D = null,
            Tex1DArrayUav? texture1DArray = null,
            Tex2DUav? texture2D = null,
            Tex2DArrayUav? texture2DArray = null,
            Tex3DUav? texture3D = null
        ) : this()
        {
            if (format is not null)
            {
                Format = format.Value;
            }

            if (viewDimension is not null)
            {
                ViewDimension = viewDimension.Value;
            }

            if (anonymous is not null)
            {
                Anonymous = anonymous.Value;
            }

            if (buffer is not null)
            {
                Buffer = buffer.Value;
            }

            if (texture1D is not null)
            {
                Texture1D = texture1D.Value;
            }

            if (texture1DArray is not null)
            {
                Texture1DArray = texture1DArray.Value;
            }

            if (texture2D is not null)
            {
                Texture2D = texture2D.Value;
            }

            if (texture2DArray is not null)
            {
                Texture2DArray = texture2DArray.Value;
            }

            if (texture3D is not null)
            {
                Texture3D = texture3D.Value;
            }
        }


        [NativeName("Type", "DXGI_FORMAT")]
        [NativeName("Type.Name", "DXGI_FORMAT")]
        [NativeName("Name", "Format")]
        public Silk.NET.DXGI.Format Format;

        [NativeName("Type", "D3D11_UAV_DIMENSION")]
        [NativeName("Type.Name", "D3D11_UAV_DIMENSION")]
        [NativeName("Name", "ViewDimension")]
        public UavDimension ViewDimension;

        [NativeName("Type", "")]
        [NativeName("Type.Name", "__AnonymousRecord_d3d11_L4635_C5")]
        [NativeName("Name", "anonymous1")]
        public UnorderedAccessViewDescUnion Anonymous;
#if NETSTANDARD2_1
        public ref BufferUav Buffer
        {
            [MethodImpl((MethodImplOptions) 768)]
            get => ref Anonymous.Buffer;
        }
#else
        public BufferUav Buffer
        {
            get => Anonymous.Buffer;
            set => Anonymous.Buffer = value;
        }
#endif

#if NETSTANDARD2_1
        public ref Tex1DUav Texture1D
        {
            [MethodImpl((MethodImplOptions) 768)]
            get => ref Anonymous.Texture1D;
        }
#else
        public Tex1DUav Texture1D
        {
            get => Anonymous.Texture1D;
            set => Anonymous.Texture1D = value;
        }
#endif

#if NETSTANDARD2_1
        public ref Tex1DArrayUav Texture1DArray
        {
            [MethodImpl((MethodImplOptions) 768)]
            get => ref Anonymous.Texture1DArray;
        }
#else
        public Tex1DArrayUav Texture1DArray
        {
            get => Anonymous.Texture1DArray;
            set => Anonymous.Texture1DArray = value;
        }
#endif

#if NETSTANDARD2_1
        public ref Tex2DUav Texture2D
        {
            [MethodImpl((MethodImplOptions) 768)]
            get => ref Anonymous.Texture2D;
        }
#else
        public Tex2DUav Texture2D
        {
            get => Anonymous.Texture2D;
            set => Anonymous.Texture2D = value;
        }
#endif

#if NETSTANDARD2_1
        public ref Tex2DArrayUav Texture2DArray
        {
            [MethodImpl((MethodImplOptions) 768)]
            get => ref Anonymous.Texture2DArray;
        }
#else
        public Tex2DArrayUav Texture2DArray
        {
            get => Anonymous.Texture2DArray;
            set => Anonymous.Texture2DArray = value;
        }
#endif

#if NETSTANDARD2_1
        public ref Tex3DUav Texture3D
        {
            [MethodImpl((MethodImplOptions) 768)]
            get => ref Anonymous.Texture3D;
        }
#else
        public Tex3DUav Texture3D
        {
            get => Anonymous.Texture3D;
            set => Anonymous.Texture3D = value;
        }
#endif

    }
}
