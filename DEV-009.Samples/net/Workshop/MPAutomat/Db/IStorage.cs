using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAutomat.Db
{
    public interface IStorage
    {
        Object GetValue(String key);
        void SetValue(String key, Object value);
    }
}
