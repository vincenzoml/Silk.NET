// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using Silk.NET.Maths;
using Silk.NET.Vulkan;

namespace Aliquip
{
    public sealed class Cube : MovableSceneObject
    {
        public override IMaterial Material { get; }
        public override IModel Model { get; }

        private static readonly Dictionary<Vector3, CubeModel> _models = new();
        
        public Cube(Vector3 color, Vk vk, IResourceProvider resourceProvider, ILogicalDeviceProvider logicalDeviceProvider, IAllocationCallbacksProvider allocationCallbacksProvider) : base()
        {
            Material = Simple3DMaterial.Create(vk, resourceProvider, logicalDeviceProvider, allocationCallbacksProvider);

            if (!_models.TryGetValue(color, out var model))
            {
                model = new CubeModel(color);
                _models[color] = model;
            }

            Model = model;
        }

        private sealed class CubeModel : IModel
        {
            public int VertexCount => Vertices.Length;
            public unsafe int VertexSize => sizeof(Vertex);
            public int IndexCount => Indices.Length;

            public Vertex[] Vertices { get; }

            public uint[] Indices { get; }

            ReadOnlySpan<byte> IModel.Vertices => MemoryMarshal.Cast<Vertex, byte>(Vertices.AsSpan());

            ReadOnlySpan<uint> IModel.Indices => Indices;

            public CubeModel(Vector3 color)
            {
                /*
http://www.asmcommunity.net/forums/topic/?id=6284.
; 1-------3-------4-------2 Cube = 8 vertices ; | E __/|\__ A | H __/| =================
; | __/ | \__ | __/ | Single Strip: 4 3 7 8 5 3 1 4 2 7 6 5 2 1
; |/ D | B \|/ I | 12 triangles: A B C D E F G H I J K L
; 5-------8-------7-------6
; | C __/|
; | __/ |
; |/ J |
; 5-------6
; |\__ K |
; | \__ |
; | L \| Left D+E
; 1-------2 Right H+I
; |\__ G | Back K+L
; | \__ | Front A+B
; | F \| Top F+G
; 3-------4 Bottom C+J
;
D3DXVECTOR3 \
{ 0.5, 0.5, 0.5 }, ;4
{ -0.5, 0.5, 0.5 }, ;3
{ 0.5,-0.5, 0.5 }, ;7 A front
{ -0.5,-0.5, 0.5 }, ;8 B front
{ -0.5,-0.5,-0.5 }, ;5 C bottom
{ -0.5, 0.5, 0.5 }, ;3 D right
{ -0.5, 0.5,-0.5 }, ;1 E right
{ 0.5, 0.5, 0.5 }, ;4 F top
{ 0.5, 0.5,-0.5 }, ;2 G top
{ 0.5,-0.5, 0.5 }, ;7 H left
{ 0.5,-0.5,-0.5 }, ;6 I left
{ -0.5,-0.5,-0.5 }, ;5 J bottom
{ 0.5, 0.5,-0.5 }, ;2 K back { -0.5, 0.5,-0.5 } ;1 L back
                 */
                Vertices = new Vertex[]
                {
                    new (new(-0.5f, 0.5f, -0.5f), color, new(0, 0.66f)),
                    new (new(0.5f, 0.5f, -0.5f), color, new(0, 0.33f)),
                    new (new(-0.5f, 0.5f, 0.5f), color, new(0.75f, 0.66f)),
                    new (new(0.5f, 0.5f, 0.5f), color, new(0.75f, 0.66f)),
                    new (new(-0.5f, -0.5f, -0.5f), color, new(0.25f, 0.66f)),
                    new (new(0.5f, -0.5f, -0.5f), color, new(0.25f, 0.33f)),
                    new (new(0.5f, -0.5f, 0.5f), color, new(0.5f, 0.33f)),
                    new (new(-0.5f, -0.5f, 0.5f), color, new(0.5f, 0.66f)),
                };

                Indices = new uint[]
                {
                    3, 2, 6, 7, 4, 2, 0, 3, 1, 6, 5, 4, 1, 0
                };
            }
        }
    }
}
