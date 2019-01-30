using MPAutomat.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAutomat.Tests.Integration
{
    class FakeStorage : IStorage
    {
        private IDictionary<String,int> variables = new Dictionary<String,int>();
        public FakeStorage()
        {
            variables["$b"] = 4;
            variables["$test"] = 2;
            variables["$k"] = 6;
            variables["$abc"] = 5;
        }
        public object GetValue(string key)
        {
            return variables[key];
        }

        public void SetValue(string key, object value)
        {
            variables[key] = (int)value;
        }
    }
}
