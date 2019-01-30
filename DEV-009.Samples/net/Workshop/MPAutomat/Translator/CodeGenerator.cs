using MPAutomat.Executor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAutomat.Translator
{
    class CodeGenerator
    {
        private String lexem = "";
        private IList<Operand> operands = new List<Operand>();
        private IList<Operation> operations = new List<Operation>();

        internal void put(char c)
        {
            lexem+=c;
        }

        internal void setOperand(OperandType operand)
        {
            operands.Add(new Operand(lexem, operand));
            lexem = "";
        }

        internal object[] GetOperandList()
        {
           return operands.ToArray();
        }

        internal void setOperation(Instruction command, int priority)
        {
            operations.Add(new Operation(command, priority)); 
        }

        internal object[] GetOperationList()
        {
            return operations.ToArray();
        }

        internal IList<Command> Generate()
        {
            IList<Command> code = new List<Command>();
            IList<Command> rightAssociate = new List<Command>();
            Stack<Command> stack = new Stack<Command>();
            Command operandCmd, operationCmd;

            int currentOperand = 0;
            int currentOperation = 0;
            while (currentOperand < operands.Count)
            {
                Operand operand = operands[currentOperand];
                if (currentOperation < operations.Count())
                {
                    Operation operation = operations[currentOperation];

                    operandCmd = CreateOperandInstruction(operand, operation);

                    if (operation.Priority < 0)
                    {
                        rightAssociate.Add(operandCmd);
                        currentOperand++;
                        currentOperation++;
                        continue;
                    }
                    operationCmd = new Command(operation.Command);

                    code.Add(operandCmd);
                    currentOperand++;
                    if (code.Count < 2)
                    {
                        operand = operands[currentOperand];
                        operandCmd = CreateOperandInstruction(operand, operation);
                        code.Add(operandCmd);
                        currentOperand++;
                    }
                    Operation nextOperation = (currentOperation + 1 < operations.Count) ? operations[currentOperation + 1] : null;
                    if (nextOperation != null && nextOperation.Priority > operation.Priority)
                    {
                        stack.Push(operationCmd);

                    }
                    else
                    {
                        code.Add(operationCmd);
                        if (nextOperation == null || nextOperation.Priority != operation.Priority)
                            while (stack.Count != 0)
                                code.Add(stack.Pop());
                    }
                    currentOperation++;
                }
                else
                {
                    operandCmd = CreateOperandInstruction(operand, null);
                    code.Add(operandCmd);
                    currentOperand++;
                }
            }
            foreach (Command c in rightAssociate)
                code.Add(c);
            code.Add(new Command(Instruction.STOP));
            return code;
        }

        private Command CreateOperandInstruction(Operand operand, Operation operation)
        {
            Command operandCmd;
            if (operation != null && operation.Command == Instruction.STORE)
                operandCmd = new Command(Instruction.STORE, operand.Lexem);
            else
                operandCmd = new Command(operand.TypeOp == OperandType.VARIABLE ? 
                    Instruction.LOAD : Instruction.PUSH, operand.Lexem);
            return operandCmd;
        }
    }
}
