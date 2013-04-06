using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RWE.NET.Entity
{
    [XmlInclude(typeof(WindowDoorSensorState)), XmlInclude(typeof(SmokeDetectorSensorState)), XmlInclude(typeof(SwitchActuatorState)), XmlInclude(typeof(RoomTemperatureActuatorState)), XmlInclude(typeof(RoomHumiditySensorState)), XmlInclude(typeof(RoomTemperatureSensorState)), XmlInclude(typeof(GenericDeviceState))]
    public class LogicalDeviceState
    {
        [XmlIgnore]
        ConcurrentDictionary<string, object> changeTracker;

        [XmlIgnore]
        public ConcurrentDictionary<string, object> ChangeTracker
        {
            get { return changeTracker; }
        }

        [XmlElement]
        public virtual Guid LogicalDeviceId { get; set; }

        protected void OnPropertyChanged(object value, [CallerMemberName] string propertyName = null)
        {
            if(changeTracker != null)
                changeTracker.AddOrUpdate(propertyName, value, (k,v) => value );
        }

        internal void InitializeChangeTracker()
        { changeTracker = new ConcurrentDictionary<string, object>(); }
    }
}
