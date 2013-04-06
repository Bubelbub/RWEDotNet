using RWE.NET;
using RWE.NET.Interface;
using RWE.NET.Request;
using RWE.NET.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MySmartHome.Framework.RWE.NET.Test
{
    public class MockRequestHandler : RequestHandler
    {
        public MockRequestHandler()
            : base(string.Empty, string.Empty, string.Empty,false)
        {
        }

        protected override TResponse DoRequest<TRequest, TResponse>(TRequest request)
        {
            switch (request.GetType().Name)
            {
                case "LoginRequest":
                    return base.deserialize<TResponse>(GetInputFile("LoginResponse.xml"));

                case "GetAllLogicalDeviceStatesRequest":
                    return base.deserialize<TResponse>(GetInputFile("GetAllLogicalDeviceStatesResponse.xml"));

                case "NotificationRequest":
                    return base.deserialize<TResponse>(GetInputFile("AcknowledgeResponse.xml"));


            }
            return default(TResponse);
        }

        public static StreamReader GetInputFile(string filename)
        {
            Assembly thisAssembly = Assembly.GetExecutingAssembly();

            string path = "MySmartHome.Framework.RWE.NET.Test.ResponseMock";

            return new StreamReader(thisAssembly.GetManifestResourceStream(path + "." + filename));
        } 


    }
}
