using RWE.NET.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RWE.NET.Response
{
    public class AuthenticationErrorResponse : BaseResponse
    {
        [XmlAttribute(AttributeName = "Error")]
        public virtual string Error { get; set; }

    }
}
