using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWE.NET.Entity.Device
{
    public class RoomTemperatureActuator : Actuator
    {
        public List<Guid> UnderlyingDevicesIds { get; set; }
        public double MaxTemperature { get; set; }
        public double MinTemperature { get; set; }
        public double PreheatFactor { get; set; }
        public Boolean IsLocked { get; set; }
        public Boolean IsFreezeProtectionActivated { get; set; }
        public double FreezeProtection { get; set; }
        public Boolean IsMoldProtectionActivated { get; set; }
        public double HumidityMoldProtection { get; set; }
        public double WindowOpenTemperature { get; set; }
    }
}
