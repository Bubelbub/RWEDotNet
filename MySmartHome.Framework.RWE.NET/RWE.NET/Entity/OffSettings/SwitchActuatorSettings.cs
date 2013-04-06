using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWE.NET.Entity.OffSettings
{
    public class SwitchActuatorSettings : DefaultOffSettings
    {
        public virtual Boolean IsOn { get; set; }
    }
}
