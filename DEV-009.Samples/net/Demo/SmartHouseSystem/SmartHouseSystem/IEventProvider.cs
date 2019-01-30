using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouseSystem
{
    public interface IEventProvider
    {
        int Channel { get; set; }

        void OnCommand();
    }
}