using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControlDemo
{
    /// <summary>
    /// Domain Entity - Product
    /// </summary>
    public class Product
    {
        public int Id;
        public String Title;
        public decimal Weight;
        public int? Width;
        public int? Height;  
        public int Code;
        
        public override string ToString()
        {
            String result = String.Format("Id = {0},Title={1},Weight={2},Width={3},Height={4},Code={5}",
                Id, Title, Weight, Width, Height, Code);
            
            return result;
        }
    }
}
