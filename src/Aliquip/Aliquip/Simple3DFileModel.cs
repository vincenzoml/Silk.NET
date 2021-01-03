// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Numerics;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;
using ObjLoader.Loader.Loaders;
using Silk.NET.Maths;

namespace Aliquip
{
    internal sealed class Simple3DFileModel : IModel
    {
        private static readonly Dictionary<string, Simple3DFileModel> _cache = new();

        public static Simple3DFileModel Create(string filePath, ILogger<Simple3DFileModel> logger)
        {
            if (_cache.TryGetValue(filePath, out var v))
                return v;

            v = new Simple3DFileModel(filePath, logger);
            _cache[filePath] = v;
            return v;
        }
        
        public int VertexCount => Vertices.Length;
        public unsafe int VertexSize => sizeof(Vertex);
        public int IndexCount => Indices.Length;

        ReadOnlySpan<byte> IModel.Vertices => MemoryMarshal.Cast<Vertex, byte>(Vertices.AsSpan());

        ReadOnlySpan<uint> IModel.Indices => Indices;

        public Vertex[] Vertices { get; }

        public uint[] Indices { get; }

        private Simple3DFileModel(string filePath, ILogger<Simple3DFileModel> logger)
        {
            var objLoaderFactory = new ObjLoaderFactory();
            var objLoader = objLoaderFactory.Create(new MaterialNullStreamProvider());
            using var stream = File.OpenRead(filePath);
            var result = objLoader.Load(stream);

            var vertices = new List<Vertex>();
            var indices = new List<uint>();
            foreach (var group in result.Groups)
            {
                foreach (var face in group.Faces)
                {
                    for (int i = 0; i < face.Count; i++)
                    {
                        try
                        {
                            var pos = result.Vertices[face[i].VertexIndex - 1];
                            var texture = result.Textures[face[i].TextureIndex - 1];
                            vertices.Add
                            (
                                new Vertex
                                (
                                    new Vector3D<float>(pos.X, pos.Y, pos.Z), new Vector3D<float>(1, 1, 1),
                                    new Vector2D<float>(texture.X, 1.0f - texture.Y)
                                )
                            );
                            indices.Add((uint) indices.Count);
                        }
                        catch (Exception ex)
                        {
                            Debugger.Break();
                            throw;
                        }
                    }
                }
            }

            Vertices = vertices.ToArray();
            Indices = indices.ToArray();
            logger.LogInformation("Loaded Model. {vertices} vertices and {indices} indices.", vertices.Count, indices.Count);
        }
    }
}
