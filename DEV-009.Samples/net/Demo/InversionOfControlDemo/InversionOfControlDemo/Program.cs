using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControlDemo
{
    public class Program
    {
        public static IContainer Container { get; set; }
        static void Main(string[] args)
        {
            //assembly layers for applications
            var builder = new ContainerBuilder();
            builder.RegisterType<BusinessService.BusinessService>().As<IBusinessService>();
            builder.RegisterType<DataAccess_Layer.LocalDataAccessLayer>().As<IDataAccessLayer>();
            Container = builder.Build();

            SimulateUI();//simulation work with UI layer

        }
        static void SimulateUI()
        {
           using(var scope = Container.BeginLifetimeScope())
            {
                var service = scope.Resolve<IBusinessService>();
                Console.WriteLine(service.AmoutProductInWarehouse(5));
            } 
        }
    }
}
