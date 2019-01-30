using MPAutomat.Db;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;

namespace MPAutomat.Tests.Integration
{
    class MPAutomatIntegrationTestParameters
    {
        public static IEnumerable<TestCaseData>  Data
            {
               get
                {
                yield return new TestCaseData("$a = $b + 2;", "$a").Returns(6);//$b=4
                yield return new TestCaseData("$x = $test * 2 - 6 / 2;", "$x").Returns(1);//$test = 2
                yield return new TestCaseData("$test = 2;", "$test").Returns(2);
                yield return new TestCaseData("$test = $k + 4;", "$test").Returns(10); //$k = 6
                yield return new TestCaseData("$abc =$abc +$abc;", "$abc").Returns(10);//$abc = 5
                }
            }
    }
}
