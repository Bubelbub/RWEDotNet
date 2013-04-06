using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWE.NET.Entity
{
    public class RoomHumiditySensorState : LogicalDeviceState
    {
        double humidity;

        public double Humidity
        {
            get
            {
                return humidity;
            }

            set
            {
                humidity = value;
                OnPropertyChanged(value);
            }
        }
    }
}
