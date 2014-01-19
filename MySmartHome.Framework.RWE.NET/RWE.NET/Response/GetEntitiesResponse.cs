using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace RWE.NET.Response
{
  using RWE.NET.Entity;
  using RWE.NET.Entity.Device;
  using RWE.NET.Entity.Profiles;

  public class GetEntitiesResponse : BaseResponse
  {
    [XmlElement("LCs")]
    public List<Location> Locations { get; set; }
    [XmlElement("BDs")]
    public Object BaseDevices { get; set; }
    [XmlElement("LDs")]
    public List<LogicalDevice> LogicalDevices { get; set; }
    [XmlElement("PFs")]
    public List<Profile> Profiles { get; set; }
    [XmlElement("AcCts")]
    public Object ActuatorContainers { get; set; }
  }
}
