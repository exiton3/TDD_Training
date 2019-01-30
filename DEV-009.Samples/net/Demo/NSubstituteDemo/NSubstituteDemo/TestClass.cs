using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;

namespace NSubstituteDemo
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestMethod()
        {
            var calculator = Substitute.For<ICalculator>();
            calculator.Add(1, 2).Returns(3);
            Assert.That(calculator.Add(1, 2), Is.EqualTo(3));
            //calculator.Add(5, 7);
            calculator.DidNotReceive().Add(5, 7);

            calculator.Mode.Returns("DEC");
            Assert.That(calculator.Mode, Is.EqualTo("DEC"));

            calculator.Mode = "HEX";
            Assert.That(calculator.Mode, Is.EqualTo("HEX"));

            calculator.Add(10, -5);
            calculator.Received().Add(10, Arg.Any<int>());
            calculator.Received().Add(10, Arg.Is<int>(x => x < 0));

            calculator.Add(Arg.Any<int>(), Arg.Any<int>()).
                Returns(x => (int)x[0] + (int)x[1]);
            Assert.That(calculator.Add(5, 10), Is.EqualTo(15));

            bool eventFired = false;
            calculator.PoweringUp += (sender, args) => eventFired = true;
            calculator.PoweringUp += Raise.Event();
            Assert.That(eventFired, Is.True);

        }
    }
}
