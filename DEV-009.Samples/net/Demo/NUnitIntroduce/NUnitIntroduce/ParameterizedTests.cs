using System;
using System.Collections;
using NUnit.Framework;

namespace NUnitIntroduce {
    [TestFixture]
    public class ParameterizedTests {
        [TestCase(2, 3, 6)]
        public void ParameterizedTest(int a, int b, int result) {
            Assert.That(a*b, Is.EqualTo(result));
        }

        [TestCase(2, 3, Result = 6)]
        public int ParameterizedTest1(int a, int b) {
            return a*b;
        }

        private object[] TestData ={new object[] {2m, 3m, 6m}};

        [Test]
        [TestCaseSource("TestData")]
        public void ParameterizedTest2(decimal a, decimal b, decimal result) {
            Assert.That(a*b, Is.EqualTo(result));
        }

        IEnumerable TestData1 {
            get {
                yield return new TestCaseData(6, 3).Returns(2);
                yield return new TestCaseData(6, 0).Throws(typeof(DivideByZeroException));
            }
        }

        [Test]
        [TestCaseSource("TestData1")]
        public int ParameterizedTest5(int a, int b) {
            return a / b;
        }
    }
}