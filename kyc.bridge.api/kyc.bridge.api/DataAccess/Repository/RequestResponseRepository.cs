using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using kyc.bridge.api.DataAccess.Model;

namespace kyc.bridge.api.DataAccess.Repository
{
    public class RequestResponseRepository
    {
        public static void SaveRequestResponse(string httpMethodType, string requestBody, DateTime requestTime, string requestUrl, 
        string responseBody, string responseHttpCode , DateTime responseTime )
        {

            using (var context = new kyc.bridge.api.DataAccess.Model.kycbridgeEntities())
            {
                var rrl = new RequestResponseLog();
                rrl.HttpMethodType = httpMethodType;
                rrl.RequestBody = requestBody;
                rrl.RequestTime = requestTime;
                rrl.RequestUrl = requestUrl;
                rrl.ResponseBody = responseBody;
                rrl.ResponseHttpCode = responseHttpCode;
                rrl.ResponseTime = responseTime;
                context.RequestResponseLogs.Add(rrl);
                context.SaveChanges();
            }
        }
    }
}