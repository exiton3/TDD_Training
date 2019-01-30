using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAutomat.StateMachine
{
    class Jumper
    {
        internal char symbol;
        internal char magazineSymbol;
        internal string stackSymbols;
        internal int state;
        internal int nextState;
        internal Action<char> action;
        
        public Jumper(char symbol, char magazineSymbol, int state, int nextState,Action<char> action = null)
        {
            this.symbol = symbol;
            this.magazineSymbol = magazineSymbol;
            this.state = state;
            this.nextState = nextState;
            this.action = action;
        }

        public Jumper(char symbol, char magazineSymbol, string stackSymbols, int state, int nextState,Action<char> action = null)
        {
            this.symbol = symbol;
            this.magazineSymbol = magazineSymbol;
            this.stackSymbols = stackSymbols;
            this.state = state;
            this.nextState = nextState;
            this.action = action;
        }
    }
}
