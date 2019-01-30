using FluentAssertions;
using MPAutomat.Executor;
using MPAutomat.Translator;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAutomat.Tests.Translator
{
    [TestFixture]
    public class CodeGeneratorTest
    {
        CodeGenerator cg;
        [SetUp]
        public void Init()
        {
            cg = new CodeGenerator();
        }
        [Test]
        public void PutSymbolsShouldBeCorrectOperandList()
        {
            cg.put('$');
            cg.put('t');
            cg.setOperand(OperandType.VARIABLE);
            Object[] actualList = cg.GetOperandList();
            Operand[] expectedOperandList = new Operand[] {
                new Operand("$t",OperandType.VARIABLE)
            };
            actualList.Should().Equals(expectedOperandList);
        }
        [Test]
        public void SetOperationShouldBeCorrectOperationList()
        {
            cg.setOperation(Instruction.ADD, 1);
            Object[] actualList = cg.GetOperationList();
            Operation[] expectedList = new Operation[] {
                new Operation(Instruction.ADD,1)
        };
            actualList.Should().Equals(expectedList);
        }
        [Test]
        public void CompleteExpressionShouldBeGenerateCorectCode()
        {
            // $m = $t - 1 / $x * 2
            cg.put('$');
            cg.put('m');
            cg.setOperand(OperandType.VARIABLE);
            cg.setOperation(Instruction.STORE, -1);
            cg.put('$');
            cg.put('t');
            cg.setOperand(OperandType.VARIABLE);
            cg.setOperation(Instruction.SUB, 1);
            cg.put('1');
            cg.setOperand(OperandType.CONST);
            cg.setOperation(Instruction.DIV, 2);
            cg.put('$');
            cg.put('x');
            cg.setOperand(OperandType.VARIABLE);
            cg.setOperation(Instruction.MUL, 2);
            cg.put('2');
            cg.setOperand(OperandType.CONST);
            IList<Command> actualCode = cg.Generate();

            IList<Command> expectedCode = new List<Command>()
                {
                new Command(Instruction.LOAD,"$t"),
                new Command(Instruction.PUSH, 1),
                new Command(Instruction.LOAD, "$x"),
                new Command(Instruction.DIV),
                new Command(Instruction.PUSH, 2),
                new Command(Instruction.MUL),
                new Command(Instruction.SUB, 1),
                new Command(Instruction.STORE, "$m"),
                new Command(Instruction.STOP)
                };
            actualCode.Should().Equal(expectedCode);
        }
        [Test]
        public void LetExpressionShouldBeGenerateCorrectCode()
        {
            //$k = 2
            cg.put('$');
            cg.put('k');
            cg.setOperand(OperandType.VARIABLE);
            cg.setOperation(Instruction.STORE, -1);
            cg.put('2');
            cg.setOperand(OperandType.CONST);
            IList<Command> expectedCode = new List<Command>()
              {
               new Command(Instruction.PUSH,2),
               new Command(Instruction.STORE, "$k"),
               new Command(Instruction.STOP)
             };
    
        IList<Command> actualCode = cg.Generate();
        actualCode.Should().Equal(expectedCode);
        }
        [Test]
        public void TwoAddShouldBeGenerateCorrectCode()
        {
            // 2 + 4
            cg.put('2');
            cg.setOperand(OperandType.CONST);
            cg.put('4');
            cg.setOperand(OperandType.CONST);
            cg.setOperation(Instruction.ADD, 1);
            IList<Command> expectedCode = new List<Command>()
              {
                new Command(Instruction.PUSH,2),
                new Command(Instruction.PUSH, 4),
                new Command(Instruction.ADD),
                new Command(Instruction.STOP)
            };
        IList<Command> actualCode = cg.Generate();
            actualCode.Should().Equal(expectedCode);        
        }
        [Test]
        public void ThreeOperandShouldBeGenerateCorrectCode()
        {
            //$k = $k + 2 - 4
            cg.put('$');
            cg.put('k');
            cg.setOperand(OperandType.VARIABLE);
            cg.setOperation(Instruction.STORE, -1);
            cg.put('$');
            cg.put('k');
            cg.setOperand(OperandType.VARIABLE);
            cg.setOperation(Instruction.ADD, 1);
            cg.put('2');
            cg.setOperand(OperandType.CONST);
            cg.setOperation(Instruction.SUB, 1);
            cg.put('4');
            cg.setOperand(OperandType.CONST);
            IList<Command> expectedCode = new List<Command>()
              {
                new Command(Instruction.LOAD,"$k"),
                new Command(Instruction.PUSH, 2),
                new Command(Instruction.ADD),
                new Command(Instruction.PUSH, 4),
                new Command(Instruction.SUB),
                new Command(Instruction.STORE, "$k"),
                new Command(Instruction.STOP)
                };
            IList<Command> actualCode = cg.Generate();
            actualCode.Should().Equal(expectedCode);           
        }
        [Test]
        public void LetSumTwoVariableShouldBeGenerateCorrectCode()
        {
            //$a = $b + 2;
            cg.put('$');
            cg.put('a');
            cg.setOperand(OperandType.VARIABLE);
            cg.setOperation(Instruction.STORE, -1);
            cg.put('$');
            cg.put('b');
            cg.setOperand(OperandType.VARIABLE);
            cg.setOperation(Instruction.ADD, 1);
            cg.put('2');
            cg.setOperand(OperandType.CONST);

            IList<Command> expectedCode = new List<Command>()
            {
            new Command(Instruction.LOAD,"$b"),
            new Command(Instruction.PUSH, 2),
            new Command(Instruction.ADD),
            new Command(Instruction.STORE, "$a"),
            new Command(Instruction.STOP)
            };
            IList<Command> actualCode = cg.Generate();
            actualCode.Should().Equal(expectedCode);
        }
     }
}
