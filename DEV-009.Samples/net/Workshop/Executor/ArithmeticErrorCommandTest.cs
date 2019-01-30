using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using MPAutomat.Executor;

namespace MPAutomat.Tests.Executor
{
    [TestFixture]
    public class ArithmeticErrorCommandTest
    {
        VirtualMachine vm;
        IList<Command> program;
        [SetUp]
        public void Init()
        {
            vm = new VirtualMachine();
            program = new List<Command>()
            {
                new Command(Instruction.PUSH,1),
                new Command(Instruction.STOP)
            };
        }
        [Test]
        [TestCase(Instruction.ADD)]
        [TestCase(Instruction.SUB)]
        [TestCase(Instruction.MUL)]
        [TestCase(Instruction.DIV)]
        public void ArihtmeticMissingOperandShouldBeBadProgramException(Instruction arhitmeticCommand)
        {
            
            program.Insert(1, new Command(arhitmeticCommand));
            vm.LoadProgram(program);
            vm.Invoking(x => x.Run()).Should().Throw<BadProgramException>();
           
        }
        [Test] 
        public void DivideByZeroShouldBeArihtmeticException()
        {
            IList<Command> program = new List<Command>()
            {
                new Command(Instruction.PUSH,2),
                new Command(Instruction.PUSH,0),
                new Command(Instruction.DIV),
                new Command(Instruction.STOP)
            };
            vm.LoadProgram(program);
            vm.Invoking(x => x.Run()).Should().Throw<ArithmeticErrorException>();
        }
    }
}