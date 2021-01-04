// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Silk.NET.Maths;
using Silk.NET.Vulkan;

namespace Aliquip
{
    public sealed class Quad : MovableSceneObject
    {
        public override IMaterial Material { get; }
        public override IModel Model { get; }

        private static readonly Dictionary<Vector3D<float>, QuadModel> _models = new();
        
        public Quad(Vector3D<float> color, Vk vk, IResourceProvider resourceProvider, ILogicalDeviceProvider logicalDeviceProvider, IAllocationCallbacksProvider allocationCallbacksProvider) : base()
        {
            Material = Simple3DMaterial.Create(vk, resourceProvider, logicalDeviceProvider, allocationCallbacksProvider);

            if (!_models.TryGetValue(color, out var model))
            {
                model = new QuadModel(color);
                _models[color] = model;
            }

            Model = model;
        }

        private sealed class QuadModel : IModel
        {
            public int VertexCount => Vertices.Length;
            public unsafe int VertexSize => sizeof(Vertex);
            public int IndexCount => Indices.Length;

            public Vertex[] Vertices { get; }

            public uint[] Indices { get; } =
            {
                0, 1, 2, 3
            };

            ReadOnlySpan<byte> IModel.Vertices => MemoryMarshal.Cast<Vertex, byte>(Vertices.AsSpan());

            ReadOnlySpan<uint> IModel.Indices => Indices;

            public QuadModel(Vector3D<float> color)
            {
                Vertices = new Vertex[]
                {
                    new(new(-0.5f, -0.5f, 0.0f), color, new(1.0f, 0.0f)),
                    new(new(0.5f, -0.5f, 0.0f), color, new(0.0f, 0.0f)),
                    new(new(-0.5f, 0.5f, 0.0f), color, new(1.0f, 1.0f)),
                    new(new(0.5f, 0.5f, 0.0f), color, new(0.0f, 1.0f)),
                };
            }
        }
    }
}
