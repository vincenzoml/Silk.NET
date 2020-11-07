// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;

namespace Silk.NET.Maths
{
    public static class Vector3
    {
        public static Vector3<T> Add<T>(Vector3<T> a, Vector3<T> b) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector3<T> Subtract<T>(Vector3<T> a, Vector3<T> b) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector3<T> Multiply<T>(Vector3<T> vector, T scale) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector3<T> Multiply<T>(Vector3<T> vector, Vector3<T> scale) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector3<T> Divide<T>(Vector3<T> vector, T scale) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector3<T> Divide<T>(Vector3<T> vector, Vector3<T> scale) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector3<T> ComponentMin<T>(Vector3<T> a, Vector3<T> b) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector3<T> ComponentMax<T>(Vector3<T> a, Vector3<T> b) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector3<T> MagnitudeMin<T>(Vector3<T> left, Vector3<T> right) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector3<T> MagnitudeMax<T>(Vector3<T> left, Vector3<T> right) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector3<T> Clamp<T>(Vector3<T> vec, Vector3<T> min, Vector3<T> max) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static T Distance<T>(Vector3<T> vec1, Vector3<T> vec2) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static T DistanceSquared<T>(Vector3<T> vec1, Vector3<T> vec2) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector3<T> Normalize<T>(Vector3<T> vec) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static T Dot<T>(Vector3<T> left, Vector3<T> right) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector3<T> Cross<T>(Vector3<T> left, Vector3<T> right) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector3<T> Lerp<T>(Vector3<T> a, Vector3<T> b, T blend) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector3<T> BaryCentric<T>(Vector3<T> a, Vector3<T> b, Vector3<T> c, T u, T v) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector3<T> TransformVector<T>(Vector3<T> vec, Matrix4<T> mat) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector3<T> TransformNormal<T>(Vector3<T> norm, Matrix4<T> mat) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector3<T> TransformNormalInverse<T>(Vector3<T> norm, Matrix4<T> invMat) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector3<T> TransformPosition<T>(Vector3<T> pos, Matrix4<T> mat) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector3<T> Transform<T>(Vector3<T> vec, Matrix3<T> mat) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector3<T> TransformColumn<T>(Vector3<T> vec, Matrix3<T> mat) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector3<T> Transform<T>(Vector3<T> vec, Quaternion<T> quat) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector3<T> Transform<T>(Matrix3<T> mat, Vector3<T> vec) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector3<T> TransformColumn<T>(Matrix3<T> mat, Vector3<T> vec) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector3<T> TransformPerspective<T>(Vector3<T> vec, Matrix4<T> mat) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static T CalculateAngle<T>(Vector3<T> first, Vector3<T> second) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector3<T> Project<T>
        (
            Vector3<T> vector,
            T x,
            T y,
            T width,
            T height,
            T minZ,
            T maxZ,
            Matrix4<T> worldViewProjection
        ) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector3<T> Unproject<T>
        (
            Vector3<T> vector,
            T x,
            T y,
            T width,
            T height,
            T minZ,
            T maxZ,
            Matrix4<T> inverseWorldViewProjection
        ) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector3<T> Negate<T>(Vector3<T> vec) where T : unmanaged => Multiply(vec, Vector3<T>.MinusOne);
    }
}
