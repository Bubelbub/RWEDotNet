using System.Xml.Serialization;
namespace RWE.NET.Entity
{
  public class RoomTemperatureActuatorState : LogicalDeviceState
  {
    double pointTemperature;
    string operationMode;
    bool windowReductionActive;

    [XmlAttribute(AttributeName = "PtTmp")]
    public double PointTemperature
    {
      get
      {
        return pointTemperature;
      }
      set
      {
        if (value != pointTemperature)
          OnPropertyChanged(value);

        pointTemperature = value;
      }
    }

    [XmlAttribute(AttributeName = "OpnMd")]
    public string OperationMode
    {
      get
      {
        return operationMode;
      }

      set
      {
        if (value != operationMode)
          OnPropertyChanged(value);
        operationMode = value;
      }
    }

    //[XmlAttribute(AttributeName = "WRAc", DataType="Boolean")]
    public bool WindowReductionActive
    {
      get
      {
        return windowReductionActive;
      }

      set
      {
        OnPropertyChanged(value);
        windowReductionActive = value;
      }
    }



  }
}
