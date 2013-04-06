using RWE.NET.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RWE.NET.Response
{
    public class NotificationList
    {
        [XmlAttribute(AttributeName = "NotificationListId")]
        public Guid NotificationListId { get; set; }

        public List<LogicalDeviceStatesChangedNotification> Notifications { get; set; }
    }
}
