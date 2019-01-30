using MPAutomat.Executor;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAutomat.Tests.Executor
{
    public class ArithmeticCommandTestParameters
    {
        public static IEnumerable Programs
        {
            get
            {
                yield return new TestCaseData(
                    //"ADD",
                    new List<Command>() {
                        new Command(Instruction.PUSH,4),
                        new Command(Instruction.PUSH,2),
                        new Command(Instruction.ADD),
                        new Command(Instruction.STOP)
                    }
                    ).Returns(6);
                yield return new TestCaseData(
                    //"SUB",
                    new List<Command>()
                    {
                        new Command(Instruction.PUSH,5),
                        new Command(Instruction.PUSH,2),
                        new Command(Instruction.SUB),
                        new Command(Instruction.STOP)
                    }
                    ).Returns(3);
                yield return new TestCaseData(
                    //"DIV",
                    new List<Command>()
                    {
                        new Command(Instruction.PUSH,6),
                        new Command(Instruction.PUSH,2),
                        new Command(Instruction.DIV),
                        new Command(Instruction.STOP)
                    }
                    ).Returns(3);
                yield return new TestCaseData(
                    //"MUL",
                    new List<Command>()
                    {
                        new Command(Instruction.PUSH,8),
                        new Command(Instruction.PUSH,2),
                        new Command(Instruction.MUL),
                        new Command(Instruction.STOP)
                    }
                    ).Returns(16);
            }
        }
    }
}
