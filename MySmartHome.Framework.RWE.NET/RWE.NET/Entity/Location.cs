using System;
using System.Xml.Serialization;

namespace RWE.NET.Entity
{
  [XmlRoot("LC")]
  public class Location
  {
    public virtual Guid Id { get; set; }
    public virtual String Name { get; set; }
    public virtual int Position { get; set; }
  }
}