using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWE.NET.Entity.Device
{
    public class GenericActuator : Actuator
    {
        public virtual String StateDisplayPropertyName { get; set; }
        public virtual String ProfileSettingsDisplayPropertyName { get; set; }
    }
}
