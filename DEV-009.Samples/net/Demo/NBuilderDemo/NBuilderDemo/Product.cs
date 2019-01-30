using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBuilderDemo
{
    class Product
    {
        public int Id;
        public String Title;
        public decimal Weight;
        public int? Width;
        public int? Height;
        private Pack pack;
        public int Code;
        public void AddPack(Pack pack)
        {
            this.pack = pack;
        }
        public override string ToString()
        {
            String result = String.Format("Id = {0},Title={1},Weight={2},Width={3},Height={4},Code={5}",
                Id, Title, Weight, Width, Height,Code);
            result += pack != null ? " product is packed with " + pack : " product not packed";
            return result;
        }
    }
}
