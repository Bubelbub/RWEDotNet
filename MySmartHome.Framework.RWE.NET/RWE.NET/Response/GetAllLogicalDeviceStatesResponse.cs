using RWE.NET.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RWE.NET.Response
{
    public class GetAllLogicalDeviceStatesResponse : BaseResponse
    {
        [XmlAttribute(AttributeName = "Result")]
        public string Result { get; set; }

        public List<LogicalDeviceState> States { get; set; }
    }
}
