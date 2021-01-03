// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Runtime.InteropServices;
using Silk.NET.Maths;
using Silk.NET.Vulkan;

namespace Aliquip
{
    public sealed class Quad : MovableSceneObject
    {
        public override IMaterial Material { get; }
        public override IModel Model => _model;

        public Quad(Vk vk, IResourceProvider resourceProvider, ILogicalDeviceProvider logicalDeviceProvider) : base()
        {
            Material = Simple3DMaterial.Create(vk, resourceProvider, logicalDeviceProvider);
        }

        private static readonly QuadModel _model = new();
        private sealed class QuadModel : IModel
        {
            public int VertexCount => Vertices.Length;
            public unsafe int VertexSize => sizeof(Vertex);
            public int IndexCount => Indices.Length;

            public Vertex[] Vertices { get; } =
            {
                new(new(-0.5f, -0.5f, 0.0f), new(1.0f, 0.0f, 0.0f), new(1.0f, 0.0f)),
                new(new(0.5f, -0.5f, 0.0f), new(0.0f, 1.0f, 0.0f), new(0.0f, 0.0f)),
                new(new(0.5f, 0.5f, 0.0f), new(0.0f, 0.0f, 1.0f), new(0.0f, 1.0f)),
                new(new(-0.5f, 0.5f, 0.0f), new(1.0f, 1.0f, 1.0f), new(1.0f, 1.0f)),
            
                // new(new(-0.5f, -0.5f, -0.5f), new(1.0f, 0.0f, 0.0f), new(1.0f, 0.0f)),
                // new(new(0.5f, -0.5f, -0.5f), new(0.0f, 1.0f, 0.0f), new(0.0f, 0.0f)),
                // new(new(0.5f, 0.5f, -0.5f), new(0.0f, 0.0f, 1.0f), new(0.0f, 1.0f)),
                // new(new(-0.5f, 0.5f, -0.5f), new(1.0f, 1.0f, 1.0f), new(1.0f, 1.0f)),
            };

            public uint[] Indices { get; } =
            {
                0, 1, 2, 2, 3, 0,
                // 4, 5, 6, 6, 7, 4
            };

            ReadOnlySpan<byte> IModel.Vertices => MemoryMarshal.Cast<Vertex, byte>(Vertices.AsSpan());

            ReadOnlySpan<uint> IModel.Indices => Indices;
        }
    }
}
