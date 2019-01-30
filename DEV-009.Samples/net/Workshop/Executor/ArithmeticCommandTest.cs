using MPAutomat.Executor;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAutomat.Tests.Executor
{
    [TestFixture]
    public class ArithmeticCommandTest
    {        
        [Test]
        [TestCaseSource(typeof(ArithmeticCommandTestParameters),"Programs")]
        public int ExecuteArithmeticCommandShouldBeCorrectResult(IList<Command> program)
        {
            VirtualMachine vm = new VirtualMachine();
            vm.LoadProgram(program);
            vm.Run();
            return (int) vm.GetTopStack();

        }
    }
}
