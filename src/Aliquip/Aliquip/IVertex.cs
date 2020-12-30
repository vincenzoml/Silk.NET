// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System.Runtime.InteropServices;
using Silk.NET.Maths;
using Silk.NET.Vulkan;

namespace Aliquip
{
    [StructLayout(LayoutKind.Explicit, Size = sizeof(float) * 5)]
    public struct Vertex
    {
        private const int PositionOffset = 0;
        [FieldOffset(PositionOffset)]
        public Vector3D<float> Position;
        private const int ColorOffset = sizeof(float) * 3;
        [FieldOffset(ColorOffset)]
        public Vector3D<float> Color;
        private const int TextureCoordinateOffset = sizeof(float) * 6;
        [FieldOffset(TextureCoordinateOffset)] 
        public Vector2D<float> TextureCoordinate;

        public Vertex(Vector3D<float> position, Vector3D<float> color, Vector2D<float> textureCoordinate)
        {
            Position = position;
            Color = color;
            TextureCoordinate = textureCoordinate;
        }

        public static VertexInputAttributeDescription[] AttributeDescriptions
        {
            get
            {
                var attributeDescriptions = new VertexInputAttributeDescription[3];

                attributeDescriptions[0].Binding = 0;
                attributeDescriptions[0].Location = 0;
                attributeDescriptions[0].Format = Format.R32G32B32Sfloat;
                attributeDescriptions[0].Offset = PositionOffset;

                attributeDescriptions[1].Binding = 0;
                attributeDescriptions[1].Location = 1;
                attributeDescriptions[1].Format = Format.R32G32B32Sfloat;
                attributeDescriptions[1].Offset = ColorOffset;
                    
                attributeDescriptions[2].Binding = 0;
                attributeDescriptions[2].Location = 2;
                attributeDescriptions[2].Format = Format.R32G32Sfloat;
                attributeDescriptions[2].Offset = TextureCoordinateOffset;

                return attributeDescriptions;
            }
        }
    }
}
