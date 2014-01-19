using System.Xml.Serialization;

namespace RWE.NET.Entity
{
  public class WindowDoorSensorState : LogicalDeviceState
  {
		bool _isOpen;

		[XmlElement ("IsOpen")]
		public virtual bool IsOpen
		{
			get
			{
				return _isOpen;
			}

			set
			{
				_isOpen = value;
				OnPropertyChanged(value);
			}
		}

  }
}
