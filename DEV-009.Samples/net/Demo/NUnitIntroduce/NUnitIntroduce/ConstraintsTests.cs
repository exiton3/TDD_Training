using System;
using System.Collections;
using NUnit.Framework;

namespace NUnitIntroduce {
    [TestFixture]
    public class ConstraintsTests {
        private class Number {
            public Number(int value) {
                Value = value;
            }

            public int Value { get; private set; }
            public int Id { get; set; }
        }

        [Test]
        public void CollectionOrderedConstraintTest() {
            Assert.That(new[] {1, 2, 3}, Is.Ordered);

            Assert.That(new[] {3, 2, 1}, Is.Ordered.Using<int>((a, b) => -a.CompareTo(b)));

            Number[] numbers1 = {new Number(1), new Number(2), new Number(3)};
            Assert.That(numbers1, Is.Ordered.By("Value"));

            Number[] numbers2 = {new Number(3), new Number(2), new Number(1)};
            Assert.That(numbers2, Is.Ordered.By("Value").Using<int>((a, b) => -a.CompareTo(b)));
        }

        public class NumberComparer : IComparer {
            public int Compare(object x, object y) {
                return ((Number) x).Value.CompareTo(((Number) y).Value);
            }
        }

        [Test]
        public void UniqNumberConstraintsUsing() {
            Assert.That(new[] { new Number(1) { Id = 1 }, new Number(2) { Id = 3 }, new Number(3) { Id = 3 } }, 
                Is.Unique.Using(new NumberComparer()));
        }

        [Test]
        public void UniqNumberConstraints() {
            Assert.That(new[] { 1, 2, 3 }, Is.Unique);
        }
    }
}