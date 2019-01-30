using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControlDemo.DataAccess_Layer
{
    public class LocalDataAccessLayer : IDataAccessLayer
    {
        public Product[] GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Product p)
        {
            throw new NotImplementedException();
        }
    }
}
