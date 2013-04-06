using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RWE.NET.Request
{
    public class LoginRequest : BaseRequest
    {
        [XmlAttribute(AttributeName = "UserName")]
        public virtual string UserName { get; set; }

        [XmlAttribute(AttributeName = "Password")]
        public virtual string Password { get; set; }
    }
}
