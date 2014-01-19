using System.Xml.Serialization;

namespace RWE.NET.Response
{
  public class LoginResponse : BaseResponse
  {
    [XmlAttribute(AttributeName = "ShcOperatingMode")]
    public virtual string ShcOperatingMode { get; set; }

    [XmlAttribute(AttributeName = "TokenHash")]
    public virtual string TokenHash { get; set; }

  }
}
