// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;

namespace Silk.NET.Maths
{
    public static class Vector4
    {
        public static Vector4<T> Add<T>(Vector4<T> a, Vector4<T> b) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector4<T> Subtract<T>(Vector4<T> a, Vector4<T> b) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector4<T> Multiply<T>(Vector4<T> vector, T scale) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector4<T> Multiply<T>(Vector4<T> vector, Vector4<T> scale) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector4<T> Divide<T>(Vector4<T> vector, T scale) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector4<T> Divide<T>(Vector4<T> vector, Vector4<T> scale) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector4<T> ComponentMin<T>(Vector4<T> a, Vector4<T> b) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector4<T> ComponentMax<T>(Vector4<T> a, Vector4<T> b) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector4<T> MagnitudeMin<T>(Vector4<T> left, Vector4<T> right) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector4<T> MagnitudeMax<T>(Vector4<T> left, Vector4<T> right) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector4<T> Clamp<T>(Vector4<T> vec, Vector4<T> min, Vector4<T> max) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector4<T> Normalize<T>(Vector4<T> vec) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static T Dot<T>(Vector4<T> left, Vector4<T> right) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector4<T> Lerp<T>(Vector4<T> a, Vector4<T> b, T blend) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector4<T> BaryCentric<T>(Vector4<T> a, Vector4<T> b, Vector4<T> c, T u, T v) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector4<T> Transform<T>(Vector4<T> vec, Matrix4<T> mat) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector4<T> TransformColumn<T>(Vector4<T> vec, Matrix4<T> mat) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector4<T> Transform<T>(Vector4<T> vec, Quaternion<T> quat) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector4<T> Transform<T>(Matrix4<T> mat, Vector4<T> vec) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector4<T> TransformColumn<T>(Matrix4<T> mat, Vector4<T> vec) where T:unmanaged
        {
            throw new NotImplementedException();
        }
        
        public static Vector4<T> Negate<T>(Vector4<T> vec) where T:unmanaged => Multiply(vec, Vector4<T>.MinusOne);
    }
}
