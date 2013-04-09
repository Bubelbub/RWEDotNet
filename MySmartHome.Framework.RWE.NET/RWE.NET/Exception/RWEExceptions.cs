using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWE.NET.Exception
{
    [Serializable]
    public class AuthenticationInvalidSessionException : System.Exception
    {
        public AuthenticationInvalidSessionException()
        { }
    }

    [Serializable]
    public class AuthenticationInvalidCredentialsException : System.Exception
    {
        public AuthenticationInvalidCredentialsException()
        { }
    }
}
