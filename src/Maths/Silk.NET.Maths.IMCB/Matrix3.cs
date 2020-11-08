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
    public struct Matrix3<T> : IEquatable<Matrix3<T>> where T:unmanaged
    {
        public static readonly Matrix3<T> Identity = new Matrix3<T>(Vector3<T>.UnitX, Vector3<T>.UnitY, Vector3<T>.UnitZ);
        public static readonly Matrix3<T> Zero = new Matrix3<T>(Vector3<T>.Zero, Vector3<T>.Zero, Vector3<T>.Zero);
        private static readonly T Four = Multiply(Scalar<T>.Two, Scalar<T>.Two);
        private static readonly T NoughtPointFive = Divide(Scalar<T>.One, Scalar<T>.Two);
        private static readonly T NoughtPointTwoFive = Divide(NoughtPointFive, Scalar<T>.Two);
        public Vector3<T> Row0;
        public Vector3<T> Row1;
        public Vector3<T> Row2;

        public Matrix3(Vector3<T> row0, Vector3<T> row1, Vector3<T> row2)
        {
            Row0 = row0;
            Row1 = row1;
            Row2 = row2;
        }

        public Matrix3
        (
            T m00,
            T m01,
            T m02,
            T m10,
            T m11,
            T m12,
            T m20,
            T m21,
            T m22
        ) =>
            throw new NotImplementedException();

        public Matrix3(Matrix4<T> matrix) => throw new NotImplementedException();

        public T GetDeterminant() => throw new NotImplementedException();

        public Vector3<T> Column0
        {
            get => new Vector3<T>(Row0.X, Row1.X, Row2.X);
            set
            {
                Row0.X = value.X;
                Row1.X = value.Y;
                Row2.X = value.Z;
            }
        }

        public Vector3<T> Column1
        {
            get => new Vector3<T>(Row0.Y, Row1.Y, Row2.Y);
            set
            {
                Row0.Y = value.X;
                Row1.Y = value.Y;
                Row2.Y = value.Z;
            }
        }

        public Vector3<T> Column2
        {
            get => new Vector3<T>(Row0.Z, Row1.Z, Row2.Z);
            set
            {
                Row0.Z = value.X;
                Row1.Z = value.Y;
                Row2.Z = value.Z;
            }
        }

        public Vector3<T> Diagonal
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public T GetTrace() => throw new NotImplementedException();

        public T this[int rowIndex, int columnIndex]
        {
            get
            {
                AssertInRange(nameof(rowIndex), rowIndex, 0, 3);
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
                    2 => columnIndex switch
                    {
                        0 => Row2.X,
                        1 => Row2.Y,
                        2 => Row2.Z,
                        _ => default
                    },
                    _ => default
                };
            }
            set
            {
                AssertInRange(nameof(rowIndex), rowIndex, 0, 3);
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
                    case 2:
                        switch (columnIndex)
                        {
                            case 0:
                                Row2.X = value;
                                break;
                            case 1:
                                Row2.Y = value;
                                break;
                            case 2:
                                Row2.Z = value;
                                break;
                        }
                        break;
                }
            }
        }

        public Matrix3<T> GetTransposed() => Matrix3.Transpose(this);
        public Matrix3<T> GetNormalized() => Matrix3.Normalize(this);
        public Matrix3<T> GetInverted() => Matrix3.Invert(this);
        public Matrix3<T> ClearScale() => new Matrix3<T>(Row0.GetNormalized(), Row1.GetNormalized(), Row2.GetNormalized());

        public Matrix3<T> ClearRotation()
            => new Matrix3<T>
            (
                new Vector3<T>(Row0.GetLength(), Scalar<T>.Zero, Scalar<T>.Zero),
                new Vector3<T>(Scalar<T>.Zero, Row1.GetLength(), Scalar<T>.Zero),
                new Vector3<T>(Scalar<T>.Zero, Scalar<T>.Zero, Row2.GetLength())
            );

        public Vector3<T> ExtractScale() => new Vector3<T>(Row0.GetLength(), Row1.GetLength(), Row2.GetLength());

        public Quaternion<T> ExtractRotation(bool rowNormalize = true)
        {
            var row0 = Row0;
            var row1 = Row1;
            var row2 = Row2;

            if (rowNormalize)
            {
                row0 = row0.GetNormalized();
                row1 = row1.GetNormalized();
                row2 = row2.GetNormalized();
            }

            // code below adapted from Blender
            var q = default(Quaternion<T>);
            var trace = Multiply(NoughtPointTwoFive, (Add(Add(Add(row0[0], row1[1]), row2[2]), Scalar<T>.One)));

            if (GreaterThan(trace, Scalar<T>.Zero))
            {
                var sq = Sqrt(trace);

                q.W = sq;
                sq = Divide(Scalar<T>.One, Multiply(Four, sq));
                q.X = Multiply(Subtract(row1[2], row2[1]), sq);
                q.Y = Multiply(Subtract(row2[0], row0[2]), sq);
                q.Z = Multiply(Subtract(row0[1], row1[0]), sq);
            }
            else if (GreaterThan(row0[0], row1[1]) && GreaterThan(row0[0], row2[2]))
            {
                var sq = Multiply(Scalar<T>.Two, Sqrt(Subtract(Subtract(Add(Scalar<T>.One, row0[0]), row1[1]), row2[2])));

                q.X = Multiply(NoughtPointTwoFive, sq);
                sq = Divide(Scalar<T>.One, sq);
                q.W = Multiply(Subtract(row2[1], row1[2]), sq);
                q.Y = Multiply(Add(row1[0], row0[1]), sq);
                q.Z = Multiply(Add(row2[0], row0[2]), sq);
            }
            else if (GreaterThan(row1[1], row2[2]))
            {
                var sq = Multiply(Scalar<T>.Two, Sqrt(Subtract(Subtract(Add(Scalar<T>.One, row1[1]), row0[0]), row2[2])));

                q.Y = Multiply(NoughtPointTwoFive, sq);
                sq = Divide(Scalar<T>.One, sq);
                q.W = Multiply(Subtract(row2[0], row0[2]), sq);
                q.X = Multiply(Add(row1[0], row0[1]), sq);
                q.Z = Multiply(Add(row2[1], row1[2]), sq);
            }
            else
            {
                var sq = Multiply(Scalar<T>.Two, Sqrt(Subtract(Subtract(Add(Scalar<T>.One, row2[2]), row0[0]), row1[1])));

                q.Z = Multiply(NoughtPointTwoFive, sq);
                sq = Divide(Scalar<T>.One, sq);
                q.W = Multiply(Subtract(row1[0], row0[1]), sq);
                q.X = Multiply(Add(row2[0], row0[2]), sq);
                q.Y = Multiply(Add(row2[1], row1[2]), sq);
            }

            return q.GetNormalized();
        }

        public static Matrix3<T> operator *(Matrix3<T> left, Matrix3<T> right) => Matrix3.Multiply(left, right);
        public static bool operator ==(Matrix3<T> left, Matrix3<T> right) => left.Equals(right);
        public static bool operator !=(Matrix3<T> left, Matrix3<T> right) => !(left == right);
        public override string ToString() => $"{Row0}\n{Row1}\n{Row2}";
        public override int GetHashCode() => HashCode.Combine(Row0, Row1, Row2);
        public override bool Equals(object obj) => obj is Matrix3<T> mat && Equals(mat);
        public bool Equals(Matrix3<T> other) => Row0.Equals(other.Row0) && Row1.Equals(other.Row1) && Row2.Equals(other.Row2);
    }
}
