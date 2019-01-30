using Autofac;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControlDemo.UI.Test
{
    [TestFixture]
    public class TestClass
    {
        [OneTimeSetUp]
        public void CreateLayersForTest()
        {
            IBusinessService businessService = Substitute.For<IBusinessService>();
            businessService.AmoutProductInWarehouse(10).Returns(1000000);
            businessService.GetCurrentPrice(Arg.Any<int>(), DateTime.Now).Returns(0);

            var builder = new ContainerBuilder();
            builder.RegisterInstance(businessService).As<IBusinessService>();
            Program.Container = builder.Build();

        }
        [Test]
        public void TestMethod()
        {
            decimal actual;
            using (var scope = Program.Container.BeginLifetimeScope())
            {
                IBusinessService service = scope.Resolve<IBusinessService>();
                actual = service.AmoutProductInWarehouse(10);
            }
            actual.Should().Be(1000000);
        }
    }
}
