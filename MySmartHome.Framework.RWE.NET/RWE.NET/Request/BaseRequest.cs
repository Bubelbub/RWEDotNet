using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RWE.NET.Request
{
    [XmlInclude(typeof(GetEntitiesRequest)), XmlInclude(typeof(NotificationRequest)), XmlInclude(typeof(ProbeShcRequest)), XmlInclude(typeof(LoginRequest)), XmlInclude(typeof(GetAllLogicalDeviceStatesRequest)), XmlInclude(typeof(SetActuatorStatesRequest))]
    public class BaseRequest
    {
        [XmlAttribute(AttributeName = "Version")]
        public virtual string Version { get; set; }

        [XmlAttribute(AttributeName = "RequestId")]
        public virtual Guid RequestId { get; set; }

        [XmlAttribute(AttributeName = "BasedOnConfigVersion")]
        public virtual int BasedOnConfigVersion { get; set; }

        [XmlAttribute(AttributeName = "SessionId")]
        public virtual Guid SessionId { get; set; }

    }
}
