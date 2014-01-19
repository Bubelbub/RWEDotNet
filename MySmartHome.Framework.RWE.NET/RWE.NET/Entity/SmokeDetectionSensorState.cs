namespace RWE.NET.Entity
{
  public class SmokeDetectionSensorState : LogicalDeviceState
  {
    private bool _IsSmokeAlarm;

    public virtual bool IsSmokeAlarm
    {
      get
      {
        return _IsSmokeAlarm;

      }
      set
      {
        _IsSmokeAlarm = value;
        OnPropertyChanged(value);
      }

    }

  }
}
