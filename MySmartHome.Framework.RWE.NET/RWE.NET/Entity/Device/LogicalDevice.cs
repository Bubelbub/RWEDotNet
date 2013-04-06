using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using RWE.NET.Entity.OffSettings;
namespace RWE.NET.Entity.Device
{
    [XmlInclude(typeof(HumiditySensor))]
    [XmlInclude(typeof(RoomHumiditySensor))]
    [XmlInclude(typeof(RoomTemperatureSensor))]
    [XmlInclude(typeof(RoomTemperatureActuator))]
    [XmlInclude(typeof(SwitchActuator))]
    [XmlInclude(typeof(TemperatureSensor))]
    [XmlInclude(typeof(TimerSensor))]
    [XmlInclude(typeof(ValveActuator))]
    [XmlInclude(typeof(VirtualResidentSensor))]
    [XmlInclude(typeof(ThermostatActuator))]
    [XmlInclude(typeof(PushButtonSensor))]
    [XmlInclude(typeof(GenericActuator))]
    [XmlInclude(typeof(WindowDoorSensor))]
    [XmlInclude(typeof(SmokeDetectorSensor))]
    public class LogicalDevice
    {
        public virtual Guid Id { get; set; }
        public virtual String Name { get; set; }
        public virtual Guid LocationId { get; set; }
        public virtual Guid BaseDeviceId { get; set; }
        public virtual DefaultOffSettings DefaultOffSettings { get; set; }
    }
}
