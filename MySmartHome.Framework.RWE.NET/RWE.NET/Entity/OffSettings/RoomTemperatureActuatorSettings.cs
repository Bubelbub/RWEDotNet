using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWE.NET.Entity.OffSettings
{
    public class RoomTemperatureActuatorSettings : DefaultOffSettings
    {
        public virtual double PointTemperature { get; set; }
        public virtual Boolean IsWindowReduction { get; set; }
        
    }
}
