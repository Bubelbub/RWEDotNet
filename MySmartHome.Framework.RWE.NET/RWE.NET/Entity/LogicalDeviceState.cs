using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace RWE.NET.Entity
{
	[XmlInclude(typeof(WindowDoorSensorState)),
   XmlInclude(typeof(SmokeDetectionSensorState)),
   XmlInclude(typeof(SwitchActuatorState)),
   XmlInclude(typeof(RoomTemperatureActuatorState)),
   XmlInclude(typeof(RoomHumiditySensorState)),
   XmlInclude(typeof(RoomTemperatureSensorState)),
   XmlInclude(typeof(GenericDeviceState)),
   XmlInclude(typeof(AlarmActuatorState)),
   XmlInclude(typeof(DimmerActuatorState)),
   XmlInclude(typeof(LuminanceSensorState))]
	public class LogicalDeviceState
	{
		[XmlIgnore]
		ConcurrentDictionary<string, object> changeTracker;

		[XmlIgnore]
		public ConcurrentDictionary<string, object> ChangeTracker {
			get { return changeTracker; }
		}

		[XmlAttribute(AttributeName = "LID")]
		public virtual Guid LogicalDeviceId { get; set; }

		protected void OnPropertyChanged (object value, [CallerMemberName] string propertyName = null)
		{
			if (changeTracker != null)
				changeTracker.AddOrUpdate (propertyName, value, (k, v) => value);
		}

		internal void InitializeChangeTracker ()
		{
			changeTracker = new ConcurrentDictionary<string, object> ();
		}
	}
}
