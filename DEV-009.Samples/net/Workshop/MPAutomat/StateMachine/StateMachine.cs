using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAutomat.StateMachine
{
    internal class StateMachine
    {
        private IList<Jumper> jumpersList = new List<Jumper>();
        private Stack<char> stack = new Stack<char>();
        private int currentState = 0;
        internal void AddJumper(Jumper jumper)
        {
            jumpersList.Add(jumper);
        }

        internal object[] GetJumpers()
        {
            return jumpersList.ToArray();
        }

        internal void Push(string v)
        {
            foreach (var c in v)
            {
                stack.Push(c);
            };
        }

        internal char[] GetStack()
        {
            return stack.ToArray();
        }

        internal void Put(char symbol)
        {
            var currentJumper = (from x in jumpersList where 
                              currentState == x.state && symbol == x.symbol && 
                              x.magazineSymbol == stack.Peek() select x).FirstOrDefault() ;
            if (currentJumper == null)
                throw new NoHaveStateException();
            currentJumper.action?.Invoke(symbol);
            ChangeStack(currentJumper.stackSymbols);
            currentState = currentJumper.nextState;

        }

        private void ChangeStack(string symbols)
        {
            if (symbols == null)
                return;
            for (int i = 0; i < symbols.Length; i++)
            {
                if (symbols[i] == '-')
                {
                    if (i + 1 < symbols.Length && symbols[i + 1] == '*')
                    {
                        EmptyStack();
                        i++;
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
                else
                {
                    stack.Push(symbols[i]);
                }
            }
        }

        private void EmptyStack()
        {
            while(stack.Count() != 0)
            {
                stack.Pop();
            }
        }

        internal int GetCurrentState()
        {
            return currentState;
        }

        internal int GetCountStates()
        {
            return jumpersList.Count;
        }

        internal char GetTopOnStack()
        {
            return stack.Peek();
        }
    }
}
