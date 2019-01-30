using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPAutomat.Executor;
using FluentAssertions;

namespace MPAutomat.Tests.Executor
{
    [TestFixture]
    public class VirtualMachineTest
    {
        private VirtualMachine vm;        IList<Command> program;
        [SetUp]
        public void Init()
        {
            program = new List<Command>()
            {
                new Command(Instruction.PUSH,4),
                new Command(Instruction.PUSH,2),
                new Command(Instruction.STOP)
            };
            vm = new VirtualMachine();

        }
        [Test]
        public void LoadProgramShouldBeOk()
        {
            vm.LoadProgram(program);
        }
        [Test]
        public void RunProgramShouldBeOk()
        {
            vm.LoadProgram(program);
            vm.Run();
        }
        [Test]
        public void NoProgramLoadShouldBeException()
        {
            vm.Invoking(x => x.Run()).Should().Throw<NoProgramLoadException>();
        }
        [Test]
        public void TryLoadEmptyProgramShouldBeException()
        {
            IList<Command> program = new List<Command>();
            vm.LoadProgram(program);
            vm.Invoking(x => x.Run()).Should().Throw<BadProgramException>();
        }
        [Test]
        public void NoStopInstructionInProgramShouldBeException()
        {
            IList<Command> program = new List<Command>()
            {
                new Command(Instruction.PUSH,0)
            };
            vm.LoadProgram(program);
            vm.Invoking(x => x.Run()).Should().Throw<HaltException>();
        }
    }
}
