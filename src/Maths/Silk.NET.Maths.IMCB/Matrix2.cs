// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using static Silk.NET.Maths.Helper;
using static Silk.NET.Maths.Scalar;

namespace Silk.NET.Maths
{
    public struct Matrix2<T> : IEquatable<Matrix2<T>> where T:unmanaged
    {
        public static readonly Matrix2<T> Identity = new Matrix2<T>(Vector2<T>.UnitX, Vector2<T>.UnitY);
        public static readonly Matrix2<T> Zero = new Matrix2<T>(Vector2<T>.Zero, Vector2<T>.Zero);
        public Vector2<T> Row0;
        public Vector2<T> Row1;

        public Matrix2(Vector2<T> row0, Vector2<T> row1) => throw new NotImplementedException();
        public Matrix2(T m00, T m01, T m10, T m11) => throw new NotImplementedException();
        public T GetDeterminant() => throw new NotImplementedException();
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

        public Vector2<T> GetDiagonal() => new Vector2<T>(Row0.X, Row1.Y);
        public Matrix2<T> WithDiagonal(Vector2<T> col)
            => new Matrix2<T>(new Vector2<T>(col.X, Row0.Y), new Vector2<T>(Row1.X, col.Y));
        public Matrix2<T> GetTransposed() => Matrix2.Transpose(this);
        public T GetTrace() => Add(Row0.X, Row1.Y);

        public T this[int rowIndex, int columnIndex]
        {
            get
            {
                AssertInRange(nameof(rowIndex), rowIndex, 0, 2);
                AssertInRange(nameof(columnIndex), columnIndex, 0, 2);
                return rowIndex switch
                {
                    0 => columnIndex switch
                    {
                        0 => Row0.X,
                        1 => Row0.Y,
                        _ => default
                    },
                    1 => columnIndex switch
                    {
                        0 => Row1.X,
                        1 => Row1.Y,
                        _ => default
                    },
                    _ => default
                };
            }
            set
            {
                AssertInRange(nameof(rowIndex), rowIndex, 0, 2);
                AssertInRange(nameof(columnIndex), columnIndex, 0, 2);
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
                        }
                        break;
                }
            }
        }

        public static Matrix2<T> operator *(T left, Matrix2<T> right) => Matrix2.Multiply(right, left);
        public static Matrix2<T> operator *(Matrix2<T> left, T right) => Matrix2.Multiply(left, right);
        public static Matrix2<T> operator *(Matrix2<T> left, Matrix2<T> right) => Matrix2.Multiply(left, right);
        public static Matrix2x3<T> operator *(Matrix2<T> left, Matrix2x3<T> right) => Matrix2.Multiply(left, right);
        public static Matrix2x4<T> operator *(Matrix2<T> left, Matrix2x4<T> right) => Matrix2.Multiply(left, right);
        public static Matrix2<T> operator +(Matrix2<T> left, Matrix2<T> right) => Matrix2.Add(left, right);
        public static Matrix2<T> operator -(Matrix2<T> left, Matrix2<T> right) => Matrix2.Subtract(left, right);
        public static bool operator ==(Matrix2<T> left, Matrix2<T> right) => left.Equals(right);
        public static bool operator !=(Matrix2<T> left, Matrix2<T> right) => !(left == right);
        public override string ToString() => $"{Row0}\n{Row1}";
        public override int GetHashCode() => HashCode.Combine(Row0, Row1);
        public override bool Equals(object obj) => obj is Matrix2<T> mat && Equals(mat);
        public bool Equals(Matrix2<T> other) => other.Row0.Equals(Row0) && other.Row1.Equals(Row1);
    }
}
