using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParametriseTest
{
    class ProviderTestData : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<object> data = new List<object>();
            data.Add(new object[] { 12, 3, 4 });
            data.Add(new object[] { 12, 2, 6 });
            data.Add(new object[] { 12, 4, 3 });
            return data.GetEnumerator();
        }
    }
}
