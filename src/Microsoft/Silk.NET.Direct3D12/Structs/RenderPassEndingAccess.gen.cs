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
    [NativeName("Name", "D3D12_RENDER_PASS_ENDING_ACCESS")]
    public unsafe partial struct RenderPassEndingAccess
    {
        public RenderPassEndingAccess
        (
            RenderPassEndingAccessType? type = null,
            RenderPassEndingAccessUnion? anonymous = null,
            RenderPassEndingAccessResolveParameters? resolve = null
        ) : this()
        {
            if (type is not null)
            {
                Type = type.Value;
            }

            if (anonymous is not null)
            {
                Anonymous = anonymous.Value;
            }

            if (resolve is not null)
            {
                Resolve = resolve.Value;
            }
        }


        [NativeName("Type", "D3D12_RENDER_PASS_ENDING_ACCESS_TYPE")]
        [NativeName("Type.Name", "D3D12_RENDER_PASS_ENDING_ACCESS_TYPE")]
        [NativeName("Name", "Type")]
        public RenderPassEndingAccessType Type;

        [NativeName("Type", "")]
        [NativeName("Type.Name", "__AnonymousRecord_d3d12_L17477_C5")]
        [NativeName("Name", "anonymous1")]
        public RenderPassEndingAccessUnion Anonymous;
#if NETSTANDARD2_1
        public ref RenderPassEndingAccessResolveParameters Resolve
        {
            [MethodImpl((MethodImplOptions) 768)]
            get => ref Anonymous.Resolve;
        }
#else
        public RenderPassEndingAccessResolveParameters Resolve
        {
            get => Anonymous.Resolve;
            set => Anonymous.Resolve = value;
        }
#endif

    }
}
