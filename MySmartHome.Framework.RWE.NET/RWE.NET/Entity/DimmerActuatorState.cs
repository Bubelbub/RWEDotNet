
using System.Xml.Serialization;
namespace RWE.NET.Entity
{
  public class DimmerActuatorState : GenericDeviceState
  {
    private double _DmLvl;

    [XmlAttribute(AttributeName = "DmLvl")]
    public virtual double DmLvl
    {
      get
      {
        return _DmLvl;
      }

      set
      {
        _DmLvl = value;
        OnPropertyChanged(value);
      }
    }
  }
}
