using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RWE.NET.Response
{
    public class ControlResultResponse : BaseResponse
    {
        [XmlAttribute(AttributeName = "Result")]
        public string Result { get; set; }
    }
}
