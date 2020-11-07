// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using static Silk.NET.Maths.Helper;
using static Silk.NET.Maths.Scalar;

namespace Silk.NET.Maths
{
    public struct Box3<T> : IEquatable<Box3<T>> where T:unmanaged
    {
        private static readonly string ListSeparator;
        private Vector3<T> Min;
        private Vector3<T> Max;
        
        public Box3(Vector3<T> min, Vector3<T> max)
        {
            throw new NotImplementedException();
        }

        public Box3(T minX, T minY, T minZ, T maxX, T maxY, T maxZ)
        {
            throw new NotImplementedException();
        }

        public Vector3<T> GetSize() => Max - Min;

        public Box3<T> WithSize(Vector3<T> newSize)
        {
            var center = GetCenter();
            var noughtPointFive = Divide(Scalar<T>.One, Scalar<T>.Two);
            return new Box3<T>(center - newSize * noughtPointFive, center + newSize * noughtPointFive);
        }

        public Vector3<T> GetCenter() => GetSize() / Scalar<T>.Two + Min;
        public Box3<T> WithCenter(Vector3<T> center) => GetTranslated(center - GetCenter());

        public bool Contains(Vector3<T> point)
        {
            throw new NotImplementedException();
        }

        public bool Contains(Box3<T> other)
        {
            throw new NotImplementedException();
        }

        public T DistanceToNearestEdge(Vector3<T> point)
        {
            throw new NotImplementedException();
        }

        public Box3<T> GetTranslated(Vector3<T> distance)
        {
            throw new NotImplementedException();
        }

        public Box3<T> GetScaled(Vector3<T> scale, Vector3<T> anchor)
        {
            throw new NotImplementedException();
        }

        public Box3<T> GetInflated(Vector3<T> point)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(Box3<T> left, Box3<T> right)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(Box3<T> left, Box3<T> right)
        {
            throw new NotImplementedException();
        }

        public bool Equals(Box3<T> other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
