using RWE.NET.Entity.Device;
using RWE.NET.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RWE.NET.Entity.Profiles;

namespace RWE.NET.Response
{
    public class GetEntitiesResponse : BaseResponse
    {
        public List<Location> Locations { get; set; }
        public Object BaseDevices { get; set; }
        public List<LogicalDevice> LogicalDevices { get; set; }
        public List<Profile> Profiles { get; set; }
        public Object ActuatorContainers { get; set; }
    }
}
