// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using Silk.NET.Maths;

namespace Aliquip
{
    public abstract class MovableSceneObject : ISceneObject
    {
        public abstract IMaterial Material { get; }
        public abstract IModel Model { get; }

        public Matrix4X4<float> WorldToLocal
        {
            get
            {
                var t = Matrix4X4.CreateTranslation(Position);
                var r = Matrix4X4.CreateFromQuaternion(Rotation);
                var s = Matrix4X4.CreateScale(Scale);
                return t * r * s;
            }
        }

        public Vector3D<float> Position { get; set; } = Vector3D<float>.Zero;
        public Quaternion<float> Rotation { get; set; } = Quaternion<float>.Identity;
        public Vector3D<float> Scale { get; set; } = Vector3D<float>.One;

    }
}
