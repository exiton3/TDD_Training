using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParametriseTest
{
    [TestFixture]
    public class TestClass
    {
        [TestCase(12,3,4)]
        [TestCase(12,2,6)]
        [TestCase(12,4,3)]
        public void DivideTest(int n,int d,int q)
        {
            int result = n / d;
            Assert.That(result, Is.EqualTo(q));
        }
        [TestCase(12,3,ExpectedResult =4)]
        [TestCase(12,2,ExpectedResult =6)]
        [TestCase(12,4,ExpectedResult =3)]
        public int DivideTestWithReturnResult(int n,int d)
        {
            return (n / d);
        }
        [TestCaseSource(typeof(ProviderTestData))]
        public void DevideTestWithIEnumerator(int n,int d,int q)
        {
            int result = n / d;
            Assert.That(result, Is.EqualTo(q));
        }
        [TestCaseSource("DivideTestData")]
        public void DevideTestWithStaticSource(int n, int d, int q)
        {
            int result = n / d;
            Assert.That(result, Is.EqualTo(q));
        }
        static object[] DivideTestData =
        {

            new object[]{12,3,4},
            new object[]{12,2,6},
            new object[]{12,4,3}
        };
    }
}
