// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;

namespace Silk.NET.Maths
{
    public static class Matrix3
    {
        public static Matrix3<T> Normalize<T>(Matrix3<T> mat) where T : unmanaged
        {
            throw new NotImplementedException();
        }
        
        public static Matrix3<T> CreateFromAxisAngle<T>(Vector3<T> axis, T angle) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Matrix3<T> CreateFromQuaternion<T>(Quaternion<T> q) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Matrix3<T> CreateRotationX<T>(T angle) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Matrix3<T> CreateRotationY<T>(T angle) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Matrix3<T> CreateRotationZ<T>(T angle) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Matrix3<T> CreateScale<T>(T scale) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Matrix3<T> CreateScale<T>(Vector3<T> scale) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Matrix3<T> CreateScale<T>(T x, T y, T z) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static void CreateScale<T>(T x, T y, T z, out Matrix3<T> result) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Matrix3<T> Add<T>(Matrix3<T> left, Matrix3<T> right) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Matrix3<T> Multiply<T>(Matrix3<T> left, Matrix3<T> right) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Matrix3<T> Invert<T>(Matrix3<T> mat) where T:unmanaged
        {
            throw new NotImplementedException();
        }

        public static Matrix3<T> Transpose<T>(Matrix3<T> mat) where T:unmanaged
        {
            throw new NotImplementedException();
        }
    }
}
