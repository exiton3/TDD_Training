using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAutomat.Translator
{
    public class SyntaxErrorException : Exception
    {
        public SyntaxErrorException(int row, int col)
        {
            Row = row;
            Col = col;
        }
        public override bool Equals(object obj)
        {
            SyntaxErrorException s = (SyntaxErrorException)obj;
            return s.Row == Row && s.Col == Col;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int Row { get; private set; }
        public int Col { get; private set; }
    }
}
