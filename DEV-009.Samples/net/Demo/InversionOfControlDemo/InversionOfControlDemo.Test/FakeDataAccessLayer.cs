using FizzWare.NBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControlDemo.Test
{
    class FakeDataAccessLayer : IDataAccessLayer
    {
        public Product[] GetAll()
        {
            var gen = new RandomGenerator();
            var basket = Builder<Product>.CreateListOfSize(300).
                Random(3).With(x => x.Title = "Special offer").
                All().With(x => x.Code = gen.Next(10, 200)).Build();
            return basket.ToArray();
        }

        public Product GetById(int id)
        {
            var product = Builder<Product>.CreateNew().
                With(x => x.Id = id).
                With(x => x.Weight = 200).
                Build();
            return product;
        }

        public void Save(Product p)
        {
            throw new NotImplementedException();
        }
    }
}
