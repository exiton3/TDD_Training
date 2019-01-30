using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace NUnitIntroduce {
    [TestFixture]
    public class ComparationTest {
        private class Number {
            public Number(int value) {
                Value = value;
            }

            public int Value { get; private set; }
            public int Id { get; set; }
        }

        public class NumberComparer : IComparer {
            public int Compare(object x, object y) {
                return ((Number) x).Value.CompareTo(((Number) y).Value);
            }
        }

        [Test]
        public void UniqNumberConstraintsUsing() {
            var numbers = new[] {new Number(1) {Id = 1}, new Number(2) {Id = 3}, new Number(3) {Id = 3}};
            Assert.That(numbers, Is.Unique.Using(new NumberComparer()));
        }

        [Test]
        public void CustomComparerTest1() {
            Assert.That("a",Is.EqualTo("A")
                .Using<string>((a, b) => String.Compare(a, b, StringComparison.InvariantCultureIgnoreCase)));
        }

        [Test]
        public void CustomComparerTest2() {
            Assert.That("a",Is.EqualTo("A")
                .Using(StringComparer.InvariantCultureIgnoreCase as IComparer<string>));
        }

        [Test]
        public void CustomComparerTest3() {
            Assert.That("a",Is.EqualTo("A")
                .Using(StringComparer.InvariantCultureIgnoreCase as IEqualityComparer<string>));
        }

        [Test]
        public void CustomComparerTest() {
            Assert.That(new[] {"a", "b", "x"},
                Is.EqualTo(new[] {"A", "B", "C"})
                        .Using<string>((a, b) => String.Compare(a, b, StringComparison.InvariantCultureIgnoreCase)));
        }
    }
}