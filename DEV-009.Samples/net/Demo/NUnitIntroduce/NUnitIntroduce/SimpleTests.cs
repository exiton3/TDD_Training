using NUnit.Framework;

namespace NUnitIntroduce {
    [TestFixture]
    public class SimpleTests {
        [Test]
        public void RangeAssert() {
            Assert.That(2, Is.InRange(1, 3));
        }
    }
}