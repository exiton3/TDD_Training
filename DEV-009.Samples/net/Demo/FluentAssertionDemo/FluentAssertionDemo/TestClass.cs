using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using System.Collections;

namespace FluentAssertionDemo
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void FluentForObject()
        {
            object theObject = null;
            theObject.Should().BeNull("value must be null");
            theObject.Should().NotBeNull("must be not null");

            theObject = "test test";
            theObject.Should().BeOfType<string>("because a {0} is set", typeof(string));
        }
        [Test]
        public void FluentForNullable()
        {
            short? theShort = null;
            theShort.Should().NotHaveValue();
            int? theInt = 3;
            theInt.Should().HaveValue();
        }
        [Test]
        public void FluentForBool()
        {
            bool theBool = false;
            theBool.Should().BeTrue();
            theBool.Should().BeFalse();
        }
        [Test]
        public void FluentForString()
        {
            string theString = "";
            theString.Should().NotBeNull();
            theString.Should().NotBeEmpty();
            theString.Should().HaveLength(9);
            theString.Should().BeNullOrWhiteSpace();
            theString.Should().Contain("as is");
            theString.Should().StartWith("run");
            theString.Should().Match("@*.com");
        }
        [Test]
        public void FluentForInt()
        {
            int theInt = 5;
            theInt.Should().BeGreaterThan(5);
            theInt.Should().BeLessThan(4);
            theInt.Should().BeInRange(1, 10);
        }
        [Test]
        public void FluentForComplexExpression()
        {
            int theInt = 5;
            theInt.Should().BeGreaterThan(10).And.BeLessThan(-10);
        }
        [Test]
        public void FluentForCollection()
        {
            IEnumerable<int> collection = new[] { 1, 2, 3, 4, 5 };
            collection.Should().NotBeEmpty().And
                .HaveCount(4).And
                .ContainInOrder(new[] { 2, 5 }).And
                .ContainItemsAssignableTo<int>();
            collection.Should().Contain(x => x > 3);
            collection.Should().ContainSingle(x => x > 5);
        }
        [Test]
        public void FluentForException()
        {
            Action act = () => new Foo().MakeIt();
            act.ShouldThrow<NotImplementedException>().WithInnerMessage("!!!");
        }
    }
}
