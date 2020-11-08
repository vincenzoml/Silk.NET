// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;

namespace Silk.NET.Maths
{
    public static class Matrix2x3
    {
        public static Matrix2x3<T> CreateRotation<T>(T angle) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Matrix2x3<T> CreateScale<T>(T scale) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Matrix2x3<T> CreateScale<T>(Vector2<T> scale) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Matrix2x3<T> CreateScale<T>(T x, T y) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Matrix2x3<T> Multiply<T>(Matrix2x3<T> left, T right) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Matrix2<T> Multiply<T>(Matrix2x3<T> left, Matrix3x2<T> right) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Matrix2x3<T> Multiply<T>(Matrix2x3<T> left, Matrix3<T> right) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Matrix2x4<T> Multiply<T>(Matrix2x3<T> left, Matrix3x4<T> right) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Matrix2x3<T> Add<T>(Matrix2x3<T> left, Matrix2x3<T> right) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Matrix2x3<T> Subtract<T>(Matrix2x3<T> left, Matrix2x3<T> right) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Matrix3x2<T> Transpose<T>(Matrix2x3<T> mat) where T:unmanaged
        {
            throw new NotImplementedException();
        }
    }
}
