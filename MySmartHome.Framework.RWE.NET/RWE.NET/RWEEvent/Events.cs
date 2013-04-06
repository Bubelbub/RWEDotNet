using RWE.NET.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWE.NET.RWEEvent
{
    public class LogicalDeviceStateUpdatedEventArgs : EventArgs
    {
        public List<LogicalDeviceState> States { get; set; }
    }
}
