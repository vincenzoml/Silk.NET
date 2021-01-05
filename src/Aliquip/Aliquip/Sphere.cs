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
    public enum SphereType
    {
        Stacked,
        Spiral
    }
    
    public sealed class Sphere : MovableSceneObject
    {
        public override IMaterial Material { get; }
        public override IModel Model { get; }

        private static readonly Dictionary<Vector3, SpiralSphereModel> _spirals = new();
        private static readonly Dictionary<Vector3, StackedSphereModel> _stackeds = new();
        
        public Sphere(Vector3 color, SphereType type, Vk vk, IResourceProvider resourceProvider, ILogicalDeviceProvider logicalDeviceProvider, IAllocationCallbacksProvider allocationCallbacksProvider) : base()
        {
            Material = Simple3DMaterial.Create(vk, resourceProvider, logicalDeviceProvider, allocationCallbacksProvider);

            if (type == SphereType.Stacked)
            {
                if (!_stackeds.TryGetValue(color, out var model))
                {
                    model = new StackedSphereModel(color);
                    _stackeds[color] = model;
                }

                Model = model;
            }
            else if (type == SphereType.Spiral)
            {
                if (!_spirals.TryGetValue(color, out var model))
                {
                    model = new SpiralSphereModel(color);
                    _spirals[color] = model;
                }

                Model = model;
            }
        }

        private const int QualityFactor = 8;
        private sealed class StackedSphereModel : IModel
        {
            public int VertexCount => Vertices.Length;
            public unsafe int VertexSize => sizeof(Vertex);
            public int IndexCount => Indices.Length;

            public Vertex[] Vertices { get; }

            public uint[] Indices { get; }
            
            ReadOnlySpan<byte> IModel.Vertices => MemoryMarshal.Cast<Vertex, byte>(Vertices.AsSpan());

            ReadOnlySpan<uint> IModel.Indices => Indices;

            public StackedSphereModel(Vector3 color, int stacks = 8 * QualityFactor, int slices = 16 * QualityFactor, float radius = 1)
            {
                var vertices = new List<Vertex>();
                var indices = new List<uint>();

                for (int stackNumber = 0; stackNumber < stacks; stackNumber++)
                {
                    for (int sliceNumber = 0; sliceNumber <= slices; sliceNumber++)
                    {
                        float theta = stackNumber * MathF.PI / stacks;
                        float phi = sliceNumber * 2 * MathF.PI / slices;
                        float sinTheta = MathF.Sin(theta);
                        float sinPhi = MathF.Sin(phi);
                        float cosTheta = MathF.Cos(theta);
                        float cosPhi = MathF.Cos(phi);
                        
                        vertices.Add(new Vertex(
                            position: new(radius * cosPhi * sinTheta, radius * sinPhi * sinTheta, radius * cosTheta),
                            color: color,
                            textureCoordinate: Vector2D<float>.Zero));
                        
                        indices.Add((uint) (stackNumber * slices + sliceNumber % slices));
                        indices.Add((uint) ((stackNumber + 1) * slices + sliceNumber % slices));
                    }
                }

                Vertices = vertices.ToArray();
                Indices = indices.ToArray();
            }
        }
        
        private sealed class SpiralSphereModel : IModel
        {
            public int VertexCount => Vertices.Length;
            public unsafe int VertexSize => sizeof(Vertex);
            public int IndexCount => Indices.Length;

            public Vertex[] Vertices { get; }

            public uint[] Indices { get; }
            
            ReadOnlySpan<byte> IModel.Vertices => MemoryMarshal.Cast<Vertex, byte>(Vertices.AsSpan());

            ReadOnlySpan<uint> IModel.Indices => Indices;
            
            public SpiralSphereModel(Vector3 color, int loops = 8 * QualityFactor, int segmentsPerLoop = 16 * QualityFactor, float radius = 1)
            {
                var vertices = new List<Vertex>();
                var indices = new List<uint>();

                for (int loopSegmentNumber = 0; loopSegmentNumber < segmentsPerLoop; loopSegmentNumber++)
                {
                    float theta = 0;
                    float phi = loopSegmentNumber * 2 * MathF.PI / segmentsPerLoop;
                    float sinTheta = MathF.Sin(theta);
                    float sinPhi = MathF.Sin(phi);
                    float cosTheta = MathF.Cos(theta);
                    float cosPhi = MathF.Cos(phi);
                    
                    vertices.Add(new Vertex(
                        position: new(radius * cosPhi * sinTheta, radius * sinPhi * sinTheta, radius * cosTheta),
                        color: color,
                        textureCoordinate: Vector2D<float>.Zero));
                }
                
                for (int loopNumber = 0; loopNumber <= loops; loopNumber++)
                {
                    for (int loopSegmentNumber = 0; loopSegmentNumber < segmentsPerLoop; loopSegmentNumber++)
                    {
                        float theta = loopNumber * MathF.PI / loops + MathF.PI * loopSegmentNumber / (segmentsPerLoop * loops);
                        if (loopNumber == loops)
                            theta = MathF.PI;
                        float phi = loopSegmentNumber * 2 * MathF.PI / segmentsPerLoop;
                        float sinTheta = MathF.Sin(theta);
                        float sinPhi = MathF.Sin(phi);
                        float cosTheta = MathF.Cos(theta);
                        float cosPhi = MathF.Cos(phi);

                        vertices.Add
                        (
                            new Vertex
                            (
                                position: new
                                    (radius * cosPhi * sinTheta, radius * sinPhi * sinTheta, radius * cosTheta),
                                color: color, textureCoordinate: Vector2D<float>.Zero
                            )
                        );
                    }
                }

                for (int loopSegmentNumber = 0; loopSegmentNumber < segmentsPerLoop; loopSegmentNumber++)
                {
                    indices.Add((uint) loopSegmentNumber);
                    indices.Add((uint) (segmentsPerLoop + loopSegmentNumber));
                }

                for (int loopNumber = 0; loopNumber < loops; loopNumber++)
                {
                    for (int loopSegmentNumber = 0; loopSegmentNumber < segmentsPerLoop; loopSegmentNumber++)
                    {
                        indices.Add((uint) (((loopNumber + 1) * segmentsPerLoop) + loopSegmentNumber));
                        indices.Add((uint) (((loopNumber + 2) * segmentsPerLoop) + loopSegmentNumber));
                    }
                }

                Vertices = vertices.ToArray();
                Indices = indices.ToArray();
            }
        }
    }
}
