using RWE.NET.Exception;
using RWE.NET.Interface;
using RWE.NET.Request;
using RWE.NET.Response;
using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace RWE.NET
{
    /// <summary>
    /// Übernimmt die Kommunikation mit der Zentrale
    /// </summary>
    /// <author>Marko Geißler (marko.geissler@googlemail.com)</author>
    public class RequestHandler : IRequestHandler
    {
        protected Guid? sessionId = null;
        protected int configurationVersion = 0;
        protected string userName, password, uri;
        protected Guid clientId = Guid.NewGuid();
        protected bool debugModeEnabled;

        /// <summary>
        /// Erzeugt eine neue Instanz der Klasse
        /// </summary>
        /// <param name="userName">Benutzername</param>
        /// <param name="password">Passwort</param>
        /// <param name="uri"> URL zur Zentrale im Format https://smarthome07 </param>
        /// <param name="isPasswordHash">Wenn true, dann liegt das Passwort bereits als SHA256 Hash Base64 codiert vor</param>
        public RequestHandler(string userName, string password, string uri, bool isPasswordHash = false, bool enableDebugMode = false)
        {
            this.userName = userName;
            this.password = isPasswordHash ? password : CreateBase64SHAHash(password);
            this.uri = uri;
            this.debugModeEnabled = enableDebugMode;
            ServicePointManager.ServerCertificateValidationCallback =
                new RemoteCertificateValidationCallback(delegate { return true; });
        }

        /// <summary>
        /// Sendet eine Anfrage an die Zentrale
        /// </summary>
        /// <typeparam name="TRequest">Request</typeparam>
        /// <typeparam name="TResponse">Response</typeparam>
        /// <param name="request"> Instanz eines Reuqests</param>
        /// <returns>Die Antwort der Zentrale</returns>
        public TResponse RequestResponse<TRequest, TResponse>(TRequest request)
            where TRequest : BaseRequest, new()
            where TResponse : BaseResponse, new()
        {
            if (sessionId != null)
            {
                request.SessionId = (Guid)sessionId;
                request.BasedOnConfigVersion = configurationVersion;
                return DoRequest<TRequest, TResponse>(request);
            }
            else
            {
                LoginRequest loginRequest = new LoginRequest();
                loginRequest.UserName = userName;
                loginRequest.Password = password;
                BaseResponse response = this.DoRequest<LoginRequest, BaseResponse>(loginRequest);
                sessionId = response.SessionId;
                configurationVersion = response.CurrentConfigurationVersion;
                return this.RequestResponse<TRequest, TResponse>(request);
            }
        }

        public NotificationList RequestUpdate()
        {
            using (var client = new WebClient())
            {
                using (var reader = PostHttp(uri + "/upd", "upd"))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(NotificationList));
                    return (NotificationList)serializer.Deserialize(reader);
                }
            }
        }

        protected string CreateBase64SHAHash(string Phrase)
        {
            SHA256Managed HashTool = new SHA256Managed();
            Byte[] phraseAsByte = System.Text.Encoding.UTF8.GetBytes(string.Concat(Phrase));
            Byte[] encryptedBytes = HashTool.ComputeHash(phraseAsByte);
            HashTool.Clear();
            return Convert.ToBase64String(encryptedBytes);
        }

        protected virtual TResponse DoRequest<TRequest, TResponse>(TRequest request)
            where TRequest : BaseRequest, new()
            where TResponse : BaseResponse, new()
        {
            using (var client = new WebClient())
            {
                string xml = serialize<TRequest>(request);
                byte[] data = Encoding.UTF8.GetBytes(xml);
                using (var reader = PostHttp(uri + "/cmd", xml))
                {
                    try
                    {
                        if (debugModeEnabled)
                        {
                            using (TextWriter file = new StreamWriter("debug.log", true))
                            {
                                string debug = reader.ReadToEnd();
                                file.Write(debug);
                                return deserialize<TResponse>(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(debug))));
                            }
                        }
                        return deserialize<TResponse>(reader);
                    }
                    catch (AuthenticationErrorException)
                    {
                        this.sessionId = null;
                        return this.RequestResponse<TRequest, TResponse>(request);
                    }
                }
            }
        }

        protected StreamReader PostHttp(string uri, string postData, bool keepAllive = false)
        {
            HttpWebRequest request = (HttpWebRequest)
            WebRequest.Create(uri);
            request.KeepAlive = keepAllive;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = "POST";

            byte[] postBytes = Encoding.UTF8.GetBytes(postData);

            request.ContentType = "text/xml";
            request.Headers["ClientId"] = clientId.ToString();
            request.Referer = "https://smarthome.blob.core.windows.net/silverlight/latest/application/RWE.SmartHome.UI.Shell.xap";
            request.ContentLength = postBytes.Length;
            Stream requestStream = request.GetRequestStream();

            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return new StreamReader(response.GetResponseStream());
        }

        protected String serialize<T>(T request)
            where T : BaseRequest, new()
        {
            XmlSerializer xmlSerialzier = new XmlSerializer(typeof(BaseRequest));
            using (StringWriter stringWriter = new StringWriter())
            {
                request.RequestId = Guid.NewGuid();
                request.Version = "1.50";
                xmlSerialzier.Serialize(stringWriter, request);
                return stringWriter.ToString(); ;
            }
        }

        protected T deserialize<T>(StreamReader response)
            where T : BaseResponse, new()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BaseResponse));
            var tmpResponse = serializer.Deserialize(response);
            try
            {
                // Authentifizierung ist fehlgeschlagen
                if (tmpResponse is AuthenticationErrorResponse)
                {
                    throw new AuthenticationErrorException();
                }
            }
            finally
            {
                response.Close();
            }

            return tmpResponse as T;
        }
    }
}
