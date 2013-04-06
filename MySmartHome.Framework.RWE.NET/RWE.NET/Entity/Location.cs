using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RWE.NET.Entity
{
    public class Location
    {
        public virtual Guid Id { get; set; }
        public virtual String Name { get; set; }
        public virtual int Position { get; set; }
    }
}