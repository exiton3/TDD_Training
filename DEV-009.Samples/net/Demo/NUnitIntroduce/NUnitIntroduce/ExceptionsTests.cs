using System;
using NUnit.Framework;

namespace NUnitIntroduce {
    [TestFixture]
    public class ExceptionsTests {
        class Worker {
            public void DoSomething() {
                throw new Exception("Trulala");
            }
        }

        [Test]
        public void NewVariant() {
            Assert.That(() => new Worker().DoSomething(),
                        Throws.InstanceOf<Exception>().And.Message.Contains("Trulala"));
        }

        [Test]
        [ExpectedException(
            ExpectedException = typeof (Exception),
            ExpectedMessage = "Trulala",
            MatchType = MessageMatch.Contains)]
        public void OldStyle() {
            new Worker().DoSomething();
        }
    }
}