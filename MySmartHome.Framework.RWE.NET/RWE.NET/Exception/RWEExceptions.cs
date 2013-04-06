using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWE.NET.Exception
{
    [Serializable]
    public class AuthenticationErrorException : System.Exception
    {
        public AuthenticationErrorException()
        { }
    }
}
