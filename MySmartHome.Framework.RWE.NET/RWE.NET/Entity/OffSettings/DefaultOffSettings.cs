using System;
using System.Xml.Serialization;

namespace RWE.NET.Entity.OffSettings
{
  [XmlInclude(typeof(GenericActuatorSettings))]
  [XmlInclude(typeof(SwitchActuatorSettings))]
  [XmlInclude(typeof(RoomTemperatureActuatorSettings))]
  public class DefaultOffSettings
  {
    [XmlElement("Id")]
    public virtual Guid Id { get; set; }
    [XmlElement("BDId")]
    public virtual Guid ActuatorId { get; set; }
  }
}
