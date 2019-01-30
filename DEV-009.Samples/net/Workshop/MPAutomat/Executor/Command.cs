using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAutomat.Executor
{
    public class Command
    {
        internal Instruction Cmd { get; private set; }
        internal Object Operand { get; private set; }
        public Command(Instruction command, Object operand = null)
        {
            this.Cmd = command;
            this.Operand = operand;
        }
        public override string ToString()
        {
            return Cmd.ToString() + " " + ((Operand != null) ? Operand.ToString() : "");
        }
       public override bool Equals(object obj)
        {
            Command c = (Command)obj;
            return c.Cmd == Cmd && (Operand == null || c.Operand == null || Operand.GetHashCode() == Operand.GetHashCode());
        }
        
        
    }
}
