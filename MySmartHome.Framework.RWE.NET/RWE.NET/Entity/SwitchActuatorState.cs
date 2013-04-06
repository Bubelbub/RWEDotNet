using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RWE.NET.Entity
{
    public class SwitchActuatorState : LogicalDeviceState
    {
        bool isOn;
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
