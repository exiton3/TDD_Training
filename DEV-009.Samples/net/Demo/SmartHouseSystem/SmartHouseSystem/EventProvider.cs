using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouseSystem
{
    public class EventProvider : IEventProvider
    {
        public int Channel
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public void OnCommand()
        {
            throw new NotImplementedException();
        }
    }
}