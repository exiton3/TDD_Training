using FluentAssertions;
using MPAutomat.StateMachine;
using NUnit.Framework;
using System;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MPAutomat.StateMachine
{
    [TestFixture]
    public class StateMachineTest
    {
        StateMachine stateMachine;


        [SetUp]
        public void InitTest()
        {
            stateMachine = new StateMachine();
        }
        [Test]
        public void InitializeShouldBeCorrectStateList()
        {
            stateMachine.AddJumper(new Jumper('i', '@', "@", 1, 2));
            stateMachine.AddJumper(new Jumper('n', '@', 2, 3));
            Object[] actual = stateMachine.GetJumpers();
            Jumper[] expected = { new Jumper('i', '@', "@", 1, 2), new Jumper('n', '@', 2, 3) };
            actual.Should().Equals(expected);
        }
        [Test]
        public void PushInStackShouldBeCorrectStack()
        {
            stateMachine.AddJumper(new Jumper('i', '@', "!@#", 0, 1));
            stateMachine.Push("!@#");
            char[] actual = stateMachine.GetStack();
            char[] expected = { '#', '@', '!' };
            actual.Should().Equal(expected);
        }
        [Test]
        public void PutOneSymbolAndSetStackShouldBeCorrectStack()
        {
            stateMachine.AddJumper(new Jumper('i', '#', "!@", 0, 1));
            stateMachine.Push("#");
            stateMachine.Put('i');
            char[] actual = stateMachine.GetStack();
            char[] expected = { '@', '!', '#' };
            actual.Should().Equal(expected);
        }
        [Test]
        public void PutBadSymbolShouldBeNoHaveStateException()
        {
            stateMachine.AddJumper(new Jumper('$', '!', 0, 1));
            stateMachine.Push("!");
            stateMachine.Invoking(x => x.Put('i')).Should().Throw<NoHaveStateException>();
        }
        [Test]
        public void RemoveFromStackOneSymbolShouldBeCorrectStack()
        {
            stateMachine.AddJumper(new Jumper('i', '$', "-", 0, 1));
            stateMachine.Push("!#$");
            stateMachine.Put('i');
            char[] actual = stateMachine.GetStack();
            char[] expected = { '#', '!' };
            actual.Should().Equal(expected);
        }
        [Test]
        public void RemoveFromStackAllSymbolsShouldBeEmptyStack()
        {

            stateMachine.AddJumper(new Jumper('i', '$', "-*", 0, 1));
            stateMachine.Push("#$");
            stateMachine.Put('i');
            char[] actual = stateMachine.GetStack();
            actual.Length.Should().Equals(0);
        }
        [Test]
        public void CallPutTwoShouldBeCorrectChangeState()
        {
            stateMachine.AddJumper(new Jumper('i', '!', "A", 0, 1));
            stateMachine.AddJumper(new Jumper('k', 'A', 1, 2));
            stateMachine.Push("!");
            stateMachine.Put('i');
            stateMachine.Put('k');
            int actual = stateMachine.GetCurrentState();
            actual.Should().Equals(2);
        }
        [Test]
        public void NoJumperCountStateHasZero()
        {
            int actual = stateMachine.GetCountStates();
            actual.Should().Equals(0);
        }
        [Test]
        public void GetTopOnStackShouldBeCorrect()
        {
            stateMachine.Push("@#$");
            char actual = stateMachine.GetTopOnStack();
            actual.Should().Equals('$');
        }
        [Test]
        public void ChangeStateShouldBeCallActionFunction()
        {
            var action = Substitute.For<Action<char>>();
            stateMachine.AddJumper(new Jumper('i', '!', "-", 0, 1, action));
            stateMachine.Push("!");
            stateMachine.Put('i');
            action.Received()(Arg.Is('i'));
        }
    }
}
