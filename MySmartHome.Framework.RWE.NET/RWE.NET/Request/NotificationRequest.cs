using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RWE.NET.Request
{
    public class NotificationRequest : BaseRequest
    {
        public string Action { get; set; }
        public string NotificationType { get; set; }
    }
}
