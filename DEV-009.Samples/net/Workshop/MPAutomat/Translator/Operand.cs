using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAutomat.Translator
{
    public class Operand
    {

        internal String Lexem { get; private set; }
        internal OperandType TypeOp { get; private set; }
        public Operand(string lexem, OperandType operandType)
        {
            Lexem = lexem;
            TypeOp = operandType; 
        }
        public override bool Equals(object obj)
        {
            Operand c = (Operand)obj;
            return c.Lexem == Lexem && c.TypeOp == TypeOp;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
