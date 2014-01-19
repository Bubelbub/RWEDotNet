using System.Xml.Serialization;
namespace RWE.NET.Entity
{
  public class RoomTemperatureSensorState : LogicalDeviceState
  {
    double temperature;

    [XmlAttribute (AttributeName="Temperature")]
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
