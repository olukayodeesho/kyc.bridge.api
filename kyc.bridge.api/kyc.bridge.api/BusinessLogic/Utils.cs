using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace kyc.bridge.api.BusinessLogic
{
    public class Utils
    {
        public static void BypassCertificateError()
        {
            ServicePointManager.ServerCertificateValidationCallback +=

                delegate(
                    Object sender1,
                    X509Certificate certificate,
                    X509Chain chain,
                    SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }

        public static void AddCustomHeadersToHttpClient( HttpClient client)
         {
            client.DefaultRequestHeaders.Add("userid", "206410f2-3ba8-493e-8112-7e38a8e6212e");
            client.DefaultRequestHeaders.Add("api-key", "QE2pQwOEi0wJ5px8eQECDoLYoz3b70z"); 
        }
    }
}