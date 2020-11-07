// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if INTRINSICS
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
#endif
using static Silk.NET.Maths.Helper;
using static Silk.NET.Maths.Scalar;

namespace Silk.NET.Maths
{
    [Serializable]
    public struct Vector2<T> : IEquatable<Vector2<T>> where T:unmanaged
    {
        public static readonly Vector2<T> UnitX = new Vector2<T>(Scalar<T>.One, Scalar<T>.Zero);
        public static readonly Vector2<T> UnitY = new Vector2<T>(Scalar<T>.Zero, Scalar<T>.One);
        public static readonly Vector2<T> Zero = new Vector2<T>(Scalar<T>.Zero);
        public static readonly Vector2<T> One = new Vector2<T>(Scalar<T>.One);
        public static readonly Vector2<T> MinusOne = new Vector2<T>(Scalar.Negate(Scalar<T>.One));
        public static readonly Vector2<T> PositiveInfinity = new Vector2<T>(Scalar<T>.PositiveInfinity);
        public static readonly Vector2<T> NegativeInfinity = new Vector2<T>(Scalar<T>.NegativeInfinity);
        public static readonly unsafe int SizeInBytes = sizeof(Vector2<T>);
        private static readonly string ListSeparator = CultureInfo.CurrentCulture.TextInfo.ListSeparator;

        private static readonly bool IntrinsicsApplicable = typeof(T) == typeof(byte)
                                                            || typeof(T) == typeof(sbyte)
                                                            || typeof(T) == typeof(ushort)
                                                            || typeof(T) == typeof(short)
                                                            || typeof(T) == typeof(uint)
                                                            || typeof(T) == typeof(int)
                                                            || typeof(T) == typeof(ulong)
                                                            || typeof(T) == typeof(long)
                                                            || typeof(T) == typeof(float)
                                                            || typeof(T) == typeof(double);

        public T X;
        public T Y;

        public Vector2(T value)
        {
            X = value;
            Y = value;
        }

        public Vector2(T x, T y)
        {
            X = x;
            Y = y;
        }

        public unsafe ref T this[int index]
        {
            get
            {
                AssertInRange(nameof(index), index, 0, 2);
                fixed (T* data = &X)
                {
                    return ref data[index];
                }
            }
        }

        public readonly T GetLength() => Scalar.Sqrt(GetLengthSquared());
        public readonly T GetLengthSquared() => Scalar.Add(Scalar.Multiply(X, X), Scalar.Multiply(Y, Y));
        public readonly Vector2<T> GetPerpendicularRight() => new Vector2<T>(Y, Scalar.Negate(X));
        public readonly Vector2<T> GetPerpendicularLeft() => new Vector2<T>(Scalar.Negate(Y), X);
        public readonly Vector2<T> GetNormalized() => Vector2.Normalize(this);
        public static Vector2<T> operator +(Vector2<T> left, Vector2<T> right) => Vector2.Add(left, right);
        public static Vector2<T> operator -(Vector2<T> left, Vector2<T> right) => Vector2.Subtract(left, right);
        public static Vector2<T> operator -(Vector2<T> vec) => Vector2.Negate(vec);
        public static Vector2<T> operator *(Vector2<T> vec, T scale) => Vector2.Multiply(vec, scale);
        public static Vector2<T> operator *(T scale, Vector2<T> vec) => vec * scale;
        public static Vector2<T> operator *(Vector2<T> vec, Vector2<T> scale) => Vector2.Multiply(vec, scale);
        public static Vector2<T> operator *(Vector2<T> vec, Matrix2<T> mat) => Vector2.Transform(vec, mat);

        public static Vector2<T> operator *(Matrix2<T> mat, Vector2<T> vec) => Vector2.Transform(mat, vec);
        public static Vector2<T> operator *(Quaternion<T> quat, Vector2<T> vec) => Vector2.Transform(vec, quat);

        public static Vector2<T> operator /(Vector2<T> vec, T scale)
            => new Vector2<T>(Scalar.Divide(vec.X, scale), Scalar.Divide(vec.Y, scale));
        public static bool operator ==(Vector2<T> left, Vector2<T> right) => left.Equals(right);
        public static bool operator !=(Vector2<T> left, Vector2<T> right) => !(left == right);
        public static implicit operator Vector2<T>((T X, T Y) values) => new Vector2<T>(values.X, values.Y);
        public override readonly string ToString() => $"({X}{ListSeparator} {Y})";
        public override readonly int GetHashCode() => HashCode.Combine(X, Y);
        public override readonly bool Equals(object obj) => obj is Vector2<T> vec && Equals(vec);
        public readonly bool Equals(Vector2<T> other) => Equal(X, other.X) && Equal(Y, other.Y);
        public readonly void Deconstruct(out T x, out T y)
        {
            x = X;
            y = Y;
        }

#if INTRINSICS
        public System.Runtime.Intrinsics.Vector64<T> AsVector64()
        {
            if (!IntrinsicsApplicable)
            {
                ThrowOpUnsupportedType();
                return default;
            }
            
            return Byte(this);

            static Vector64<T> Byte(Vector2<T> vec)
            {
                if (typeof(T) == typeof(byte))
                {
                    return (Vector64<T>)(object)Vector64.Create((byte)(object)vec.X, (byte)(object)vec.Y, 0, 0, 0, 0, 0, 0);
                }
                return Sbyte(vec);
            }
            static Vector64<T> Sbyte(Vector2<T> vec)
            {
                if (typeof(T) == typeof(sbyte))
                {
                    return (Vector64<T>)(object)Vector64.Create((sbyte)(object)vec.X, (sbyte)(object)vec.Y, 0, 0, 0, 0, 0, 0);
                }
                
                return Ushort(vec);
            }
            static Vector64<T> Ushort(Vector2<T> vec)
            {
                if (typeof(T) == typeof(ushort))
                {
                    return (Vector64<T>)(object)Vector64.Create((ushort)(object)vec.X, (ushort)(object)vec.Y, 0, 0);
                }
                
                return Short(vec);
            }
            static Vector64<T> Short(Vector2<T> vec)
            {
                if (typeof(T) == typeof(short))
                {
                    return (Vector64<T>)(object)Vector64.Create((short)(object)vec.X, (short)(object)vec.Y, 0, 0);
                }
                
                return Uint(vec);
            }
            static Vector64<T> Uint(Vector2<T> vec)
            {
                if (typeof(T) == typeof(uint))
                {
                    return (Vector64<T>)(object)Vector64.Create((uint)(object)vec.X, (uint)(object)vec.Y);
                }
                
                return Int(vec);
            }
            static Vector64<T> Int(Vector2<T> vec)
            {
                if (typeof(T) == typeof(int))
                {
                    return (Vector64<T>)(object)Vector64.Create((int)(object)vec.X, (int)(object)vec.Y);
                }
                
                return Ulong(vec);
            }
            static Vector64<T> Ulong(Vector2<T> vec)
            {
                if (typeof(T) == typeof(ulong))
                {
                    ThrowOpUnsupportedPrecision();
                    return default;
                }
                
                return Long(vec);
            }
            static Vector64<T> Long(Vector2<T> vec)
            {
                if (typeof(T) == typeof(long))
                {
                    ThrowOpUnsupportedPrecision();
                    return default;
                }
                
                return Float(vec);
            }
            static Vector64<T> Float(Vector2<T> vec)
            {
                if (typeof(T) == typeof(float))
                {
                    return (Vector64<T>)(object)Vector64.Create((float)(object)vec.X, (float)(object)vec.Y);
                }
                
                return Double(vec);
            }
            static Vector64<T> Double(Vector2<T> vec)
            {
                if (typeof(T) == typeof(double))
                {
                    ThrowOpUnsupportedPrecision();
                    return default;
                }
                
                ThrowOpUnsupportedType();
                return default;
            }
        }

        public System.Runtime.Intrinsics.Vector128<T> AsVector128()
        {
            if (!IntrinsicsApplicable)
            {
                ThrowOpUnsupportedType();
                return default;
            }
            
            return Byte(this);

            static Vector128<T> Byte(Vector2<T> vec)
            {
                if (typeof(T) == typeof(byte))
                {
                    return (Vector128<T>)(object)Vector128.Create((byte)(object)vec.X, (byte)(object)vec.Y, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                }
                return Sbyte(vec);
            }
            static Vector128<T> Sbyte(Vector2<T> vec)
            {
                if (typeof(T) == typeof(sbyte))
                {
                    return (Vector128<T>)(object)Vector128.Create((sbyte)(object)vec.X, (sbyte)(object)vec.Y, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                }
                
                return Ushort(vec);
            }
            static Vector128<T> Ushort(Vector2<T> vec)
            {
                if (typeof(T) == typeof(ushort))
                {
                    return (Vector128<T>)(object)Vector128.Create((ushort)(object)vec.X, (ushort)(object)vec.Y, 0, 0, 0, 0, 0, 0);
                }
                
                return Short(vec);
            }
            static Vector128<T> Short(Vector2<T> vec)
            {
                if (typeof(T) == typeof(short))
                {
                    return (Vector128<T>)(object)Vector128.Create((short)(object)vec.X, (short)(object)vec.Y, 0, 0, 0, 0, 0, 0);
                }
                
                return Uint(vec);
            }
            static Vector128<T> Uint(Vector2<T> vec)
            {
                if (typeof(T) == typeof(uint))
                {
                    return (Vector128<T>)(object)Vector128.Create((uint)(object)vec.X, (uint)(object)vec.Y, 0, 0);
                }
                
                return Int(vec);
            }
            static Vector128<T> Int(Vector2<T> vec)
            {
                if (typeof(T) == typeof(int))
                {
                    return (Vector128<T>)(object)Vector128.Create((int)(object)vec.X, (int)(object)vec.Y, 0, 0);
                }
                
                return Ulong(vec);
            }
            static Vector128<T> Ulong(Vector2<T> vec)
            {
                if (typeof(T) == typeof(ulong))
                {
                    return (Vector128<T>)(object)Vector128.Create((ulong)(object)vec.X, (ulong)(object)vec.Y);
                }
                
                return Long(vec);
            }
            static Vector128<T> Long(Vector2<T> vec)
            {
                if (typeof(T) == typeof(long))
                {
                    return (Vector128<T>)(object)Vector128.Create((long)(object)vec.X, (long)(object)vec.Y);
                }
                
                return Float(vec);
            }
            static Vector128<T> Float(Vector2<T> vec)
            {
                if (typeof(T) == typeof(float))
                {
                    return (Vector128<T>)(object)Vector128.Create((float)(object)vec.X, (float)(object)vec.Y, 0, 0);
                }
                
                return Double(vec);
            }
            static Vector128<T> Double(Vector2<T> vec)
            {
                if (typeof(T) == typeof(double))
                {
                    return (Vector128<T>)(object)Vector128.Create((double)(object)vec.X, (double)(object)vec.Y);
                }
                
                ThrowOpUnsupportedType();
                return default;
            }
        }

        public System.Runtime.Intrinsics.Vector256<T> AsVector256()
        {
            if (!IntrinsicsApplicable)
            {
                ThrowOpUnsupportedType();
                return default;
            }
            
            return Byte(this);

            static Vector256<T> Byte(Vector2<T> vec)
            {
                if (typeof(T) == typeof(byte))
                {
                    return (Vector256<T>)(object)Vector256.Create((byte)(object)vec.X, (byte)(object)vec.Y, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                }
                return Sbyte(vec);
            }
            static Vector256<T> Sbyte(Vector2<T> vec)
            {
                if (typeof(T) == typeof(sbyte))
                {
                    return (Vector256<T>)(object)Vector256.Create((sbyte)(object)vec.X, (sbyte)(object)vec.Y, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                }
                
                return Ushort(vec);
            }
            static Vector256<T> Ushort(Vector2<T> vec)
            {
                if (typeof(T) == typeof(ushort))
                {
                    return (Vector256<T>)(object)Vector256.Create((ushort)(object)vec.X, (ushort)(object)vec.Y, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                }
                
                return Short(vec);
            }
            static Vector256<T> Short(Vector2<T> vec)
            {
                if (typeof(T) == typeof(short))
                {
                    return (Vector256<T>)(object)Vector256.Create((short)(object)vec.X, (short)(object)vec.Y, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                }
                
                return Uint(vec);
            }
            static Vector256<T> Uint(Vector2<T> vec)
            {
                if (typeof(T) == typeof(uint))
                {
                    return (Vector256<T>)(object)Vector256.Create((uint)(object)vec.X, (uint)(object)vec.Y, 0, 0, 0, 0, 0, 0);
                }
                
                return Int(vec);
            }
            static Vector256<T> Int(Vector2<T> vec)
            {
                if (typeof(T) == typeof(int))
                {
                    return (Vector256<T>)(object)Vector256.Create((int)(object)vec.X, (int)(object)vec.Y, 0, 0, 0, 0, 0, 0);
                }
                
                return Ulong(vec);
            }
            static Vector256<T> Ulong(Vector2<T> vec)
            {
                if (typeof(T) == typeof(ulong))
                {
                    return (Vector256<T>)(object)Vector256.Create((ulong)(object)vec.X, (ulong)(object)vec.Y, 0, 0);
                }
                
                return Long(vec);
            }
            static Vector256<T> Long(Vector2<T> vec)
            {
                if (typeof(T) == typeof(long))
                {
                    return (Vector256<T>)(object)Vector256.Create((long)(object)vec.X, (long)(object)vec.Y, 0, 0);
                }
                
                return Float(vec);
            }
            static Vector256<T> Float(Vector2<T> vec)
            {
                if (typeof(T) == typeof(float))
                {
                    return (Vector256<T>)(object)Vector256.Create((float)(object)vec.X, (float)(object)vec.Y, 0, 0, 0, 0, 0, 0);
                }
                
                return Double(vec);
            }
            static Vector256<T> Double(Vector2<T> vec)
            {
                if (typeof(T) == typeof(double))
                {
                    return (Vector256<T>)(object)Vector256.Create((double)(object)vec.X, (double)(object)vec.Y, 0, 0);
                }
                
                ThrowOpUnsupportedType();
                return default;
            }
        }
#endif

#if BTEC_INTRINSICS
        public System.Numerics.Vector<T> AsVector()
        {
            if (!IntrinsicsApplicable)
            {
                ThrowOpUnsupportedType();
                return default;
            }
            
            if (Vector<T>.Count == 2)
            {
                return new Vector<T>(MemoryMarshal.CreateSpan(ref X, 2));
            }
            else
            {
                Span<T> data = stackalloc T[Vector<T>.Count];
                data[0] = X;
                data[1] = Y;
                return new Vector<T>(data);
            }
        }
#endif
    }
}
