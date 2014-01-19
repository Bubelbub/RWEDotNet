using System.Xml.Serialization;

namespace RWE.NET.Entity
{
  public class RoomHumiditySensorState : LogicalDeviceState
  {
    double humidity;

    [XmlAttribute(AttributeName = "Humidity")]
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
