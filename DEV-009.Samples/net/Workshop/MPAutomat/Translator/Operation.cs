using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPAutomat.Executor;

namespace MPAutomat.Translator
{
    public class Operation
    {
        internal Instruction Command { get; private set; }
        internal int Priority { get; private set; }

        public Operation(Instruction command, int priority)
        {
            this.Command = command;
            this.Priority = priority;
        }
    }
}
