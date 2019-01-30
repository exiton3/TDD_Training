using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControlDemo
{
    public interface IDataAccessLayer
    {
        Product GetById(int id);
        void Save(Product p);
        Product[] GetAll();
    }
}
