using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouseSystem
{
    public class DimmerDevice : Device
    {
        /// <summary>
        /// Percent of brightness
        /// </summary>
        private int brightness;

        /// <summary>
        /// Get Percent of brightness
        /// </summary>
        public int Brightness
        {
            get
            {
                return brightness;
            }

            
        }

        /// <summary>
        /// Set brightness
        /// </summary>
        /// <param name="brightness">Percent of brightness</param>
        public void SetBrightness(int brightness)
        {
            if (brightness < 0 || brightness > 100)
                throw new ArgumentOutOfRangeException();
            this.brightness = brightness;
        }
        public override void turnOn()
        {
            //base.turnOn();
        }
    }
}