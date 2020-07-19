using NUnit.Framework;

namespace FixedPoint
{
    public class fixmath3Tests
    {
        [Test]
        public void NormalizationTest()
        {
            var originalVector = new fp3(fp._5, fp._0, fp._0);
            var modifiedVector = fixmath.Normalize(originalVector);

            Assert.That(modifiedVector, Is.EqualTo(new fp3(fp._1, fp._0, fp._0)));
        }
        
        [Test]
        public void MagnitudeTest()
        {
            var originalVector = new fp3(fp._5, fp._0, fp._0);
            var magnitude = fixmath.Magnitude(originalVector);

            Assert.That(magnitude, Is.EqualTo(fp._5));
        }   
        
        [Test]
        public void MagnitudeSqrTest()
        {
            var originalVector = new fp3(fp._5, fp._0, fp._0);
            var magnitude      = fixmath.MagnitudeSqr(originalVector);

            Assert.That(magnitude, Is.EqualTo(fp._5 * fp._5));
        }

        [Test]
        public void MagnitudeClampTest()
        {
            var originalVector = new fp3(fp._5, fp._0, fp._0);
            var clampedVector      = fixmath.MagnitudeClamp(originalVector, fp._1_10);

            Assert.That(clampedVector.x.AsFloat, Is.EqualTo(1.10f).Within(0.01f));
            Assert.That(clampedVector.y.AsFloat, Is.EqualTo(0f));
            Assert.That(clampedVector.z.AsFloat, Is.EqualTo(0f));
        }
        
        [Test]
        public void DotTest()
        {
            var vector1 = new fp3(fp._5, fp._0, fp._0);
            var vector2 = new fp3(fp._5, fp._0, fp._0);
            var dot = fixmath.Dot(vector1, vector2);

            Assert.That(dot, Is.EqualTo(fp._5 * fp._5));
            
            vector1 = new fp3(fp._1, fp._5, fp._4);
            vector2 = new fp3(fp._2, fp._0, fp._1);
            dot     = fixmath.Dot(vector1, vector2);

            Assert.That(dot, Is.EqualTo(fp._6));
            
            vector1 = new fp3(fp._0_10, fp._0_75,   fp._0_10);
            vector2 = new fp3(fp._0_50+fp._0_10, fp._0_20, fp._0_33);
            dot     = fixmath.Dot(vector1, vector2);

            var str = $"{vector1.x.AsFloat},{vector1.y.value},{vector1.z.value} | {vector2} {dot}";

            Assert.That(dot.AsFloat, Is.EqualTo(0.243f).Within(0.01f));
        }

        [Test]
        public void AngleTest()
        {
            var vector1 = new fp3(fp._1, fp._5, fp._4);
            var vector2 = new fp3(fp._2, fp._0, fp._1);
            var angle     = fixmath.Angle(vector1, vector2);

            Assert.That(angle.AsInt, Is.EqualTo(65));
            
            vector1 = new fp3(fp._2, fp._1,   fp._1);
            vector2 = new fp3(fp._2, fp._0, fp._1);
            angle = fixmath.Angle(vector1, vector2);

            Assert.That(angle.AsInt, Is.EqualTo(24));
        }

        [Test]
        public void AngleSignedTest()
        {
            var vector1 = new fp3(fp._1, fp._5,   fp._4);
            var vector2 = new fp3(fp._2, fp._0, fp._1);
            var angle   = fixmath.AngleSigned(vector1, vector2, fp3.up);

            Assert.That(angle.AsInt, Is.EqualTo(65));
            
            vector1 = new fp3(-fp._2, fp._1,   fp._1);
            vector2 = new fp3(fp._2, fp._1, fp._1);
            angle   = fixmath.AngleSigned(vector1, vector2, fp3.up);

            Assert.That(angle.AsFloat, Is.EqualTo(109.47f).Within(0.1f));
        }
        
        [Test]
        public void RadiansTest()
        {
            var vector1 = new fp3(fp._1, fp._5,   fp._4);
            var vector2 = new fp3(fp._2, fp._0, fp._1);
            var angle   = fixmath.Radians(vector1, vector2);

            Assert.That(angle.AsInt, Is.EqualTo(1));
            
            vector1 = new fp3(fp._2, fp._1,   fp._1);
            vector2 = new fp3(fp._2, fp._0, fp._1);
            angle   = fixmath.Radians(vector1, vector2);
            
            Assert.That(angle.AsFloat, Is.EqualTo(0.42f).Within(0.01f));
        }

        [Test]
        public void CrossTest()
        {
            var vector1 = new fp3(fp._1, fp._5,   fp._4);
            var vector2 = new fp3(fp._2, fp._0, fp._1);
            var cross   = fixmath.Cross(vector1, vector2);

            Assert.That(cross, Is.EqualTo(new fp3(fp._5, fp._7, -fp._10)));
        }

        [Test]
        public void ReflectTest()
        {
            var vector     = new fp3(fp._5,  fp._0,   fp._5);
            var normal     = new fp3(-fp._1, fp._0, fp._0);
            var reflection = fixmath.Reflect(vector, normal);

            Assert.That(reflection, Is.EqualTo(new fp3(-fp._5, fp._0, fp._5)));
        }
        
        [Test]
        public void ProjectTest()
        {
            var vector     = new fp3(fp._5,  fp._0, fp._5);
            var normal     = new fp3(-fp._1, fp._0, fp._0);
            var projection = fixmath.Project(vector, normal);

            Assert.That(projection, Is.EqualTo(new fp3(fp._5, fp._0, fp._0)));
        }

        [Test]
        public void ProjectOnPlaneTest()
        {
            var vector     = new fp3(fp._5,  fp._1, fp._5);
            var normal     = new fp3(-fp._1, fp._0, fp._0);
            var projection = fixmath.ProjectOnPlane(vector, normal);

            Assert.That(projection, Is.EqualTo(new fp3(fp._0, fp._1, fp._5)));
        }

        [Test]
        public void LerpTest()
        {
            var @from     = new fp3(fp._5,  fp._0,   fp._5);
            var to     = new fp3(fp._0, fp._0, fp._0);
            var lerped = fixmath.Lerp(@from, to, fp._0_50);

            Assert.That(lerped, Is.EqualTo(new fp3(fp._2+fp._0_50, fp._0, fp._2 +fp._0_50)));
        }

        [Test]
        public void MoveTowardsTest()
        {
            var current = fp3.one;
            var target = new fp3(fp._5, fp._1, fp._1);

            var step1 = fixmath.MoveTowards(current, target, fp._1);
            Assert.That(step1, Is.EqualTo(new fp3(fp._2, fp._1, fp._1)));
            
            var step2 = fixmath.MoveTowards(current, target, fp._10);
            Assert.That(step2, Is.EqualTo(new fp3(fp._5, fp._1, fp._1)));
        }
    }
}