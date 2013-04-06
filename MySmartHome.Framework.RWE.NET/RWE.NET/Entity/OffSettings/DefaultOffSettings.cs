using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RWE.NET.Entity.OffSettings
{
    [XmlInclude(typeof(GenericActuatorSettings))]
    [XmlInclude(typeof(SwitchActuatorSettings))]
    [XmlInclude(typeof(RoomTemperatureActuatorSettings))]
    public class DefaultOffSettings
    {
        public virtual Guid Id { get; set; }
        public virtual Guid ActuatorId { get; set; }
    }
}
