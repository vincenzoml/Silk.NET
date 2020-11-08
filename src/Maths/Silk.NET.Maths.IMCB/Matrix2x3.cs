// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using static Silk.NET.Maths.Helper;
using static Silk.NET.Maths.Scalar;

namespace Silk.NET.Maths
{
    public struct Matrix2x3<T> : IEquatable<Matrix2x3<T>> where T:unmanaged
    {
        public static readonly Matrix2x3<T> Zero = new Matrix2x3<T>(Vector3<T>.Zero, Vector3<T>.Zero);
        public Vector3<T> Row0;
        public Vector3<T> Row1;

        public Matrix2x3(Vector3<T> row0, Vector3<T> row1) => throw new NotImplementedException();

        public Matrix2x3(T m00, T m01, T m02, T m10, T m11, T m12) => throw new NotImplementedException();

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

        public Vector2<T> GetDiagonal() => new Vector2<T>(Row0.X, Row1.Y);
        public Matrix2x3<T> WithDiagonal(Vector2<T> col)
            => new Matrix2x3<T>(new Vector3<T>(col.X, Row0.Y, Row0.Z), new Vector3<T>(Row1.X, col.Y, Row1.Z));
        public Matrix3x2<T> GetTransposed() => Matrix2x3.Transpose(this);
        public T GetTrace() => Add(Row0.X, Row1.Y);

        public T this[int rowIndex, int columnIndex]
        {
            get
            {
                AssertInRange(nameof(rowIndex), rowIndex, 0, 2);
                AssertInRange(nameof(columnIndex), columnIndex, 0, 3);
                return rowIndex switch
                {
                    0 => columnIndex switch
                    {
                        0 => Row0.X,
                        1 => Row0.Y,
                        2 => Row0.Z,
                        _ => default
                    },
                    1 => columnIndex switch
                    {
                        0 => Row1.X,
                        1 => Row1.Y,
                        2 => Row1.Z,
                        _ => default
                    },
                    _ => default
                };
            }
            set
            {
                AssertInRange(nameof(rowIndex), rowIndex, 0, 2);
                AssertInRange(nameof(columnIndex), columnIndex, 0, 3);
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
                        }
                        break;
                }
            }
        }

        public static Matrix2x3<T> operator *(T left, Matrix2x3<T> right) => Matrix2x3.Multiply(right, left);
        public static Matrix2x3<T> operator *(Matrix2x3<T> left, T right) => Matrix2x3.Multiply(left, right);
        public static Matrix2<T> operator *(Matrix2x3<T> left, Matrix3x2<T> right) => Matrix2x3.Multiply(left, right);
        public static Matrix2x3<T> operator *(Matrix2x3<T> left, Matrix3<T> right) => Matrix2x3.Multiply(left, right);
        public static Matrix2x4<T> operator *(Matrix2x3<T> left, Matrix3x4<T> right) => Matrix2x3.Multiply(left, right);
        public static Matrix2x3<T> operator +(Matrix2x3<T> left, Matrix2x3<T> right) => Matrix2x3.Add(left, right);
        public static Matrix2x3<T> operator -(Matrix2x3<T> left, Matrix2x3<T> right) => Matrix2x3.Subtract(left, right);
        public static bool operator ==(Matrix2x3<T> left, Matrix2x3<T> right) => left.Equals(right);
        public static bool operator !=(Matrix2x3<T> left, Matrix2x3<T> right) => !(left == right);
        public override string ToString() => $"{Row0}\n{Row1}";
        public override int GetHashCode() => HashCode.Combine(Row0, Row1);
        public override bool Equals(object obj) => obj is Matrix2x3<T> mat && Equals(mat);
        public bool Equals(Matrix2x3<T> other) => Row0.Equals(other.Row0) && Row1.Equals(other.Row1);
    }
}
