using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPAutomat.Db;

namespace MPAutomat.Executor
{
    internal class VirtualMachine
    {
        private IList<Command> program;
        private Stack<int> stack = new Stack<int>();
        private Command lastCommand;
        private IStorage storage;

        public VirtualMachine(IStorage storage = null)
        {
            this.storage = storage;
        }

        internal void LoadProgram(IList<Command> program)
        {
            if (program == null && program.Count == 0)
                throw new BadProgramException();
            this.program = new List<Command>();
            foreach (var item in program)
            {
                this.program.Add(item);
            }
        }

        internal Object GetTopStack()
        {
            return stack.Peek();
        }

        internal void Run()
        {
            GuardLoadCorrectProgram();
            try
            {
                foreach (var c in program)
                {
                    lastCommand = c;
                    switch (lastCommand.Cmd)
                    {
                        case Instruction.PUSH:
                            Push(); break;
                        case Instruction.POP:
                            Pop(); break;
                        case Instruction.ADD:
                            Add(); break;
                        case Instruction.SUB:
                            Sub(); break;
                        case Instruction.MUL:
                            Mul(); break;
                        case Instruction.DIV:
                            Div(); break;
                        case Instruction.STORE:
                            Store();break;
                        case Instruction.LOAD:
                            Load();break;

                    }
                }
                if (lastCommand.Cmd != Instruction.STOP)
                    throw new HaltException();
            }
            catch(InvalidOperationException)
            {
                throw new BadProgramException();
            }
        }

        private void Load()
        {
            if (lastCommand.Operand == null)
                throw new BadProgramException();
            int variable = GetValue((String)lastCommand.Operand);
            stack.Push(variable);
        }

        private void Store()
        {
            if (lastCommand.Operand == null)
                throw new BadProgramException();
            int value = (int)stack.Peek();
            SetValue((String)lastCommand.Operand,value);
        }

        private void Div()
        {
            int op1 = (int)stack.Pop();
            int op2 = (int)stack.Pop();
            if (op1 == 0)
                throw new ArithmeticErrorException();
            stack.Push(op2 / op1);
        }

        private void Mul()
        {
            int op1 = (int)stack.Pop();
            int op2 = (int)stack.Pop();
            stack.Push(op2 * op1);
        }

        private void Sub()
        {
            int op1 = (int)stack.Pop();
            int op2 = (int)stack.Pop();
            stack.Push(op2 - op1);
        }

        private void Add()
        {
            int op1 = (int)stack.Pop();
            int op2 = (int)stack.Pop();
            stack.Push(op2 + op1);
        }

        private void Pop()
        {
            if (stack.Count == 0)
                throw new HaltException();
            stack.Pop();
        }

        private void Push()
        {
            stack.Push(Convert.ToInt16(lastCommand.Operand));
        }

        internal int[] GetStack()
        {
            return stack.ToArray();
        }

        private void GuardLoadCorrectProgram()
        {
            if (program == null)
                throw new NoProgramLoadException();
            if (program.Count == 0)
                throw new BadProgramException();
        }

        internal void SetValue(string key, int value)
        {
            storage.SetValue(key, value);
        }

        internal int GetValue(string key)
        {
            try
            {
                return (int)storage.GetValue(key);
            }
            catch(ArgumentOutOfRangeException)
            {
                throw new UnknownVariableException();
            }
        }
    }
}
