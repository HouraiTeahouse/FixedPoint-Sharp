using FixedPoint;
using NUnit.Framework;

namespace FPTesting {
    public class randomTests {
        [Test]
        public void BoolTest()
        {
            var random = new Random(645);
            Assert.That(random.NextBool(), Is.EqualTo(true));
            
            random.SetState(435);
            Assert.That(random.NextBool(), Is.EqualTo(false));
        }
        
        [Test]
        public void IntTest()
        {
            var random = new Random(645);
            Assert.That(random.NextInt(), Is.EqualTo(-1975191795));
            
            random.SetState(435);
            Assert.That(random.NextInt(), Is.EqualTo(-2030414680));
        }

        [Test]
        public void IntMaxTest()
        {
            var random = new Random(345345346);
            for (uint i = 5; i < 100; i++) {
                Assert.That(random.NextInt(30), Is.LessThan(31));
            }
        }
        
        [Test]
        public void IntMinMaxTest()
        {
            var random = new Random(345345346);
            for (var i = 0; i < 100; i++) { 
                Assert.That(random.NextInt(-30, 30), Is.InRange(-30, 30));
            }
        }
        
        [Test]
        public void FpTest()
        {
            var random = new Random(645);
            Assert.That(random.NextFp().value, Is.EqualTo(2628L));
            
            random.SetState(435);
            Assert.That(random.NextFp().value, Is.EqualTo(1786L));
        }
        
        [Test]
        public void FpMaxTest()
        {
            var random = new Random(345345346);
            for (uint i = 5; i < 100; i++) {
                Assert.That(random.NextFp(fp._100), Is.LessThan(fp._100));
            }
        }
        
        [Test]
        public void FpMinMaxTest()
        {
            var random = new Random(345345346);
            for (uint i = 5; i < 100; i++) {
                Assert.That(random.NextFp(fp._99, fp._100), Is.InRange(fp._99, fp._100));
            }
        }
    }
}