using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPAutomat.Executor;
using MPAutomat.StateMachine;

namespace MPAutomat.Translator
{
    public abstract class AbstractMPAutomat
    {
        internal StateMachine.StateMachine stateMachine = new StateMachine.StateMachine();
        public void Process(string source)
        {
            if (stateMachine.GetCountStates() == 0)
                InitGrammar();
            if (stateMachine.GetCountStates() == 0)
                throw new NoGrammarException();
            int row = 1, col = 0;
            try
            {
                stateMachine.Push("!");
                foreach (var c in source)
                {
                    if(c == '\n') {
                        row++;
                        col = 0;
                    }
				else 
					col++;
                stateMachine.Put(c);
                }
                if (stateMachine.GetTopOnStack() != '!')
                    throw new SyntaxErrorException(row, col);
            }
            catch (NoHaveStateException)
            {
                throw new SyntaxErrorException(row, col);
            }
        }
        public abstract void InitGrammar();
        public abstract IList<Command> GetByteCode();
    }
}
