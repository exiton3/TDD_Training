using Autofac;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControlDemo.Test
{
    [TestFixture]
    public class BusinessServiceTest
    {
        IBusinessService service;

        [OneTimeSetUp]
        public void CreateLayersForUnitTests()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<BusinessService.BusinessService>().As<IBusinessService>();
            builder.RegisterType<FakeDataAccessLayer>().As<IDataAccessLayer>();
            Program.Container = builder.Build();

        }
        [SetUp]
        public void Setup()
        {
            
            service = Program.Container.Resolve<IBusinessService>();
        }

        [Test]
        public void SetCode1ShouldBeAmount10()
        {
           decimal amount = service.AmoutProductInWarehouse(1);
           amount.Should().Be((decimal)10.0);
        }
    }
}
