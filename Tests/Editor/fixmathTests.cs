using System;
using System.Numerics;
using NUnit.Framework;

namespace FixedPoint {
    public class fixmathTests {

        [Test]
        public void CountLeadingZerosTest() {
            Assert.That(fixmath.CountLeadingZeroes(5435345), Is.EqualTo(9));
            Assert.That(fixmath.CountLeadingZeroes(4), Is.EqualTo(29));
        }
        
        [Test]
        public void ExpTest() {
            var result = fixmath.Exp(-fp._5);
            Assert.That(result.AsFloat, Is.EqualTo(0.000f).Within(0.01f));

            result = fixmath.Exp(fp._5);
            Assert.That(result.AsFloat, Is.EqualTo(148.413f).Within(0.01f));

            result = fixmath.Exp(fp._5 + fp._0_33);
            Assert.That(result.AsFloat, Is.EqualTo(206.437f).Within(1f));
        }

        [Test]
        public void Exp_2Test() {
            var result = fixmath.ExpApproximated(fp._5);
            Assert.That(result.AsFloat, Is.EqualTo(148.413f).Within(0.6f));

            result = fixmath.ExpApproximated(fp._5 + fp._0_33);
            Assert.That(result.AsFloat, Is.EqualTo(206.437f).Within(1f));
        }

        [Test]
        public void Pow2Test() {
            var result = fixmath.Pow2(fp._5);
            Assert.That(result.AsInt, Is.EqualTo(32));

            result = fixmath.Pow2(fp._10 + fp._0_25);
            Assert.That(result.AsFloat, Is.EqualTo(1217f).Within(2f));
        }

        [Test]
        public void Atan_2Test() {
            var value  = fp._0_95;
            var result = fixmath.AtanApproximated(value);
            Assert.That(result.AsFloat, Is.EqualTo(0.759f).Within(0.01f));

            value  = -fp._1;
            result = fixmath.AtanApproximated(value);
            Assert.That(result.AsFloat, Is.EqualTo(-0.785f).Within(0.01f));

            value  = fp._0;
            result = fixmath.AtanApproximated(value);
            Assert.That(result.AsFloat, Is.EqualTo(0f).Within(0.01f));

            value  = fp._0_25;
            result = fixmath.AtanApproximated(value);
            Assert.That(result.AsFloat, Is.EqualTo(0.245f).Within(0.01f));
        }

        [Test]
        public void AtanTest() {
            var value  = fp._0_95;
            var result = fixmath.Atan(value);
            Assert.That(result.AsFloat, Is.EqualTo(0.759f).Within(0.001f));

            value  = -fp._1;
            result = fixmath.Atan(value);
            Assert.That(result.AsFloat, Is.EqualTo(-0.785f).Within(0.001f));

            value  = fp._0;
            result = fixmath.Atan(value);
            Assert.That(result.AsFloat, Is.EqualTo(0f).Within(0.001f));

            value  = fp._5;
            result = fixmath.Atan(value);
            Assert.That(result.AsFloat, Is.EqualTo(1.373f).Within(0.001f));

            value  = fp._0_25;
            result = fixmath.Atan(value);
            Assert.That(result.AsFloat, Is.EqualTo(0.245f).Within(0.001f));
        }

        [Test]
        public void Atan2Test() {
            var valueA = fp._0_95;
            var valueB = fp._0_95;
            var result = fixmath.Atan2(valueB, valueA);
            Assert.That(result.AsFloat, Is.EqualTo(0.785f).Within(0.001f));

            valueA = fp._0_50;
            valueB = fp._0_25;
            result = fixmath.Atan2(valueB, valueA);
            Assert.That(result.AsFloat, Is.EqualTo(0.463f).Within(0.001f));

            valueA = fp._2;
            valueB = fp._5;
            result = fixmath.Atan2(valueB, valueA);
            Assert.That(result.AsFloat, Is.EqualTo(1.190f).Within(0.001f));
        }

        [Test]
        public void TanTest() {
            var value  = fp._0_75;
            var result = fixmath.Tan(value);
            Assert.That(result.AsFloat, Is.EqualTo(0.931f).Within(0.001f));

            value  = -fp._0_75;
            result = fixmath.Tan(value);
            Assert.That(result.AsFloat, Is.EqualTo(-0.931f).Within(0.001f));

            value  = -fp._1;
            result = fixmath.Tan(value);
            Assert.That(result.AsFloat, Is.EqualTo(-1.557f).Within(0.001f));

            value  = fp._0_25;
            result = fixmath.Tan(value);
            Assert.That(result.AsFloat, Is.EqualTo(0.255f).Within(0.001f));

            value  = fp._1;
            result = fixmath.Tan(value);
            Assert.That(result.AsFloat, Is.EqualTo(1.557f).Within(0.001f));

            value  = fp._0;
            result = fixmath.Tan(value);
            Assert.That(result.AsFloat, Is.EqualTo(0f).Within(0.001f));
        }

        [Test]
        public void AcosTest() {
            var value  = fp._0_75;
            var result = fixmath.Acos(value);
            Assert.That(result.AsFloat, Is.EqualTo(0.722f).Within(0.001f));

            value  = -fp._0_75;
            result = fixmath.Acos(value);
            Assert.That(result.AsFloat, Is.EqualTo(2.418f).Within(0.001f));

            value  = -fp._1;
            result = fixmath.Acos(value);
            Assert.That(result.AsFloat, Is.EqualTo(3.141f).Within(0.001f));

            value  = fp._0_25;
            result = fixmath.Acos(value);
            Assert.That(result.AsFloat, Is.EqualTo(1.318f).Within(0.001f));

            value  = fp._1;
            result = fixmath.Acos(value);
            Assert.That(result.AsFloat, Is.EqualTo(0f).Within(0.001f));

            value  = fp._0;
            result = fixmath.Acos(value);
            Assert.That(result.AsFloat, Is.EqualTo(1.570f).Within(0.001f));
        }

        [Test]
        public void AsinTest() {
            var value  = fp._0_75;
            var result = fixmath.Asin(value);
            Assert.That(result.AsFloat, Is.EqualTo(0.848f).Within(0.001f));

            value  = -fp._0_75;
            result = fixmath.Asin(value);
            Assert.That(result.AsFloat, Is.EqualTo(-0.848f).Within(0.001f));

            value  = -fp._1;
            result = fixmath.Asin(value);
            Assert.That(result.AsFloat, Is.EqualTo(-1.570f).Within(0.001f));

            value  = fp._0_25;
            result = fixmath.Asin(value);
            Assert.That(result.AsFloat, Is.EqualTo(0.252f).Within(0.001f));

            value  = fp._1;
            result = fixmath.Asin(value);
            Assert.That(result.AsFloat, Is.EqualTo(1.570f).Within(0.001f));

            value  = fp._0;
            result = fixmath.Asin(value);
            Assert.That(result.AsFloat, Is.EqualTo(0f).Within(0.001f));
        }

        [Test]
        public void CosTest() {
            var value  = fp._0_25;
            var result = fixmath.Cos(value);
            Assert.That(result.AsFloat, Is.EqualTo(0.969f).Within(0.001f));
        }

        [Test]
        public void SinTest() {
            var value  = fp._0_25;
            var result = fixmath.Sin(value);
            Assert.That(result.AsFloat, Is.EqualTo(0.247f).Within(0.001f));
        }

        [Test]
        public void SinCosTest() {
            var value = fp._0_25;
            fixmath.SinCos(value, out var sin, out var cos);
            Assert.That(sin.AsFloat, Is.EqualTo(0.247f).Within(0.001f));
            Assert.That(cos.AsFloat, Is.EqualTo(0.969f).Within(0.001f));
        }

        [Test]
        public void SinCosTanTest() {
            var value = fp._0_25;
            fixmath.SinCosTan(value, out var sin, out var cos, out var tan);
            Assert.That(sin.AsFloat, Is.EqualTo(0.247f).Within(0.001f));
            Assert.That(cos.AsFloat, Is.EqualTo(0.969f).Within(0.001f));
            Assert.That(tan.AsFloat, Is.EqualTo(0.255f).Within(0.001f));
        }
        
        [Test]
        public void RcpTest() {
            var value = fp._0_25;
            var result = fixmath.Rcp(value);
            Assert.That(result, Is.EqualTo(fp._4));
            
            value = fp._4;
            result = fixmath.Rcp(value);
            Assert.That(result, Is.EqualTo(fp._0_25));
        }

        [Test]
        public void SqrtTest() {
            var value  = fp._5 * fp._5;
            var result = fixmath.Sqrt(value);
            Assert.That(result, Is.EqualTo(fp._5));
        }

        [Test]
        public void FloorTest() {
            var value  = fp._0_25;
            var result = fixmath.Floor(value);
            Assert.That(result, Is.EqualTo(fp._0));

            result = fixmath.Floor(-value);
            Assert.That(result, Is.EqualTo(-fp._1));
        }

        [Test]
        public void CeilTest() {
            var value  = fp._0_25;
            var result = fixmath.Ceil(value);
            Assert.That(result, Is.EqualTo(fp._1));

            result = fixmath.Ceil(-fp._4 - fp._0_25);
            Assert.That(result, Is.EqualTo(-fp._4));
        }

        [Test]
        public void RoundToIntTest() {
            var value  = fp._5 + fp._0_25;
            var result = fixmath.RoundToInt(value);
            Assert.That(result, Is.EqualTo(5));

            result = fixmath.RoundToInt(value + fp._0_33);
            Assert.That(result, Is.EqualTo(6));

            result = fixmath.RoundToInt(value + fp._0_25);
            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void MinTest() {
            var value1 = fp._0_25;
            var value2 = fp._0_33;
            var result = fixmath.Min(value1, value2);
            Assert.That(result, Is.EqualTo(value1));

            result = fixmath.Min(-value1, -value2);
            Assert.That(result, Is.EqualTo(-value2));
        }

        [Test]
        public void MaxTest() {
            var value1 = fp._0_25;
            var value2 = fp._0_33;
            var result = fixmath.Max(value1, value2);
            Assert.That(result, Is.EqualTo(value2));

            result = fixmath.Max(-value1, -value2);
            Assert.That(result, Is.EqualTo(-value1));
        }

        [Test]
        public void AbsTest() {
            var value  = fp._0_25;
            var result = fixmath.Abs(value);
            Assert.That(result, Is.EqualTo(value));

            result = fixmath.Abs(-value);
            Assert.That(result, Is.EqualTo(value));
        }

        [Test]
        public void ClampTest() {
            var result = fixmath.Clamp(fp._0_33, fp._0_25, fp._0_75);
            Assert.That(result, Is.EqualTo(fp._0_33));

            result = fixmath.Clamp(fp._1, fp._0_33, fp._0_75);
            Assert.That(result, Is.EqualTo(fp._0_75));

            result = fixmath.Clamp(fp._0, fp._0_33, fp._0_75);
            Assert.That(result, Is.EqualTo(fp._0_33));
        }

        [Test]
        public void LerpTest() {
            var result = fixmath.Lerp(fp._2, fp._4, fp._0_25);
            Assert.That(result, Is.EqualTo(fp._2 + fp._0_50));

            result = fixmath.Lerp(fp._2, fp._4, fp._0);
            Assert.That(result, Is.EqualTo(fp._2));

            result = fixmath.Lerp(fp._2, fp._4, fp._1);
            Assert.That(result, Is.EqualTo(fp._4));

            result = fixmath.Lerp(fp._2, fp._4, fp._0_50);
            Assert.That(result, Is.EqualTo(fp._3));
        }

        [Test]
        public void SignTest() {
            var result = fixmath.Sign(fp._0_25);
            Assert.That(result, Is.EqualTo(fp._1));

            result = fixmath.Sign(-fp._0_25);
            Assert.That(result, Is.EqualTo(-fp._1));
        }

        [Test]
        public void IsOppositeSignTest() {
            var result = fixmath.IsOppositeSign(fp._0_25, -fp._0_20);
            Assert.That(result, Is.EqualTo(true));

            result = fixmath.IsOppositeSign(fp._0_25, fp._0_20);
            Assert.That(result, Is.EqualTo(false));

            result = fixmath.IsOppositeSign(-fp._0_25, -fp._0_20);
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void Sin2Test() {
            fixmath.SinCosTan(fp._0_20, out var sin, out var cos, out var tan);
            var bbb = sin;
        }
    }
}