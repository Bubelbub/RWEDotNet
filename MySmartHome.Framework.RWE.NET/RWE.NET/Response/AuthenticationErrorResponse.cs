using System.Xml.Serialization;

namespace RWE.NET.Response
{
  public class AuthenticationErrorResponse : BaseResponse
  {
    [XmlAttribute(AttributeName = "Error")]
    public virtual string Error { get; set; }

  }
}
