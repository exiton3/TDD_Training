using FluentAssertions;
using MPAutomat.Translator;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAutomat.Tests.Translator
{
    [TestFixture]
    public class MPAutomatTest
    {
        private AbstractMPAutomat mpAutomat;
        [SetUp]
        public void InitTest()
        {
            mpAutomat = new SampleMPAutomat();
        }
        [Test]
        public void CallProcessWithoutInitShouldBeNoGrammarException()
        {
            FakeMPAutomat mpAutomat = new FakeMPAutomat();
            mpAutomat.Invoking(p => p.Process("int i = 2;string x = \"test\";")).Should().Throw<NoGrammarException>();
        }
        [Test]
        public void CallProcessShouldBeOk()
        {
            mpAutomat.Process("int i = 2;string x = \"test\";");
        }
        [Test]
        public void CallProcessShouldBeSyntaxErrorException()
        {
            mpAutomat.Invoking(p => p.Process("int i = 2; string")).Should().Throw<SyntaxErrorException>();
        }
        [Test]
        public void callProcessWithTwoLineShouldBeOk()
        {
            mpAutomat.Process("int i=1;\nstring s=\"test\";");
        }
        [Test]
        public void SyntaxErrorExceptionShouldBeCorrectRowAndCol()
        {
            Action test = () =>
            {
                mpAutomat.Process("int i=1\nint");
            };
            test.Should().Throw<SyntaxErrorException>().And.Equals(new SyntaxErrorException(2, 1));
            //mpAutomat.Invoking(p => p.Process("int i=1\nint")).Should().
            //    Throw<SyntaxErrorException>().Where(e => e.Row.Should().Equals(2)).Where(e => e.Col.Should().Equals(1));
        }
    }
}
