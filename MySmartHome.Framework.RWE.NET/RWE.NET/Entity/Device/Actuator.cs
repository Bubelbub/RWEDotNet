using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using RWE.NET.Entity.OffSettings;
namespace RWE.NET.Entity.Device
{
    public class Actuator : LogicalDevice
    {
        public virtual String ActuatorClass { get; set; }
    }
}
