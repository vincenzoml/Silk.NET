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
    [StructLayout(LayoutKind.Explicit)]
    [NativeName("Name", "__AnonymousRecord_d3d12_L3951_C5")]
    public unsafe partial struct IndirectArgumentDescUnion
    {
        public IndirectArgumentDescUnion
        (
            IndirectArgumentDescUnionVertexBuffer? vertexBuffer = null,
            IndirectArgumentDescUnionConstant? constant = null,
            IndirectArgumentDescUnionConstantBufferView? constantBufferView = null,
            IndirectArgumentDescUnionShaderResourceView? shaderResourceView = null,
            IndirectArgumentDescUnionUnorderedAccessView? unorderedAccessView = null
        ) : this()
        {
            if (vertexBuffer is not null)
            {
                VertexBuffer = vertexBuffer.Value;
            }

            if (constant is not null)
            {
                Constant = constant.Value;
            }

            if (constantBufferView is not null)
            {
                ConstantBufferView = constantBufferView.Value;
            }

            if (shaderResourceView is not null)
            {
                ShaderResourceView = shaderResourceView.Value;
            }

            if (unorderedAccessView is not null)
            {
                UnorderedAccessView = unorderedAccessView.Value;
            }
        }


        [FieldOffset(0)]
        [NativeName("Type", "struct (anonymous struct at d3d12.h:3953:9)")]
        [NativeName("Type.Name", "struct (anonymous struct at d3d12.h:3953:9)")]
        [NativeName("Name", "VertexBuffer")]
        public IndirectArgumentDescUnionVertexBuffer VertexBuffer;

        [FieldOffset(0)]
        [NativeName("Type", "struct (anonymous struct at d3d12.h:3957:9)")]
        [NativeName("Type.Name", "struct (anonymous struct at d3d12.h:3957:9)")]
        [NativeName("Name", "Constant")]
        public IndirectArgumentDescUnionConstant Constant;

        [FieldOffset(0)]
        [NativeName("Type", "struct (anonymous struct at d3d12.h:3963:9)")]
        [NativeName("Type.Name", "struct (anonymous struct at d3d12.h:3963:9)")]
        [NativeName("Name", "ConstantBufferView")]
        public IndirectArgumentDescUnionConstantBufferView ConstantBufferView;

        [FieldOffset(0)]
        [NativeName("Type", "struct (anonymous struct at d3d12.h:3967:9)")]
        [NativeName("Type.Name", "struct (anonymous struct at d3d12.h:3967:9)")]
        [NativeName("Name", "ShaderResourceView")]
        public IndirectArgumentDescUnionShaderResourceView ShaderResourceView;

        [FieldOffset(0)]
        [NativeName("Type", "struct (anonymous struct at d3d12.h:3971:9)")]
        [NativeName("Type.Name", "struct (anonymous struct at d3d12.h:3971:9)")]
        [NativeName("Name", "UnorderedAccessView")]
        public IndirectArgumentDescUnionUnorderedAccessView UnorderedAccessView;
    }
}
