using NUnit.Framework;

namespace NUnitIntroduce {
    [TestFixture]
    public class NumbersTests {
        [Test]
        public void DoubleTestsInAbsoluteValue() {
            Assert.That(1.5, Is.EqualTo(2).Within(1));
        }

        [Test]
        public void DoubleTestsInPercentValue() {
            Assert.That(1.5, Is.EqualTo(2).Within(50).Percent);
        }
    }
}