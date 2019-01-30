using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouseSystem
{
    public class Scenario : IDispatch
    {
        public void Dispatch()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Execute of scenario
        /// </summary>
        public virtual void Run()
        {
            throw new System.NotImplementedException();
        }
    }
}