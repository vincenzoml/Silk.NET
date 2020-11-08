// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using static Silk.NET.Maths.Helper;
using static Silk.NET.Maths.Scalar;

namespace Silk.NET.Maths
{
    public struct Matrix2x4<T> : IEquatable<Matrix2x4<T>> where T:unmanaged
    {
        public static readonly Matrix2x4<T> Zero = new Matrix2x4<T>(Vector4<T>.Zero, Vector4<T>.Zero);
        public Vector4<T> Row0;
        public Vector4<T> Row1;

        public Matrix2x4(Vector4<T> row0, Vector4<T> row1) => throw new NotImplementedException();

        public Matrix2x4
        (
            T m00,
            T m01,
            T m02,
            T m03,
            T m10,
            T m11,
            T m12,
            T m13
        ) =>
            throw new NotImplementedException();

        public Vector2<T> Column0
        {
            get => new Vector2<T>(Row0.X, Row1.X);
            set
            {
                Row0.X = value.X;
                Row1.X = value.Y;
            }
        }

        public Vector2<T> Column1
        {
            get => new Vector2<T>(Row0.Y, Row1.Y);
            set
            {
                Row0.Y = value.X;
                Row1.Y = value.Y;
            }
        }

        public Vector2<T> Column2
        {
            get => new Vector2<T>(Row0.Z, Row1.Z);
            set
            {
                Row0.Z = value.X;
                Row1.Z = value.Y;
            }
        }

        public Vector2<T> Column3
        {
            get => new Vector2<T>(Row0.W, Row1.W);
            set
            {
                Row0.W = value.X;
                Row1.W = value.Y;
            }
        }

        public Vector2<T> GetDiagonal() => new Vector2<T>(Row0.X, Row1.Y);

        public Matrix2x4<T> WithDiagonal(Vector2<T> col)
            => new Matrix2x4<T>
                (new Vector4<T>(col.X, Row0.Y, Row0.Z, Row0.W), new Vector4<T>(Row1.X, col.Y, Row1.Z, Row1.W));
        public T GetTrace() => throw new NotImplementedException();
        public Matrix4x2<T> GetTransposed() => Matrix2x4.Transpose(this);

        public T this[int rowIndex, int columnIndex]
        {
            get
            {
                AssertInRange(nameof(rowIndex), rowIndex, 0, 2);
                AssertInRange(nameof(columnIndex), columnIndex, 0, 4);
                return rowIndex switch
                {
                    0 => columnIndex switch
                    {
                        0 => Row0.X,
                        1 => Row0.Y,
                        2 => Row0.Z,
                        3 => Row0.W,
                        _ => default
                    },
                    1 => columnIndex switch
                    {
                        0 => Row1.X,
                        1 => Row1.Y,
                        2 => Row1.Z,
                        3 => Row1.W,
                        _ => default
                    },
                    _ => default
                };
            }
            set
            {
                AssertInRange(nameof(rowIndex), rowIndex, 0, 2);
                AssertInRange(nameof(columnIndex), columnIndex, 0, 4);
                switch (rowIndex)
                {
                    case 0:
                        switch (columnIndex)
                        {
                            case 0:
                                Row0.X = value;
                                break;
                            case 1:
                                Row0.Y = value;
                                break;
                            case 2:
                                Row0.Z = value;
                                break;
                            case 3:
                                Row0.W = value;
                                break;
                        }
                        break;
                    case 1:
                        switch (columnIndex)
                        {
                            case 0:
                                Row1.X = value;
                                break;
                            case 1:
                                Row1.Y = value;
                                break;
                            case 2:
                                Row1.Z = value;
                                break;
                            case 3:
                                Row1.W = value;
                                break;
                        }
                        break;
                }
            }
        }

        public static Matrix2x4<T> operator *(T left, Matrix2x4<T> right) => Matrix2x4.Multiply(right, left);
        public static Matrix2x4<T> operator *(Matrix2x4<T> left, T right) => Matrix2x4.Multiply(left, right);
        public static Matrix2<T> operator *(Matrix2x4<T> left, Matrix4x2<T> right) => Matrix2x4.Multiply(left, right);
        public static Matrix2x3<T> operator *(Matrix2x4<T> left, Matrix4x3<T> right) => Matrix2x4.Multiply(left, right);
        public static Matrix2x4<T> operator *(Matrix2x4<T> left, Matrix4<T> right) => Matrix2x4.Multiply(left, right);
        public static Matrix2x4<T> operator +(Matrix2x4<T> left, Matrix2x4<T> right) => Matrix2x4.Add(left, right);
        public static Matrix2x4<T> operator -(Matrix2x4<T> left, Matrix2x4<T> right) => Matrix2x4.Subtract(left, right);
        public static bool operator ==(Matrix2x4<T> left, Matrix2x4<T> right) => left.Equals(right);
        public static bool operator !=(Matrix2x4<T> left, Matrix2x4<T> right) => !(left == right);
        public override string ToString() => $"{Row0}\n{Row1}";
        public override int GetHashCode() => HashCode.Combine(Row0, Row1);
        public override bool Equals(object obj) => obj is Matrix2x4<T> mat && Equals(mat);
        public bool Equals(Matrix2x4<T> other) => other.Row0.Equals(Row0) && other.Row1.Equals(Row1);
    }
}
