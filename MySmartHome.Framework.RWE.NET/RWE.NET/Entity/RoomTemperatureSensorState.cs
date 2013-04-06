using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWE.NET.Entity
{
    public class RoomTemperatureSensorState : LogicalDeviceState
    {
        double temperature;
        public double Temperature
        {
            get
            {
                return temperature;
            }

            set
            {
                OnPropertyChanged(value);
                temperature = value;
            }
        }
    }
}
