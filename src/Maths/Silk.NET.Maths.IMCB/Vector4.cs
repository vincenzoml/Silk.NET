// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Runtime.CompilerServices;
using static Silk.NET.Maths.Helper;
using static Silk.NET.Maths.Scalar;

namespace Silk.NET.Maths
{
    [Serializable]
    public struct Vector4<T> : IEquatable<Vector4<T>> where T : unmanaged
    {
        public static readonly Vector4<T> UnitX = new Vector4<T>(Scalar<T>.One, Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.Zero);
        public static readonly Vector4<T> UnitY = new Vector4<T>(Scalar<T>.Zero, Scalar<T>.One, Scalar<T>.Zero, Scalar<T>.Zero);
        public static readonly Vector4<T> UnitZ = new Vector4<T>(Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.One, Scalar<T>.Zero);
        public static readonly Vector4<T> UnitW = new Vector4<T>(Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.One);
        public static readonly Vector4<T> Zero = new Vector4<T>(Scalar<T>.Zero);
        public static readonly Vector4<T> One = new Vector4<T>(Scalar<T>.One);
        public static readonly Vector4<T> MinusOne = new Vector4<T>(Negate(Scalar<T>.One));
        public static readonly Vector4<T> PositiveInfinity = new Vector4<T>(Scalar<T>.PositiveInfinity);
        public static readonly Vector4<T> NegativeInfinity = new Vector4<T>(Scalar<T>.NegativeInfinity);
        public static readonly unsafe int SizeInBytes = sizeof(Vector4<T>);
        public T X;
        public T Y;
        public T Z;
        public T W;

        public Vector4(T value)
        {
            X = value;
            Y = value;
            Z = value;
            W = value;
        }

        public Vector4(T x, T y, T z, T w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public Vector4(Vector2<T> v)
        {
            X = v.X;
            Y = v.Y;
            Z = Scalar<T>.Zero;
            W = Scalar<T>.Zero;
        }

        public Vector4(Vector3<T> v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
            W = Scalar<T>.Zero;
        }

        public Vector4(Vector3<T> v, T w)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
            W = w;
        }

        public Vector4(Vector4<T> v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
            W = v.W;
        }

        public T this[int index]
        {
            get
            {
                AssertInRange(nameof(index), index, 0, 4);
                return index switch
                {
                    0 => X,
                    1 => Y,
                    2 => Z,
                    3 => W,
                    _ => default
                };
            }
            set
            {
                AssertInRange(nameof(index), index, 0, 4);
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
                    case 3:
                        W = value;
                        break;
                }
            }
        }

        public T GetLength() => Sqrt(GetLengthSquared());
        public T GetLengthSquared() => Add(Add(Add(Multiply(X, X), Multiply(Y, Y)), Multiply(Z, Z)), Multiply(W, W));
        public Vector4<T> GetNormalized() => Vector4.Normalize(this);
        public static Vector4<T> operator +(Vector4<T> left, Vector4<T> right) => Vector4.Add(left, right);
        public static Vector4<T> operator -(Vector4<T> left, Vector4<T> right) => Vector4.Subtract(left, right);
        public static Vector4<T> operator -(Vector4<T> vec) => Vector4.Negate(vec);
        public static Vector4<T> operator *(Vector4<T> vec, T scale) => Vector4.Multiply(vec, scale);
        public static Vector4<T> operator *(T scale, Vector4<T> vec) => Vector4.Multiply(vec, scale);
        public static Vector4<T> operator *(Vector4<T> vec, Vector4<T> scale) => Vector4.Multiply(vec, scale);
        public static Vector4<T> operator *(Vector4<T> vec, Matrix4<T> mat) => Vector4.Transform(vec, mat);
        public static Vector4<T> operator *(Matrix4<T> mat, Vector4<T> vec) => Vector4.Transform(mat, vec);
        public static Vector4<T> operator *(Quaternion<T> quat, Vector4<T> vec) => Vector4.Transform(vec, quat);
        public static Vector4<T> operator /(Vector4<T> vec, T scale) => Vector4.Divide(vec, scale);
        public static bool operator ==(Vector4<T> left, Vector4<T> right) => left.Equals(right);
        public static bool operator !=(Vector4<T> left, Vector4<T> right) => !(left == right);
        public static implicit operator Vector4<T>((T X, T Y, T Z, T W) values) => new Vector4<T>(values.X, values.Y, values.Z, values.W);
        public override string ToString() => $"({X}{ListSeparator} {Y}{ListSeparator} {Z}{ListSeparator} {W})";
        public override int GetHashCode() => HashCode.Combine(X, Y, Z, W);
        public override bool Equals(object obj) => obj is Vector4<T> vec && Equals(vec);
        public bool Equals(Vector4<T> other) => Equal(X, other.X) && Equal(Y, other.Y) && Equal(Z, other.Z) && Equal(W, other.W);

        public void Deconstruct(out T x, out T y, out T z, out T w)
        {
            x = X;
            y = Y;
            z = Z;
            w = W;
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
