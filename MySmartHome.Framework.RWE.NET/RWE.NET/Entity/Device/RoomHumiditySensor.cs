using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWE.NET.Entity.Device
{
    public class RoomHumiditySensor : LogicalDevice
    {
        public List<Guid> UnderlyingDevicesIds { get; set; }
    }
}
