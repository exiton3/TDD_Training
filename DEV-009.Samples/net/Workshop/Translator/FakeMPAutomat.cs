using MPAutomat.Executor;
using MPAutomat.Translator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAutomat.Tests.Translator
{
    class FakeMPAutomat : AbstractMPAutomat
    {
        public override IList<Command> GetByteCode()
        {
            throw new NotImplementedException();
        }

        public override void InitGrammar()
        {
            
        }
    }
}
