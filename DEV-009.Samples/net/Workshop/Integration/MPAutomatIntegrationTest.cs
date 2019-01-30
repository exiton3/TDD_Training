using MPAutomat.Db;
using MPAutomat.Executor;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAutomat.Tests.Integration
{
    [TestFixture]
    public class MPAutomatIntegrationTest
    {
        private IStorage storage;
        private VirtualMachine vm;
        private SimpleMPAutomat mp;
        [SetUp]
        public void Init()
        {
            storage = new FakeStorage();
            vm = new VirtualMachine(storage);
            mp = new SimpleMPAutomat();
        }
        [Test]
        [TestCaseSource(typeof(MPAutomatIntegrationTestParameters),"Data")]
        public int ExecuteDSLShouldBeCorrectValue(String program,String resultVariable)
        {
            mp.Process(program);
            IList<Command> code = mp.GetByteCode();
            vm.LoadProgram(code);
            vm.Run();
            return vm.GetValue(resultVariable);
        }
    }
}
