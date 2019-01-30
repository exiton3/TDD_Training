using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSubstituteDemo
{
    public interface ICalculator
    {
        int Add(int a, int b);
        String Mode { get; set; }
        event EventHandler PoweringUp;
    }
}
