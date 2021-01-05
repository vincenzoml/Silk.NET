// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System.Numerics;
using Silk.NET.Maths;

namespace Aliquip
{
    public abstract class MovableSceneObject : ISceneObject
    {
        public abstract IMaterial Material { get; }
        public abstract IModel Model { get; }

        public Matrix4x4 WorldToLocal
        {
            get
            {
                var t = Matrix4x4.CreateTranslation(Position);
                var r = Matrix4x4.CreateFromQuaternion(Rotation);
                var s = Matrix4x4.CreateScale(Scale);
                return t * r * s;
            }
        }

        public Vector3 Position { get; set; } = Vector3.Zero;
        public Quaternion Rotation { get; set; } = Quaternion.Identity;
        public Vector3 Scale { get; set; } = Vector3.One;

    }
}
