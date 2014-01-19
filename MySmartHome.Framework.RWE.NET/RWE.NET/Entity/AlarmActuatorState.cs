
namespace RWE.NET.Entity
{
  public class AlarmActuatorState : GenericDeviceState
  {
    private bool isOn;

    public virtual bool IsOn
    {
      get
      {
        return isOn;
      }

      set
      {
        isOn = value;
        OnPropertyChanged(value);
      }
    }
  }
}
