using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControlDemo.BusinessService
{
    public class BusinessService : IBusinessService
    {
        public decimal AmoutProductInWarehouse(int Code)
        {
            using (var scope = Program.Container.BeginLifetimeScope())
            {
                IDataAccessLayer ds = scope.Resolve<IDataAccessLayer>();
                Product[] basket = ds.GetAll();
                int amoutProduct = (from p in basket where p.Code == Code select p).Count();
                return amoutProduct;
            }
        }

        public decimal GetCurrentPrice(int Code, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
