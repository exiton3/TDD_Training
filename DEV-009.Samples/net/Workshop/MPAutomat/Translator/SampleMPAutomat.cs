using MPAutomat.Executor;
using MPAutomat.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAutomat.Translator
{
    class SampleMPAutomat : AbstractMPAutomat
    {
        public override IList<Command> GetByteCode()
        {
            throw new NotImplementedException();
        }

        public override void InitGrammar()
        {
            //ignoring spaces
            stateMachine.AddJumper(new Jumper(' ', '!', 0, 0));
            stateMachine.AddJumper(new Jumper('\n', '!', 0, 0));
            //int

            stateMachine.AddJumper(new Jumper('i', '!', "T", 0, 1));
            stateMachine.AddJumper(new Jumper('n', 'T', 1, 1));
            stateMachine.AddJumper(new Jumper('t', 'T', 1, 2));

            //string
            stateMachine.AddJumper(new Jumper('s', '!', "T", 0, 2));
            stateMachine.AddJumper(new Jumper('t', 'T', 2, 2));
            stateMachine.AddJumper(new Jumper('r', 'T', 2, 2));
            stateMachine.AddJumper(new Jumper('i', 'T', 2, 2));
            stateMachine.AddJumper(new Jumper('n', 'T', 2, 2));
            stateMachine.AddJumper(new Jumper('g', 'T', 2, 3));

            //ignore space
            stateMachine.AddJumper(new Jumper(' ', 'T', 2, 3));
            stateMachine.AddJumper(new Jumper('\n', 'T', 2, 3));
            stateMachine.AddJumper(new Jumper(' ', 'T', 3, 3));
            //variable name (first letter)
            stateMachine.AddJumper(new Jumper('a', 'T', "-N", 3, 4));
            stateMachine.AddJumper(new Jumper('b', 'T', "-N", 3, 4));
            stateMachine.AddJumper(new Jumper('c', 'T', "-N", 3, 4));
            stateMachine.AddJumper(new Jumper('d', 'T', "-N", 3, 4));
            stateMachine.AddJumper(new Jumper('e', 'T', "-N", 3, 4));
            stateMachine.AddJumper(new Jumper('f', 'T', "-N", 3, 4));
            stateMachine.AddJumper(new Jumper('g', 'T', "-N", 3, 4));
            stateMachine.AddJumper(new Jumper('i', 'T', "-N", 3, 4));
            stateMachine.AddJumper(new Jumper('j', 'T', "-N", 3, 4));
            stateMachine.AddJumper(new Jumper('k', 'T', "-N", 3, 4));
            stateMachine.AddJumper(new Jumper('l', 'T', "-N", 3, 4));
            stateMachine.AddJumper(new Jumper('m', 'T', "-N", 3, 4));
            stateMachine.AddJumper(new Jumper('n', 'T', "-N", 3, 4));
            stateMachine.AddJumper(new Jumper('o', 'T', "-N", 3, 4));
            stateMachine.AddJumper(new Jumper('p', 'T', "-N", 3, 4));
            stateMachine.AddJumper(new Jumper('q', 'T', "-N", 3, 4));
            stateMachine.AddJumper(new Jumper('v', 'T', "-N", 3, 4));
            stateMachine.AddJumper(new Jumper('w', 'T', "-N", 3, 4));
            stateMachine.AddJumper(new Jumper('x', 'T', "-N", 3, 4));
            stateMachine.AddJumper(new Jumper('y', 'T', "-N", 3, 4));
            stateMachine.AddJumper(new Jumper('z', 'T', "-N", 3, 4));
            stateMachine.AddJumper(new Jumper('r', 'T', "-N", 3, 4));
            stateMachine.AddJumper(new Jumper('u', 'T', "-N", 3, 4));
            stateMachine.AddJumper(new Jumper('s', 'T', "-N", 3, 4));
            stateMachine.AddJumper(new Jumper('t', 'T', "-N", 3, 4));
            stateMachine.AddJumper(new Jumper('h', 'T', "-N", 3, 4));

            //next letter of variable name
            stateMachine.AddJumper(new Jumper('a', 'N', 4, 4));
            stateMachine.AddJumper(new Jumper('b', 'N', 4, 4));
            stateMachine.AddJumper(new Jumper('c', 'N', 4, 4));
            stateMachine.AddJumper(new Jumper('d', 'N', 4, 4));
            stateMachine.AddJumper(new Jumper('e', 'N', 4, 4));
            stateMachine.AddJumper(new Jumper('f', 'N', 4, 4));
            stateMachine.AddJumper(new Jumper('g', 'N', 4, 4));
            stateMachine.AddJumper(new Jumper('i', 'N', 4, 4));
            stateMachine.AddJumper(new Jumper('j', 'N', 4, 4));
            stateMachine.AddJumper(new Jumper('k', 'N', 4, 4));
            stateMachine.AddJumper(new Jumper('l', 'N', 4, 4));
            stateMachine.AddJumper(new Jumper('m', 'N', 4, 4));
            stateMachine.AddJumper(new Jumper('n', 'N', 4, 4));
            stateMachine.AddJumper(new Jumper('o', 'N', 4, 4));
            stateMachine.AddJumper(new Jumper('p', 'N', 4, 4));
            stateMachine.AddJumper(new Jumper('q', 'N', 4, 4));
            stateMachine.AddJumper(new Jumper('v', 'N', 4, 4));
            stateMachine.AddJumper(new Jumper('w', 'N', 4, 4));
            stateMachine.AddJumper(new Jumper('x', 'N', 4, 4));
            stateMachine.AddJumper(new Jumper('y', 'N', 4, 4));
            stateMachine.AddJumper(new Jumper('z', 'N', 4, 4));
            stateMachine.AddJumper(new Jumper('r', 'N', 4, 4));
            stateMachine.AddJumper(new Jumper('u', 'N', 4, 4));
            stateMachine.AddJumper(new Jumper('s', 'N', 4, 4));
            stateMachine.AddJumper(new Jumper('t', 'N', 4, 4));
            stateMachine.AddJumper(new Jumper('h', 'N', 4, 4));

            //ignoring spaces
            stateMachine.AddJumper(new Jumper(' ', 'N', "-P", 4, 5));
            stateMachine.AddJumper(new Jumper('\n', 'N', "-P", 4, 5));
            stateMachine.AddJumper(new Jumper(' ', 'P', 5, 5));
            stateMachine.AddJumper(new Jumper('\n', 'P', 5, 5));

            //operator let
            stateMachine.AddJumper(new Jumper('=', 'N', "-V", 4, 6));
            stateMachine.AddJumper(new Jumper('=', 'P', "-V", 5, 6));
            stateMachine.AddJumper(new Jumper(' ', 'V', 6, 6));

            //start of string
            stateMachine.AddJumper(new Jumper('\"', 'V', "-S", 6, 7));

            //contain of string

            stateMachine.AddJumper(new Jumper('a', 'S', 7, 7));
            stateMachine.AddJumper(new Jumper('b', 'S', 7, 7));
            stateMachine.AddJumper(new Jumper('c', 'S', 7, 7));
            stateMachine.AddJumper(new Jumper('d', 'S', 7, 7));
            stateMachine.AddJumper(new Jumper('e', 'S', 7, 7));
            stateMachine.AddJumper(new Jumper('f', 'S', 7, 7));
            stateMachine.AddJumper(new Jumper('g', 'S', 7, 7));
            stateMachine.AddJumper(new Jumper('i', 'S', 7, 7));
            stateMachine.AddJumper(new Jumper('j', 'S', 7, 7));
            stateMachine.AddJumper(new Jumper('k', 'S', 7, 7));
            stateMachine.AddJumper(new Jumper('l', 'S', 7, 7));
            stateMachine.AddJumper(new Jumper('m', 'S', 7, 7));
            stateMachine.AddJumper(new Jumper('n', 'S', 7, 7));
            stateMachine.AddJumper(new Jumper('o', 'S', 7, 7));
            stateMachine.AddJumper(new Jumper('p', 'S', 7, 7));
            stateMachine.AddJumper(new Jumper('q', 'S', 7, 7));
            stateMachine.AddJumper(new Jumper('v', 'S', 7, 7));
            stateMachine.AddJumper(new Jumper('w', 'S', 7, 7));
            stateMachine.AddJumper(new Jumper('x', 'S', 7, 7));
            stateMachine.AddJumper(new Jumper('y', 'S', 7, 7));
            stateMachine.AddJumper(new Jumper('z', 'S', 7, 7));
            stateMachine.AddJumper(new Jumper('r', 'S', 7, 7));
            stateMachine.AddJumper(new Jumper('u', 'S', 7, 7));
            stateMachine.AddJumper(new Jumper('s', 'S', 7, 7));
            stateMachine.AddJumper(new Jumper('t', 'S', 7, 7));
            stateMachine.AddJumper(new Jumper('h', 'S', 7, 7));
            stateMachine.AddJumper(new Jumper(' ', 'S', 7, 7));
            //end of string
            stateMachine.AddJumper(new Jumper('\"', 'S', "*-!", 7, 9));

            //digit value (first letter)
            stateMachine.AddJumper(new Jumper('0', 'V', "-D", 6, 8));
            stateMachine.AddJumper(new Jumper('1', 'V', "-D", 6, 8));
            stateMachine.AddJumper(new Jumper('2', 'V', "-D", 6, 8));
            stateMachine.AddJumper(new Jumper('3', 'V', "-D", 6, 8));
            stateMachine.AddJumper(new Jumper('4', 'V', "-D", 6, 8));
            stateMachine.AddJumper(new Jumper('5', 'V', "-D", 6, 8));
            stateMachine.AddJumper(new Jumper('6', 'V', "-D", 6, 8));
            stateMachine.AddJumper(new Jumper('7', 'V', "-D", 6, 8));
            stateMachine.AddJumper(new Jumper('8', 'V', "-D", 6, 8));
            stateMachine.AddJumper(new Jumper('9', 'V', "-D", 6, 8));

            //digit value (next letter)
            stateMachine.AddJumper(new Jumper('0', 'D', 8, 8));
            stateMachine.AddJumper(new Jumper('1', 'D', 8, 8));
            stateMachine.AddJumper(new Jumper('2', 'D', 8, 8));
            stateMachine.AddJumper(new Jumper('3', 'D', 8, 8));
            stateMachine.AddJumper(new Jumper('4', 'D', 8, 8));
            stateMachine.AddJumper(new Jumper('5', 'D', 8, 8));
            stateMachine.AddJumper(new Jumper('6', 'D', 8, 8));
            stateMachine.AddJumper(new Jumper('7', 'D', 8, 8));
            stateMachine.AddJumper(new Jumper('8', 'D', 8, 8));
            stateMachine.AddJumper(new Jumper('9', 'D', 8, 8));

            //statement operator
            stateMachine.AddJumper(new Jumper(';', 'D', "-*!", 8, 0));
            stateMachine.AddJumper(new Jumper(';', '!', "-*!", 9, 0));
            stateMachine.AddJumper(new Jumper(' ', 'D', "-*!", 8, 9));
            stateMachine.AddJumper(new Jumper('\n', 'D', "-*!", 8, 9));
        }
    }
}
