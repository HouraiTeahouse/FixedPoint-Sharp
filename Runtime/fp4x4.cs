using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FixedPoint
{
    // A standard 4x4 transformation matrix.
    [StructLayout(LayoutKind.Sequential)]
    public partial struct fp4x4 : IEquatable<fp4x4>
    {
        // memory layout:
        //
        //                row no (=vertical)
        //               |  0   1   2   3
        //            ---+----------------
        //            0  | m00 m10 m20 m30
        // column no  1  | m01 m11 m21 m31
        // (=horiz)   2  | m02 m12 m22 m32
        //            3  | m03 m13 m23 m33

        public fp m00;
        public fp m10;
        public fp m20;
        public fp m30;

        public fp m01;
        public fp m11;
        public fp m21;
        public fp m31;

        public fp m02;
        public fp m12;
        public fp m22;
        public fp m32;

        public fp m03;
        public fp m13;
        public fp m23;
        public fp m33;

        public fp4x4(fp4 column0, fp4 column1, fp4 column2, fp4 column3)
        {
            this.m00 = column0.x; this.m01 = column1.x; this.m02 = column2.x; this.m03 = column3.x;
            this.m10 = column0.y; this.m11 = column1.y; this.m12 = column2.y; this.m13 = column3.y;
            this.m20 = column0.z; this.m21 = column1.z; this.m22 = column2.z; this.m23 = column3.z;
            this.m30 = column0.w; this.m31 = column1.w; this.m32 = column2.w; this.m33 = column3.w;
        }

        // Access element at [row, column].
        public fp this[int row, int column]
        {
            get
            {
                return this[row + column * 4];
            }

            set
            {
                this[row + column * 4] = value;
            }
        }

        // Access element at sequential index (0..15 inclusive).
        public fp this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return m00;
                    case 1: return m10;
                    case 2: return m20;
                    case 3: return m30;
                    case 4: return m01;
                    case 5: return m11;
                    case 6: return m21;
                    case 7: return m31;
                    case 8: return m02;
                    case 9: return m12;
                    case 10: return m22;
                    case 11: return m32;
                    case 12: return m03;
                    case 13: return m13;
                    case 14: return m23;
                    case 15: return m33;
                    default:
                        throw new IndexOutOfRangeException("Invalid matrix index!");
                }
            }

            set
            {
                switch (index)
                {
                    case 0: m00 = value; break;
                    case 1: m10 = value; break;
                    case 2: m20 = value; break;
                    case 3: m30 = value; break;
                    case 4: m01 = value; break;
                    case 5: m11 = value; break;
                    case 6: m21 = value; break;
                    case 7: m31 = value; break;
                    case 8: m02 = value; break;
                    case 9: m12 = value; break;
                    case 10: m22 = value; break;
                    case 11: m32 = value; break;
                    case 12: m03 = value; break;
                    case 13: m13 = value; break;
                    case 14: m23 = value; break;
                    case 15: m33 = value; break;

                    default:
                        throw new IndexOutOfRangeException("Invalid matrix index!");
                }
            }
        }

        // used to allow fp4x4s to be used as keys in hash tables
        public override int GetHashCode()
        {
            return GetColumn(0).GetHashCode() ^ (GetColumn(1).GetHashCode() << 2) ^ (GetColumn(2).GetHashCode() >> 2) ^ (GetColumn(3).GetHashCode() >> 1);
        }

        // also required for being able to use fp4x4s as keys in hash tables
        public override bool Equals(object other)
        {
            if (!(other is fp4x4)) return false;

            return Equals((fp4x4)other);
        }

        public bool Equals(fp4x4 other)
        {
            return GetColumn(0).Equals(other.GetColumn(0))
                && GetColumn(1).Equals(other.GetColumn(1))
                && GetColumn(2).Equals(other.GetColumn(2))
                && GetColumn(3).Equals(other.GetColumn(3));
        }

        // Multiplies two matrices.
        public static fp4x4 operator*(fp4x4 lhs, fp4x4 rhs)
        {
            fp4x4 res;
            res.m00 = lhs.m00 * rhs.m00 + lhs.m01 * rhs.m10 + lhs.m02 * rhs.m20 + lhs.m03 * rhs.m30;
            res.m01 = lhs.m00 * rhs.m01 + lhs.m01 * rhs.m11 + lhs.m02 * rhs.m21 + lhs.m03 * rhs.m31;
            res.m02 = lhs.m00 * rhs.m02 + lhs.m01 * rhs.m12 + lhs.m02 * rhs.m22 + lhs.m03 * rhs.m32;
            res.m03 = lhs.m00 * rhs.m03 + lhs.m01 * rhs.m13 + lhs.m02 * rhs.m23 + lhs.m03 * rhs.m33;

            res.m10 = lhs.m10 * rhs.m00 + lhs.m11 * rhs.m10 + lhs.m12 * rhs.m20 + lhs.m13 * rhs.m30;
            res.m11 = lhs.m10 * rhs.m01 + lhs.m11 * rhs.m11 + lhs.m12 * rhs.m21 + lhs.m13 * rhs.m31;
            res.m12 = lhs.m10 * rhs.m02 + lhs.m11 * rhs.m12 + lhs.m12 * rhs.m22 + lhs.m13 * rhs.m32;
            res.m13 = lhs.m10 * rhs.m03 + lhs.m11 * rhs.m13 + lhs.m12 * rhs.m23 + lhs.m13 * rhs.m33;

            res.m20 = lhs.m20 * rhs.m00 + lhs.m21 * rhs.m10 + lhs.m22 * rhs.m20 + lhs.m23 * rhs.m30;
            res.m21 = lhs.m20 * rhs.m01 + lhs.m21 * rhs.m11 + lhs.m22 * rhs.m21 + lhs.m23 * rhs.m31;
            res.m22 = lhs.m20 * rhs.m02 + lhs.m21 * rhs.m12 + lhs.m22 * rhs.m22 + lhs.m23 * rhs.m32;
            res.m23 = lhs.m20 * rhs.m03 + lhs.m21 * rhs.m13 + lhs.m22 * rhs.m23 + lhs.m23 * rhs.m33;

            res.m30 = lhs.m30 * rhs.m00 + lhs.m31 * rhs.m10 + lhs.m32 * rhs.m20 + lhs.m33 * rhs.m30;
            res.m31 = lhs.m30 * rhs.m01 + lhs.m31 * rhs.m11 + lhs.m32 * rhs.m21 + lhs.m33 * rhs.m31;
            res.m32 = lhs.m30 * rhs.m02 + lhs.m31 * rhs.m12 + lhs.m32 * rhs.m22 + lhs.m33 * rhs.m32;
            res.m33 = lhs.m30 * rhs.m03 + lhs.m31 * rhs.m13 + lhs.m32 * rhs.m23 + lhs.m33 * rhs.m33;

            return res;
        }

        // Transforms a [[fp4]] by a matrix.
        public static fp4 operator*(fp4x4 lhs, fp4 vector)
        {
            fp4 res;
            res.x = lhs.m00 * vector.x + lhs.m01 * vector.y + lhs.m02 * vector.z + lhs.m03 * vector.w;
            res.y = lhs.m10 * vector.x + lhs.m11 * vector.y + lhs.m12 * vector.z + lhs.m13 * vector.w;
            res.z = lhs.m20 * vector.x + lhs.m21 * vector.y + lhs.m22 * vector.z + lhs.m23 * vector.w;
            res.w = lhs.m30 * vector.x + lhs.m31 * vector.y + lhs.m32 * vector.z + lhs.m33 * vector.w;
            return res;
        }

        //*undoc*
        public static bool operator==(fp4x4 lhs, fp4x4 rhs)
        {
            // Returns false in the presence of NaN values.
            return lhs.GetColumn(0) == rhs.GetColumn(0)
                && lhs.GetColumn(1) == rhs.GetColumn(1)
                && lhs.GetColumn(2) == rhs.GetColumn(2)
                && lhs.GetColumn(3) == rhs.GetColumn(3);
        }

        //*undoc*
        public static bool operator!=(fp4x4 lhs, fp4x4 rhs)
        {
            // Returns true in the presence of NaN values.
            return !(lhs == rhs);
        }

        // Get a column of the matrix.
        public fp4 GetColumn(int index)
        {
            switch (index)
            {
                case 0: return new fp4(m00, m10, m20, m30);
                case 1: return new fp4(m01, m11, m21, m31);
                case 2: return new fp4(m02, m12, m22, m32);
                case 3: return new fp4(m03, m13, m23, m33);
                default:
                    throw new IndexOutOfRangeException("Invalid column index!");
            }
        }

        // Returns a row of the matrix.
        public fp4 GetRow(int index)
        {
            switch (index)
            {
                case 0: return new fp4(m00, m01, m02, m03);
                case 1: return new fp4(m10, m11, m12, m13);
                case 2: return new fp4(m20, m21, m22, m23);
                case 3: return new fp4(m30, m31, m32, m33);
                default:
                    throw new IndexOutOfRangeException("Invalid row index!");
            }
        }

        // Sets a column of the matrix.
        public void SetColumn(int index, fp4 column)
        {
            this[0, index] = column.x;
            this[1, index] = column.y;
            this[2, index] = column.z;
            this[3, index] = column.w;
        }

        // Sets a row of the matrix.
        public void SetRow(int index, fp4 row)
        {
            this[index, 0] = row.x;
            this[index, 1] = row.y;
            this[index, 2] = row.z;
            this[index, 3] = row.w;
        }

        // Transforms a position by this matrix, with a perspective divide. (generic)
        public fp3 MultiplyPoint(fp3 point)
        {
            fp3 res;
            fp w;
            res.x = this.m00 * point.x + this.m01 * point.y + this.m02 * point.z + this.m03;
            res.y = this.m10 * point.x + this.m11 * point.y + this.m12 * point.z + this.m13;
            res.z = this.m20 * point.x + this.m21 * point.y + this.m22 * point.z + this.m23;
            w = this.m30 * point.x + this.m31 * point.y + this.m32 * point.z + this.m33;

            w = fp._1 / w;
            res.x *= w;
            res.y *= w;
            res.z *= w;
            return res;
        }

        // Transforms a position by this matrix, without a perspective divide. (fast)
        public fp3 MultiplyPoint3x4(fp3 point)
        {
            fp3 res;
            res.x = this.m00 * point.x + this.m01 * point.y + this.m02 * point.z + this.m03;
            res.y = this.m10 * point.x + this.m11 * point.y + this.m12 * point.z + this.m13;
            res.z = this.m20 * point.x + this.m21 * point.y + this.m22 * point.z + this.m23;
            return res;
        }

        // Transforms a direction by this matrix.
        public fp3 MultiplyVector(fp3 vector)
        {
            fp3 res;
            res.x = this.m00 * vector.x + this.m01 * vector.y + this.m02 * vector.z;
            res.y = this.m10 * vector.x + this.m11 * vector.y + this.m12 * vector.z;
            res.z = this.m20 * vector.x + this.m21 * vector.y + this.m22 * vector.z;
            return res;
        }

        // Creates a scaling matrix.
        public static fp4x4 Scale(fp3 vector)
        {
            fp4x4 m;
            m.m00 = vector.x; m.m01 = fp._0; m.m02 = fp._0; m.m03 = fp._0;
            m.m10 = fp._0; m.m11 = vector.y; m.m12 = fp._0; m.m13 = fp._0;
            m.m20 = fp._0; m.m21 = fp._0; m.m22 = vector.z; m.m23 = fp._0;
            m.m30 = fp._0; m.m31 = fp._0; m.m32 = fp._0; m.m33 = fp._1;
            return m;
        }

        // Creates a translation matrix.
        public static  fp4x4 Translate(fp3 vector)
        {
            fp4x4 m;
            m.m00 = fp._1; m.m01 = fp._0; m.m02 = fp._0; m.m03 = vector.x;
            m.m10 = fp._0; m.m11 = fp._1; m.m12 = fp._0; m.m13 = vector.y;
            m.m20 = fp._0; m.m21 = fp._0; m.m22 = fp._1; m.m23 = vector.z;
            m.m30 = fp._0; m.m31 = fp._0; m.m32 = fp._0; m.m33 = fp._1;
            return m;
        }

        // Creates a rotation matrix. Note: Assumes unit quaternion
        public static fp4x4 Rotate(fp4 q)
        {
            // Precalculate coordinate products
            fp x = q.x * fp._2;
            fp y = q.y * fp._2;
            fp z = q.z * fp._2;
            fp xx = q.x * x;
            fp yy = q.y * y;
            fp zz = q.z * z;
            fp xy = q.x * y;
            fp xz = q.x * z;
            fp yz = q.y * z;
            fp wx = q.w * x;
            fp wy = q.w * y;
            fp wz = q.w * z;

            // Calculate 3x3 matrix from orthonormal basis
            fp4x4 m;
            m.m00 = fp._1 - (yy + zz); m.m10 = xy + wz; m.m20 = xz - wy; m.m30 = fp._0;
            m.m01 = xy - wz; m.m11 = fp._1 - (xx + zz); m.m21 = yz + wx; m.m31 = fp._0;
            m.m02 = xz + wy; m.m12 = yz - wx; m.m22 = fp._1 - (xx + yy); m.m32 = fp._0;
            m.m03 = fp._0; m.m13 = fp._0; m.m23 = fp._0; m.m33 = fp._1;
            return m;
        }

        // fp4x4.zero is of questionable usefulness considering C# sets everything to 0 by default, however:
        //  1. it's consistent with other Math structs in Unity such as Vector2, fp3 and fp4,
        //  2. "fp4x4.zero" is arguably more readable than "new fp4x4()",
        //  3. it's already in the API ..
        static readonly fp4x4 zeroMatrix = new fp4x4(new fp4(fp._0, fp._0, fp._0, fp._0),
            new fp4(fp._0, fp._0, fp._0, fp._0),
            new fp4(fp._0, fp._0, fp._0, fp._0),
            new fp4(fp._0, fp._0, fp._0, fp._0));

        // Returns a matrix with all elements set to zero (RO).
        public static fp4x4 zero  => zeroMatrix;

        static readonly fp4x4 identityMatrix = new fp4x4(new fp4(fp._1, fp._0, fp._0, fp._0),
            new fp4(fp._0, fp._1, fp._0, fp._0),
            new fp4(fp._0, fp._0, fp._1, fp._0),
            new fp4(fp._0, fp._0, fp._0, fp._1));

        // Returns the identity matrix (RO).
        public static fp4x4 identity  => identityMatrix;

        public override string ToString()
        {
            return String.Format("{0}\t{1}\t{2}\t{3}\n{4}\t{5}\t{6}\t{7}\n{8}\t{9}\t{10}\t{11}\n{12}\t{13}\t{14}\t{15}\n",
                m00, m01, m02, m03, m10, m11, m12, m13, m20, m21, m22, m23, m30, m31, m32, m33);
        }
    }
} //namespace
