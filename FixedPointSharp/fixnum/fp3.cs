﻿using System;
using System.Collections.Generic;

namespace FixedPoint
{
    public struct fp3 : IEquatable<fp3>
    {
        public class EqualityComparer : IEqualityComparer<fp3>
        {
            public static readonly EqualityComparer instance = new EqualityComparer();

            EqualityComparer()
            {
            }

            bool IEqualityComparer<fp3>.Equals(fp3 x, fp3 y)
            {
                return x == y;
            }

            int IEqualityComparer<fp3>.GetHashCode(fp3 obj)
            {
                return obj.GetHashCode();
            }
        }

        public static readonly fp3 left     = new fp3(-fp.one, fp.zero, fp.zero);
        public static readonly fp3 right    = new fp3(+fp.one, fp.zero, fp.zero);
        public static readonly fp3 up       = new fp3(fp.zero, +fp.one, fp.zero);
        public static readonly fp3 forward  = new fp3(fp.zero, fp.zero, fp.one);
        public static readonly fp3 backward = new fp3(fp.zero, fp.zero, fp.minus_one);
        public static readonly fp3 one      = new fp3(fp.one,  fp.one,  fp.one);
        public static readonly fp3 zero     = new fp3(fp.zero, fp.zero, fp.zero);

        public fp x;
        public fp y;
        public fp z;

        public fp3(fp x, fp y, fp z)
        {
            this.x.value = x.value;
            this.y.value = y.value;
            this.z.value = z.value;
        }

        public static fp3 X(fp x)
        {
            fp3 r;

            r.x.value = x.value;
            r.y.value = 0;
            r.z.value = 0;

            return r;
        }

        public static fp3 Y(fp y)
        {
            fp3 r;

            r.x.value = 0;
            r.y.value = y.value;
            r.z.value = 0;

            return r;
        }

        public static fp3 Z(fp z)
        {
            fp3 r;

            r.x.value = 0;
            r.y.value = 0;
            r.z.value = z.value;

            return r;
        }


        public static fp3 operator +(fp3 a, fp3 b)
        {
            fp3 r;

            r.x.value = a.x.value + b.x.value;
            r.y.value = a.y.value + b.y.value;
            r.z.value = a.z.value + b.z.value;

            return r;
        }

        public static fp3 operator -(fp3 a, fp3 b)
        {
            fp3 r;

            r.x.value = a.x.value - b.x.value;
            r.y.value = a.y.value - b.y.value;
            r.z.value = a.z.value - b.z.value;

            return r;
        }

        public static fp3 operator -(fp3 a)
        {
            a.x.value = -a.x.value;
            a.y.value = -a.y.value;
            a.z.value = -a.z.value;

            return a;
        }

        public static fp3 operator *(fp3 a, fp b)
        {
            fp3 r;

            r.x.value = ((a.x.value * b.value) >> fixlut.PRECISION);
            r.y.value = ((a.y.value * b.value) >> fixlut.PRECISION);
            r.z.value = ((a.z.value * b.value) >> fixlut.PRECISION);

            return r;
        }

        public static fp3 operator *(fp b, fp3 a)
        {
            fp3 r;

            r.x.value = ((a.x.value * b.value) >> fixlut.PRECISION);
            r.y.value = ((a.y.value * b.value) >> fixlut.PRECISION);
            r.z.value = ((a.z.value * b.value) >> fixlut.PRECISION);

            return r;
        }

        public static fp3 operator /(fp3 a, fp b)
        {
            fp3 r;

            r.x.value = ((a.x.value << fixlut.PRECISION) / b.value);
            r.y.value = ((a.y.value << fixlut.PRECISION) / b.value);
            r.z.value = ((a.z.value << fixlut.PRECISION) / b.value);

            return r;
        }

        public static fp3 operator /(fp b, fp3 a)
        {
            fp3 r;

            r.x.value = ((a.x.value << fixlut.PRECISION) / b.value);
            r.y.value = ((a.y.value << fixlut.PRECISION) / b.value);
            r.z.value = ((a.z.value << fixlut.PRECISION) / b.value);

            return r;
        }


        public static bool operator ==(fp3 a, fp3 b)
        {
            return a.x.value == b.x.value && a.y.value == b.y.value && a.z.value == b.z.value;
        }

        public static bool operator !=(fp3 a, fp3 b)
        {
            return a.x.value != b.x.value || a.y.value != b.y.value || a.z.value != b.z.value;
        }

        public bool Equals(fp3 other)
        {
            return x.Equals(other.x) && y.Equals(other.y) && z.Equals(other.z);
        }

        public override bool Equals(object obj)
        {
            return obj is fp3 other && this == other;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = x.GetHashCode();
                hashCode = (hashCode * 397) ^ y.GetHashCode();
                hashCode = (hashCode * 397) ^ z.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"({x}, {y}, {z})";
        }
    }
}