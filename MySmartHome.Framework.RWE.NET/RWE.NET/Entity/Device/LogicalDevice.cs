using System;
using System.Xml.Serialization;
using RWE.NET.Entity.OffSettings;

namespace RWE.NET.Entity.Device
{
  [XmlInclude(typeof(DimmerActuator)),
   XmlInclude(typeof(GenericActuator)),
   XmlInclude(typeof(HumiditySensor)),
   XmlInclude(typeof(PushButtonSensor)),
   XmlInclude(typeof(RoomHumiditySensor)),
   XmlInclude(typeof(RoomTemperatureSensor)),
   XmlInclude(typeof(RoomTemperatureActuator)),
   XmlInclude(typeof(SmokeDetectionSensor)),
   XmlInclude(typeof(SwitchActuator)),
   XmlInclude(typeof(ThermostatActuator)),
   XmlInclude(typeof(TemperatureSensor)),
   XmlInclude(typeof(TimerSensor)),
   XmlInclude(typeof(ValveActuator)),
   XmlInclude(typeof(VirtualResidentSensor)),
   XmlInclude(typeof(WindowDoorSensor))]
  public class LogicalDevice
  {
    [XmlElement("Id")]
    public virtual Guid Id { get; set; }

    [XmlAttribute(AttributeName = "Name")]
    public virtual String Name { get; set; }

    [XmlAttribute(AttributeName = "LCID")]
    public virtual Guid LocationId { get; set; }

    [XmlElement("BDId")]
    public virtual Guid BaseDeviceId { get; set; }

    [XmlElement("DOfStgs")]
    public virtual DefaultOffSettings DefaultOffSettings { get; set; }
  }
}
