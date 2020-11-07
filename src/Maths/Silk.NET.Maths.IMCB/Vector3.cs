// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using static Silk.NET.Maths.Helper;
using static Silk.NET.Maths.Scalar;

namespace Silk.NET.Maths
{
    [Serializable]
    public struct Vector3<T> : IEquatable<Vector3<T>> where T:unmanaged
    {
        public static readonly Vector3<T> UnitX = new Vector3<T>(Scalar<T>.One, Scalar<T>.Zero, Scalar<T>.Zero);
        public static readonly Vector3<T> UnitY = new Vector3<T>(Scalar<T>.Zero, Scalar<T>.One, Scalar<T>.Zero);
        public static readonly Vector3<T> UnitZ = new Vector3<T>(Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.One);
        public static readonly Vector3<T> Zero = new Vector3<T>(Scalar<T>.Zero);
        public static readonly Vector3<T> One = new Vector3<T>(Scalar<T>.One);
        public static readonly Vector3<T> MinusOne = new Vector3<T>(Negate(Scalar<T>.One));
        public static readonly Vector3<T> PositiveInfinity = new Vector3<T>(Scalar<T>.PositiveInfinity);
        public static readonly Vector3<T> NegativeInfinity = new Vector3<T>(Scalar<T>.NegativeInfinity);
        public static readonly unsafe int SizeInBytes = sizeof(Vector3<T>);
        public T X;
        public T Y;
        public T Z;

        public Vector3(T value)
        {
            X = value;
            Y = value;
            Z = value;
        }

        public Vector3(T x, T y, T z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3(Vector2<T> v)
        {
            X = v.X;
            Y = v.Y;
            Z = Scalar<T>.Zero;
        }

        public Vector3(Vector3<T> v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
        }

        public Vector3(Vector4<T> v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
        }

        public T this[int index]
        {
            get
            {
                AssertInRange(nameof(index), index, 0, 3);
                return index switch
                {
                    0 => X,
                    1 => Y,
                    2 => Z,
                    _ => default
                };
            }
            set
            {
                AssertInRange(nameof(index), index, 0, 3);
                switch (index)
                {
                    case 0:
                        X = value;
                        break;
                    case 1:
                        Y = value;
                        break;
                    case 2:
                        Z = value;
                        break;
                }
            }
        }

        public readonly T GetLength() => Sqrt(GetLengthSquared());
        public readonly T GetLengthSquared() => Add(Add(Multiply(X, X), Multiply(Y, Y)), Multiply(Z, Z));
        public readonly Vector3<T> GetNormalized() => Vector3.Normalize(this);
        public static Vector3<T> operator +(Vector3<T> left, Vector3<T> right) => Vector3.Add(left, right);
        public static Vector3<T> operator -(Vector3<T> left, Vector3<T> right) => Vector3.Subtract(left, right);
        public static Vector3<T> operator -(Vector3<T> vec) => Vector3.Negate(vec);
        public static Vector3<T> operator *(Vector3<T> vec, T scale) => Vector3.Multiply(vec, scale);
        public static Vector3<T> operator *(T scale, Vector3<T> vec) => Vector3.Multiply(vec, scale);
        public static Vector3<T> operator *(Vector3<T> vec, Vector3<T> scale) => Vector3.Multiply(vec, scale);
        public static Vector3<T> operator *(Vector3<T> vec, Matrix3<T> mat) => Vector3.Transform(vec, mat);
        public static Vector3<T> operator *(Matrix3<T> mat, Vector3<T> vec) => Vector3.Transform(mat, vec);
        public static Vector3<T> operator *(Quaternion<T> quat, Vector3<T> vec) => Vector3.Transform(vec, quat);
        public static Vector3<T> operator /(Vector3<T> vec, T scale) => Vector3.Divide(vec, scale);
        public static bool operator ==(Vector3<T> left, Vector3<T> right) => left.Equals(right);
        public static bool operator !=(Vector3<T> left, Vector3<T> right) => !(left == right);
        public static implicit operator Vector3<T>((T X, T Y, T Z) values) => new Vector3<T>(values.X, values.Y, values.Z);
        public override string ToString() => $"({X}{ListSeparator} {Y}{ListSeparator} {Z})";
        public override int GetHashCode() => HashCode.Combine(X, Y, Z);
        public override bool Equals(object obj) => obj is Vector3<T> vec && Equals(vec);
        public bool Equals(Vector3<T> other) => Equal(other.X, X) && Equal(other.Y, Y) && Equal(other.Z, Z);

        public void Deconstruct(out T x, out T y, out T z)
        {
            x = X;
            y = Y;
            z = Z;
        }

#if INTRINSICS
        public System.Runtime.Intrinsics.Vector64<T> AsVector64() => throw new NotImplementedException();

        public System.Runtime.Intrinsics.Vector128<T> AsVector128() => throw new NotImplementedException();

        public System.Runtime.Intrinsics.Vector256<T> AsVector256() => throw new NotImplementedException();
#endif

#if BTEC_INTRINSICS
        public System.Numerics.Vector<T> AsVector() => throw new NotImplementedException();
#endif
    }
}
