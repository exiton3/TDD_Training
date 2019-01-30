using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouseSystem
{
    public class Device
    {
        /// <summary>
        /// State of device
        /// </summary>
        private bool status;

        /// <summary>
        /// Get state of device
        /// </summary>
        public bool Status
        {
            get
            {
                return status;
            }
        }

        public int Address
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        /// <summary>
        /// Turn on device
        /// </summary>
        public virtual void turnOn()
        {
            status = true;
        }

        /// <summary>
        /// Turn off device
        /// </summary>
        public virtual void turnOff()
        {
            status = false;
        }
    }
}