// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using static Silk.NET.Maths.Helper;
using static Silk.NET.Maths.Scalar;

namespace Silk.NET.Maths
{
    public struct Box2<T> : IEquatable<Box2<T>> where T:unmanaged
    {
        private Vector2<T> Min;
        private Vector2<T> Max;

        public Box2(Vector2<T> min, Vector2<T> max)
        {
            Min = min;
            Max = max;
        }

        public Box2(T minX, T minY, T maxX, T maxY) :this(new Vector2<T>(minX, minY), new Vector2<T>(maxX, maxY))
        {
        }

        public Vector2<T> GetSize() => Max - Min;

        public Box2<T> WithSize(Vector2<T> newSize)
        {
            var center = GetCenter();
            var noughtPointFive = Divide(Scalar<T>.One, Scalar<T>.Two);
            return new Box2<T>(center - newSize * noughtPointFive, center + newSize * noughtPointFive);
        }

        public Vector2<T> GetCenter() => GetSize() / Scalar<T>.Two + Min;
        public Box2<T> WithCenter(Vector2<T> center) => GetTranslated(center - GetCenter());

        public bool Contains(Vector2<T> point)
            => Vector2.ComponentMin(point, Min) == point && Vector2.ComponentMax(point, Max) == Max;

        public bool Contains(Box2<T> other)
        {
            throw new NotImplementedException();
        }

        public T GetDistanceToNearestEdge(Vector2<T> point)
        {
            throw new NotImplementedException();
        }

        public Box2<T> GetTranslated(Vector2<T> distance)
        {
            throw new NotImplementedException();
        }

        public Box2<T> GetScaled(Vector2<T> scale, Vector2<T> anchor)
        {
            throw new NotImplementedException();
        }

        public Box2<T> GetInflated(Vector2<T> point)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(Box2<T> left, Box2<T> right)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(Box2<T> left, Box2<T> right)
        {
            throw new NotImplementedException();
        }

        public bool Equals(Box2<T> other)
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
