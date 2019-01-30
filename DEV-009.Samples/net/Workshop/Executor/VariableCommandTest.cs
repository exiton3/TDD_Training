using MPAutomat.Executor;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using MPAutomat.Db;
using FluentAssertions;

namespace MPAutomat.Tests.Executor
{
    [TestFixture]
    public class VariableCommandTest
    {
        VirtualMachine vm;

        [SetUp]
        public void Init()
        {
        }
        [Test]
        public void StoreValueFromStackShouldBeCorrectValue()
        {
            IStorage storage = Substitute.For<IStorage>();
            vm = new VirtualMachine(storage);
            IList<Command> program = new List<Command>()
            {
                new Command(Instruction.PUSH,4),
                new Command(Instruction.STORE,"Test"),
                new Command(Instruction.STOP)
            };
            vm.LoadProgram(program);
            vm.Run();
            storage.Received().SetValue("Test", 4);
        }
        [Test]
        public void SaveValueWithNullNameFromStackShouldBeException()
        {
            IList<Command> program = new List<Command>()
            {
                new Command(Instruction.PUSH,4),
                new Command(Instruction.STORE,null),
                new Command(Instruction.STOP)
            };
            VirtualMachine vm = new VirtualMachine();
            vm.LoadProgram(program);
            vm.Invoking(x => x.Run()).Should().Throw<BadProgramException>();
        }
        [Test]
        public void LoadValueToStackShouldBeCorrectTopStack()
        {
            IList<Command> program = new List<Command>()
            {
                new Command(Instruction.LOAD,"Test"),
                new Command(Instruction.STOP)
            };
            IStorage storage = Substitute.For<IStorage>();
            storage.GetValue("Test").Returns(4);
            VirtualMachine vm = new VirtualMachine(storage);
            vm.LoadProgram(program);
            vm.Run();
            int actual = (int)vm.GetTopStack();
            actual.Should().Equals(4);
        }
        [Test]
        public void LoadValueWithNullNameToStackShouldBeException()
        {
            IList<Command> program = new List<Command>()
            {
                new Command(Instruction.LOAD,null),
                new Command(Instruction.STOP)
            };
            VirtualMachine vm = new VirtualMachine();
            vm.LoadProgram(program);
            vm.Invoking(x => x.Run()).Should().Throw<BadProgramException>();
        }
        [Test]
        public void TrySaveValueFromEmptyStackShouldBeError()
        {
            IList<Command> program = new List<Command>()
            {
                new Command(Instruction.STORE,"Test"),
                new Command(Instruction.STOP)
            };
            IStorage storage = Substitute.For<IStorage>();

            VirtualMachine vm = new VirtualMachine(storage);
            vm.LoadProgram(program);
            vm.Invoking(x => x.Run()).Should().Throw<BadProgramException>();
            storage.DidNotReceive().SetValue("Test", 4);
        }
        [Test]
        public void SetVariableShouldBeOk()
        {
            IStorage storage = Substitute.For<IStorage>();
            VirtualMachine vm = new VirtualMachine(storage);
            vm.SetValue("Test", 1234);
            storage.Received().SetValue("Test", 1234);

        }
        [Test]
        public void GetVariableShouldBeOk()
        {
            IStorage storage = Substitute.For<IStorage>();
            storage.GetValue("Test").Returns(1234);
            VirtualMachine vm = new VirtualMachine(storage);
            int actual = vm.GetValue("Test");
            actual.Should().Equals(1234);
        }
        [Test]
        public void GetUnknownVariableShouldBeException()
        {
            IStorage storage = Substitute.For<IStorage>();
            storage.GetValue(Arg.Any<String>()).Returns((x) => { throw new ArgumentOutOfRangeException(); });
            VirtualMachine vm = new VirtualMachine(storage);
            vm.Invoking(x => x.GetValue("TEST")).Should().Throw<UnknownVariableException>();
        }
    }
}