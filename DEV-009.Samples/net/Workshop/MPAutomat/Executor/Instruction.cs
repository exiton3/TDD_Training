using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAutomat.Executor
{
    public enum Instruction
    {
        ADD,
        //  CONCAT,
        SUB,
        MUL,
        DIV,
        LOAD,
        STORE,
        //  JMP,
        //  JNE,
        //  JE,
        //  CMP,
        PUSH,
        POP,
        STOP
    }
}
