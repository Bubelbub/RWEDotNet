using System.Xml.Serialization;

namespace RWE.NET.Entity.Device
{
  public class DimmerActuator : Actuator
  {
    [XmlAttribute(AttributeName = "TMxV")]
    public double MaxValue { get; set; }

    [XmlAttribute(AttributeName = "TMnV")]
    public double MinValue { get; set; }
  }
}
