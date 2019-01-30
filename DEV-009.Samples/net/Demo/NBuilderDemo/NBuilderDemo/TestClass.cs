using FizzWare.NBuilder;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBuilderDemo
{
    
    public class TestClass
    {
        public static void Main(String[] s)
        {
            var product = Builder<Product>.CreateNew().Build();
            Console.WriteLine(product);
            var product2 = Builder<Product>.CreateNew().
                With(x => x.Id = 100).
                With(x => x.Weight = 200).
                Build();
            Console.WriteLine(product2);
            var pack = Builder<Pack>.CreateNew().Build();
            var PackedProduct = Builder<Product>.CreateNew().
                Do(x => x.AddPack(pack)).
                Build();
            Console.WriteLine(PackedProduct);
            var gen = new RandomGenerator();
            var basket = Builder<Product>.CreateListOfSize(15).
                Random(3).With(x => x.Title = "Special offer").
                All().With(x=>x.Code = gen.Next(100,200)).Build();
            foreach (var item in basket)
            {
                Console.WriteLine(item);
            }

        }
    }
}
