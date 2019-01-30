using System;
using System.Data.SqlTypes;
using NUnit.Framework;

namespace NUnitIntroduce {
    [TestFixture]
    public class DateTimeTests {
        [Test]
        public void DateTimeTest() {
            for (var ms = 991; ms <= 999; ms++) {
                var dt = new DateTime(2009, 04, 22, 20, 52, 41, ms);
                var sqldt = new SqlDateTime(dt).Value;
                Assert.That(dt, Is.EqualTo(sqldt));
            }
        }

        [Test]
        public void DateTimeTestCorrect() {
            for (var ms = 991; ms <= 999; ms++) {
                var dt = new DateTime(2009, 04, 22, 20, 52, 41, ms);
                var sqldt = new SqlDateTime(dt).Value;
                Assert.That(dt, Is.EqualTo(sqldt).Within(3).Milliseconds);
            }
        }
    }
}