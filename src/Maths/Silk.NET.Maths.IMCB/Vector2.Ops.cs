// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Numerics;

namespace Silk.NET.Maths
{
    public static class Vector2
    {
        public static Vector2<T> Add<T>(Vector2<T> a, Vector2<T> b) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector2<T> Subtract<T>(Vector2<T> a, Vector2<T> b) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector2<T> Multiply<T>(Vector2<T> vector, T scale) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector2<T> Multiply<T>(Vector2<T> vector, Vector2<T> scale) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector2<T> Divide<T>(Vector2<T> vector, T scale) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector2<T> Divide<T>(Vector2<T> vector, Vector2<T> scale) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector2<T> ComponentMin<T>(Vector2<T> a, Vector2<T> b) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector2<T> ComponentMax<T>(Vector2<T> a, Vector2<T> b) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector2<T> MagnitudeMin<T>(Vector2<T> left, Vector2<T> right) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector2<T> MagnitudeMax<T>(Vector2<T> left, Vector2<T> right) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector2<T> Clamp<T>(Vector2<T> vec, Vector2<T> min, Vector2<T> max) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static T Distance<T>(Vector2<T> vec1, Vector2<T> vec2) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static T DistanceSquared<T>(Vector2<T> vec1, Vector2<T> vec2) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector2<T> Normalize<T>(Vector2<T> vec) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static T Dot<T>(Vector2<T> left, Vector2<T> right) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static T PerpDot<T>(Vector2<T> left, Vector2<T> right) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector2<T> Lerp<T>(Vector2<T> a, Vector2<T> b, T blend) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector2<T> BaryCentric<T>(Vector2<T> a, Vector2<T> b, Vector2<T> c, T u, T v) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector2<T> Transform<T>(Vector2<T> vec, Matrix2<T> mat) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector2<T> TransformColumn<T>(Vector2<T> vec, Matrix2<T> mat) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector2<T> Transform<T>(Vector2<T> vec, Quaternion<T> quat) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector2<T> Transform<T>(Matrix2<T> mat, Vector2<T> vec) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector2<T> TransformColumn<T>(Matrix2<T> mat, Vector2<T> vec) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Vector2<T> Negate<T>(Vector2<T> vec) where T:unmanaged => vec * Vector2<T>.MinusOne;
    }
}
