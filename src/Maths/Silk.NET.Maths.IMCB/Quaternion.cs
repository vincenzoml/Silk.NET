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
    public struct Quaternion<T> : IEquatable<Quaternion<T>> where T:unmanaged
    {
        public static readonly Quaternion<T> Identity = new Quaternion<T>(Vector3<T>.Zero, Scalar<T>.One);
        public Vector3<T> Xyz;
        public T W;

        public Quaternion(Vector3<T> v, T w)
        {
            Xyz = v;
            W = w;
        }

        public Quaternion(T x, T y, T z, T w) : this(new Vector3<T>(x, y, z), w)
        {
        }

        public Quaternion(T rotationX, T rotationY, T rotationZ) : this(new Vector3<T>(rotationX, rotationY, rotationZ))
        {
        }

        public Quaternion(Vector3<T> eulerAngles)
        {
            eulerAngles = Vector3.Multiply(eulerAngles, Divide(Scalar<T>.One, Scalar<T>.Two));

            var c1 = Cos(eulerAngles.X); // TODO Make MathF but for vectors! SIMD GO BRRRRRR! (we can so vectorize this)
            var c2 = Cos(eulerAngles.Y); 
            var c3 = Cos(eulerAngles.Z);
            var s1 = Sin(eulerAngles.X);
            var s2 = Sin(eulerAngles.Y);
            var s3 = Sin(eulerAngles.Z);

            W = Add(Multiply(Multiply(c1, c2), c3), Multiply(Multiply(s1, s2), s3));
            Xyz.X = Add(Multiply(Multiply(s1, c2), c3), Multiply(Multiply(c1, s2), s3));
            Xyz.Y = Add(Multiply(Multiply(c1, s2), c3), Multiply(Multiply(s1, c2), s3));
            Xyz.Z = Add(Multiply(Multiply(c1, c2), s3), Multiply(Multiply(s1, s2), c3));
        }

        public T X
        {
            get => Xyz.X;
            set => Xyz.X = value;
        }

        public T Y
        {
            get => Xyz.Y;
            set => Xyz.Y = value;
        }

        public T Z
        {
            get => Xyz.Z;
            set => Xyz.Z = value;
        }

        public void ToAxisAngle(out Vector3<T> axis, out T angle)
        {
            var result = ToAxisAngle();
            axis = new Vector3<T>(result);
            angle = result.W;
        }

        public Vector4<T> ToAxisAngle()
        {
            var q = this;
            if (GreaterThan(Abs(q.W), Scalar<T>.One))
            {
                q = Quaternion.Normalize(q);
            }

            var den = Sqrt(Subtract(Scalar<T>.One, Multiply(q.W, q.W)));

            return GreaterThan(den, As<float, T>(0.0001f))
                ? new Vector4<T>(q.Xyz / den, Multiply(Scalar<T>.Two, Acos(q.W)))
                : new Vector4<T>(Vector3<T>.UnitX, Multiply(Scalar<T>.Two, Acos(q.W)));
        }

        public Vector3<T> ToEulerAngles()
        {
            // references
            // http://en.wikipedia.org/wiki/Conversion_between_quaternions_and_Euler_angles
            // http://www.euclideanspace.com/maths/geometry/rotations/conversions/quaternionToEuler/

            var q = this;

            Vector3<T> eulerAngles;

            // Threshold for the singularities found at the north/south poles.
            const float singularityThreshold = 0.4999995f;

            var sqw = Multiply(q.W, q.W);
            var sqx = Multiply(q.X, q.X);
            var sqy = Multiply(q.Y, q.Y);
            var sqz = Multiply(q.Z, q.Z);
            var unit = Add(Add(sqx, sqy), Add(sqz, sqw)); // if normalised is one, otherwise is correction factor
            var singularityTest = Add(Multiply(q.X, q.Z), Multiply(q.W, q.Y));

            if (GreaterThan(singularityTest, Multiply(As<float, T>(singularityThreshold), unit)))
            {
                eulerAngles.Z = Multiply(Scalar<T>.Two, Atan2(q.X, q.W));
                eulerAngles.Y = Scalar<T>.PiOver2;
                eulerAngles.X = Scalar<T>.Zero;
            }
            else if (LessThan(singularityTest, Multiply(As<float, T>(-singularityThreshold), unit)))
            {
                eulerAngles.Z = Multiply(Negate(Scalar<T>.Two), Atan2(q.X, q.W));
                eulerAngles.Y = Negate(Scalar<T>.PiOver2);
                eulerAngles.X = Scalar<T>.Zero;
            }
            else
            {
                eulerAngles.Z = Atan2(Multiply(Scalar<T>.Two, (Subtract(Multiply(q.W, q.Z), Multiply(q.X, q.Y)))), Subtract(Subtract(Add(sqw, sqx), sqy), sqz));
                eulerAngles.Y = Asin(Multiply(Scalar<T>.Two, Divide(singularityTest, unit)));
                eulerAngles.X = Atan2(Multiply(Scalar<T>.Two, (Subtract(Multiply(q.W, q.Z), Multiply(q.X, q.Y)))), Add(Subtract(Subtract(sqw, sqx), sqy), sqz));
            }

            return eulerAngles;
        }

        public T GetLength() => Sqrt(GetLengthSquared());
        public T GetLengthSquared() => Add(Multiply(W, W), Xyz.GetLengthSquared());
        public Quaternion<T> GetNormalized() => Quaternion.Normalize(this);
        public Quaternion<T> GetInverted() => Quaternion.Invert(this); // All I have for you is a word: TENET

        public static Quaternion<T> operator +(Quaternion<T> left, Quaternion<T> right) => Quaternion.Add(left, right);
        public static Quaternion<T> operator -(Quaternion<T> left, Quaternion<T> right) => Quaternion.Subtract(left, right);
        public static Quaternion<T> operator *(Quaternion<T> left, Quaternion<T> right) => Quaternion.Multiply(left, right);
        public static Quaternion<T> operator *(Quaternion<T> quaternion, T scale) => Quaternion.Multiply(quaternion, scale);
        public static Quaternion<T> operator *(T scale, Quaternion<T> quaternion) => Quaternion.Multiply(quaternion, scale);
        public static bool operator ==(Quaternion<T> left, Quaternion<T> right) => left.Equals(right);
        public static bool operator !=(Quaternion<T> left, Quaternion<T> right) => !(left == right);
        public override string ToString() => $"V: {Xyz}{ListSeparator} W: {W}";
        public override bool Equals(object other) => other is Quaternion<T> quat && Equals(quat);
        public override int GetHashCode() => HashCode.Combine(Xyz, W);
        public bool Equals(Quaternion<T> other) => other.Xyz.Equals(Xyz) && Equal(W, W);

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
