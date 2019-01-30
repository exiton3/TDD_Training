using MPAutomat.Executor;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace MPAutomat.Tests.Executor
{
    [TestFixture]
    public class PushPopCommandTest
    {
        VirtualMachine vm;
        [SetUp]
        public void Init()
        {
            vm = new VirtualMachine();
        }
        [Test]
        public void PushCommandShouldBeCorrectValue()
        {
            IList<Command> program = new List<Command>()
            {
                new Command(Instruction.PUSH,4),
                new Command(Instruction.PUSH,2),
                new Command(Instruction.STOP)
            };
            vm.LoadProgram(program);
            vm.Run();
            int[]actual = vm.GetStack();
            int[] expected = new int[]
            {
                2,4
            };
            actual.Should().Equal(expected);
        }
        [Test]
        public void PopCommandShouldBeCorrectStackValue()
        {
            IList<Command> program = new List<Command>()
            {
                new Command(Instruction.PUSH,4),
                new Command(Instruction.PUSH,2),
                new Command(Instruction.PUSH,1),
                new Command(Instruction.POP),
                new Command(Instruction.STOP)
            };
            vm.LoadProgram(program);
            vm.Run();
            int[] actual = vm.GetStack();
            int[] expected = new int[]
            {
                2,4
            };
            actual.Should().Equal(expected);
        }
        [Test]
        public void PopFromEmtpyStackShouldBeHaltException()
        {
            IList<Command> program = new List<Command>()
            {
                new Command(Instruction.POP),
                new Command(Instruction.STOP)
            };
            vm.LoadProgram(program);
            vm.Invoking(x => x.Run()).Should().Throw<HaltException>();
        }
    }
}
