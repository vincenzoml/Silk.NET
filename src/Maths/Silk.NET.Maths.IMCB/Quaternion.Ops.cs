// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;

namespace Silk.NET.Maths
{
    public static class Quaternion
    {
        public static Quaternion<T> Add<T>(Quaternion<T> left, Quaternion<T> right) where T : unmanaged
        {
            throw new NotImplementedException();
        }

        public static Quaternion<T> Subtract<T>(Quaternion<T> left, Quaternion<T> right) where T : unmanaged
        {
            throw new NotImplementedException();
        }

        public static Quaternion<T> Multiply<T>(Quaternion<T> left, Quaternion<T> right) where T : unmanaged
        {
            throw new NotImplementedException();
        }

        public static Quaternion<T> Multiply<T>(Quaternion<T> quaternion, T scale) where T : unmanaged
        {
            throw new NotImplementedException();
        }

        public static Quaternion<T> Conjugate<T>(Quaternion<T> q) where T : unmanaged
        {
            throw new NotImplementedException();
        }

        public static Quaternion<T> Invert<T>(Quaternion<T> q) where T : unmanaged
        {
            throw new NotImplementedException();
        }

        public static Quaternion<T> Normalize<T>(Quaternion<T> q) where T : unmanaged
        {
            throw new NotImplementedException();
        }

        public static Quaternion<T> FromAxisAngle<T>(Vector3<T> axis, T angle) where T : unmanaged
        {
            throw new NotImplementedException();
        }

        public static Quaternion<T> FromEulerAngles<T>(T pitch, T yaw, T roll) where T : unmanaged
        {
            throw new NotImplementedException();
        }

        public static Quaternion<T> FromEulerAngles<T>(Vector3<T> eulerAngles) where T : unmanaged
        {
            throw new NotImplementedException();
        }

        public static Quaternion<T> FromMatrix<T>(Matrix3<T> matrix) where T : unmanaged
        {
            throw new NotImplementedException();
        }

        public static Quaternion<T> Slerp<T>(Quaternion<T> q1, Quaternion<T> q2, T blend) where T : unmanaged
        {
            throw new NotImplementedException();
        }
    }
}
