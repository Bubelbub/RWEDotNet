using System;
using System.Xml.Serialization;

namespace RWE.NET.Response
{
  [XmlInclude(typeof(GetEntitiesResponse)),
   XmlInclude(typeof(AcknowledgeResponse)),
   XmlInclude(typeof(LoginResponse)),
   XmlInclude(typeof(AuthenticationErrorResponse)),
   XmlInclude(typeof(ControlResultResponse)),
   XmlInclude(typeof(GetAllLogicalDeviceStatesResponse)),
   XmlInclude(typeof(GenericSHCErrorResponse))]
  public class BaseResponse
  {
    [XmlAttribute(AttributeName = "Version")]
    public virtual string Version { get; set; }

    [XmlAttribute(AttributeName = "CurrentConfigurationVersion")]
    public virtual int CurrentConfigurationVersion { get; set; }

    [XmlAttribute(AttributeName = "SessionId")]
    public virtual Guid SessionId { get; set; }

    [XmlAttribute(AttributeName = "CorrespondingRequestId")]
    public virtual Guid CorrespondingRequestId { get; set; }

  }
}
