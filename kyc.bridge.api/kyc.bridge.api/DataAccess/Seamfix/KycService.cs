using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using kyc.bridge.api.BusinessLogic;
using kyc.bridge.api.DataAccess.Repository;
using kyc.bridge.api.DataTransferObject;
using kyc.bridge.api.DataTransferObject.Request;
using Newtonsoft.Json;

namespace kyc.bridge.api.DataAccess.Seamfix
{
    public class KycService
    {
        private static string seamFixBaseUrl = ConfigurationManager.AppSettings["seamFixBaseUrlId"].ToString();
        private static string seamFixBaseBvnUrl = ConfigurationManager.AppSettings["seamFixBaseUrlBvn"].ToString();
        private static string seamFixBaseDocUrl = ConfigurationManager.AppSettings["seamFixBaseUrlDoc"].ToString();
        private static string seamFixBaseStatusUrl = ConfigurationManager.AppSettings["seamFixBaseUrlStatus"].ToString();

        public static string IdServiceValidation(IdValidationRequest idValidation)
        {
            var idType = "";
            switch (idValidation.idType.ToLower())
            {
                case "nin":
                    idType = "nin";
                    break;
                case "vin":
                    idType = "vin";
                    break;
                case "passport":
                    idType = "passport";
                    break;
                case "frsc":
                    idType = "frsc";
                    break;
                default:
                    idType = "";
                    break;
            }

            var responseString = "";
            var fullUrl = seamFixBaseUrl + "id-service/" + idType;
            idValidation.transactionRef = KycLogic.GenerateTransactionRef();
            var json = JsonConvert.SerializeObject(idValidation);
            var requestTime = DateTime.Now;

            try
            {
                using (var client = new HttpClient())
                {
                    Utils.AddCustomHeadersToHttpClient(client);

                    var data = new StringContent(json, Encoding.UTF8, "application/json");

                    requestTime = DateTime.Now;
                    var httpResponseMsg = client.PostAsync(fullUrl, data).Result;

                    if (httpResponseMsg.IsSuccessStatusCode)
                    {
                        responseString = httpResponseMsg.Content.ReadAsStringAsync().Result;
                    }
                }

                var responseTime = DateTime.Now;
                RequestResponseRepository.SaveRequestResponse("POST", json, requestTime, fullUrl, responseString, "", responseTime);
            }
            catch (Exception e)
            {
                ExceptionLogRepository.SaveExceptionLog(e);
            }
            return responseString;
        }

        public static string IdServiceFaceMatch(IdFaceMatchRequest idFaceValidation)
        {
            var idType = "";
            switch (idFaceValidation.idType.ToLower())
            {
                case "nin":
                    idType = "nin";
                    break;
                case "vin":
                    idType = "vin";
                    break;
                case "passport":
                    idType = "passport";
                    break;
                case "frsc":
                    idType = "frsc";
                    break;
                default:
                    idType = "";
                    break;


            }
            var responseString = "";
            var fullUrl = seamFixBaseUrl + "id-service/" + idType;
            idFaceValidation.transactionRef = KycLogic.GenerateTransactionRef();
            var json = JsonConvert.SerializeObject(idFaceValidation);
            var requestTime = DateTime.Now;

            try
            {
                using (var client = new HttpClient())
                {

                    Utils.AddCustomHeadersToHttpClient(client);

                    var data = new StringContent(json, Encoding.UTF8, "application/json");

                    requestTime = DateTime.Now;
                    var httpResponseMsg = client.PostAsync(fullUrl, data).Result;

                    if (httpResponseMsg.IsSuccessStatusCode)
                    {
                        responseString = httpResponseMsg.Content.ReadAsStringAsync().Result;
                    }
                }

                var responseTime = DateTime.Now;
                RequestResponseRepository.SaveRequestResponse("POST", json, requestTime, fullUrl, responseString, "", responseTime);
            }
            catch (Exception e)
            {
                ExceptionLogRepository.SaveExceptionLog(e);
            }
            return responseString;

        }
        public static string BvnServiceRequestValidation0(BvnServiceRequest bvnValidation)
        {
            var responseString = "";
            var fullUrl = seamFixBaseBvnUrl + "bvn";
            bvnValidation.transactionRef = KycLogic.GenerateTransactionRef();
            var json = JsonConvert.SerializeObject(bvnValidation);
            var requestTime = DateTime.Now;
            try
            {
                
                using (var client = new HttpClient())
                {
                    Utils.AddCustomHeadersToHttpClient(client);

                    var data = new StringContent(json, Encoding.UTF8, "application/json");

                    requestTime = DateTime.Now;
                    var httpResponseMsg = client.PostAsync(fullUrl, data).Result;
                    
                    if (httpResponseMsg.IsSuccessStatusCode)
                    {
                        responseString = httpResponseMsg.Content.ReadAsStringAsync().Result;
                    }      
                }
                var responseTime = DateTime.Now;
                RequestResponseRepository.SaveRequestResponse("POST", json, requestTime, fullUrl, responseString, "", responseTime);


            }
            catch (Exception e)
            {
                ExceptionLogRepository.SaveExceptionLog(e);
            }
            return responseString;
        }
        public static string BvnServiceRequestValidation(BvnServiceRequest bvnValidation)
        {
            var responseString = "";
            var fullUrl = seamFixBaseBvnUrl + "bvn";
            bvnValidation.transactionRef = KycLogic.GenerateTransactionRef();
            var json = JsonConvert.SerializeObject(bvnValidation);
            var requestTime = DateTime.Now;
            try
            {

                using (var client = new HttpClient())
                {
                    Utils.AddCustomHeadersToHttpClient(client);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    requestTime = DateTime.Now;
                    var httpResponseMsg = client.PostAsync(fullUrl, data).Result;

                    if (httpResponseMsg.IsSuccessStatusCode)
                    {
                        responseString = httpResponseMsg.Content.ReadAsStringAsync().Result;
                    }
                }
                var responseTime = DateTime.Now;
                RequestResponseRepository.SaveRequestResponse("POST", json, requestTime, fullUrl, responseString, "", responseTime);

            }
            catch (Exception e)
            {
                ExceptionLogRepository.SaveExceptionLog(e);
            }
            return responseString;
        }

        public static string BvnServiceFaceMatchRequest(BvnServiceFaceMatch bvnFaceMatchValidation)
        {
            var responseString = "";
            var fullUrl = seamFixBaseBvnUrl + "bvn";
            bvnFaceMatchValidation.transactionRef = KycLogic.GenerateTransactionRef();
            var json = JsonConvert.SerializeObject(bvnFaceMatchValidation);
            var requestTime = DateTime.Now;
            try
            {
                using (var client = new HttpClient())
                {

                    Utils.AddCustomHeadersToHttpClient(client);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    requestTime = DateTime.Now;
                    var httpResponseMsg = client.PostAsync(fullUrl, data).Result;

                    if (httpResponseMsg.IsSuccessStatusCode)
                    {
                        responseString = httpResponseMsg.Content.ReadAsStringAsync().Result;
                    }
                }
                var responseTime = DateTime.Now;
                RequestResponseRepository.SaveRequestResponse("POST", json, requestTime, fullUrl, responseString, "", responseTime);

            }
            catch (Exception e)
            {
                ExceptionLogRepository.SaveExceptionLog(e);
            }
            return responseString;
        }



        public static string DocumentServiceRequest(DocumentServiceRequest documentsValidation)
        {
            var responseString = "";
            var fullUrl = seamFixBaseDocUrl + "document/check/";
            documentsValidation.transactionRef = KycLogic.GenerateTransactionRef();
            var json = JsonConvert.SerializeObject(documentsValidation);
            var requestTime = DateTime.Now;
            try
            {

                using (var client = new HttpClient())
                {

                    Utils.AddCustomHeadersToHttpClient(client);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    requestTime = DateTime.Now;
                    var httpResponseMsg = client.PostAsync(fullUrl, data).Result;

                    if (httpResponseMsg.IsSuccessStatusCode)
                    {
                        responseString = httpResponseMsg.Content.ReadAsStringAsync().Result;
                    }

                }
                var responseTime = DateTime.Now;
                RequestResponseRepository.SaveRequestResponse("POST", json, requestTime, fullUrl, responseString, "", responseTime);
            }
            catch (Exception e)
            {
                ExceptionLogRepository.SaveExceptionLog(e);
            }
            return responseString;

        }


        public static string StatusServiceRequest(StatusServiceRequest statusService)
        {
            var responseString = "";  
			 var fullUrl = seamFixBaseStatusUrl + "verification-status/";
			 statusService.transactionRef = KycLogic.GenerateTransactionRef();
            var json = JsonConvert.SerializeObject(statusService);
           var requestTime = DateTime.Now;
            try
            {
                using (var client = new HttpClient())
                {
                    Utils.AddCustomHeadersToHttpClient(client);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    requestTime = DateTime.Now;
                    var httpResponseMsg = client.PostAsync(fullUrl, data).Result;

                    if (httpResponseMsg.IsSuccessStatusCode)
                    {
                        responseString = httpResponseMsg.Content.ReadAsStringAsync().Result;
                    }
                }
                var responseTime = DateTime.Now;
                RequestResponseRepository.SaveRequestResponse("POST", json, requestTime, fullUrl, responseString, "", responseTime);

            }
            catch (Exception e)
            {
                ExceptionLogRepository.SaveExceptionLog(e);
            }
            return responseString;
        }


        public static string KycTier3Verification(KycTier3Verification KycTier3Verif)
        {
            var responseString = "";
            var fullUrl = seamFixBaseUrl + "KYC Tier-3 Verification";
            KycTier3Verif.transactionRef = KycLogic.GenerateTransactionRef();
            var json = JsonConvert.SerializeObject(KycTier3Verif);
            var requestTime = DateTime.Now;
            try
            {
                using (var client = new HttpClient())
                {

                    Utils.AddCustomHeadersToHttpClient(client);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    requestTime = DateTime.Now;
                    var httpResponseMsg = client.PostAsync(fullUrl, data).Result;

                    if (httpResponseMsg.IsSuccessStatusCode)
                    {
                        responseString = httpResponseMsg.Content.ReadAsStringAsync().Result;
                    }
                }
                var responseTime = DateTime.Now;
                RequestResponseRepository.SaveRequestResponse("POST", json, requestTime, fullUrl, responseString, "", responseTime);

            }
            catch (Exception e)
            {
                ExceptionLogRepository.SaveExceptionLog(e);
            }
            return responseString;
        }

             public static string AddressVerificationRequest(AddressVerificationRequest AddressVerifReq)
        {
            var responseString = "";
            var fullUrl = seamFixBaseStatusUrl + "verification-status/";
            var json = JsonConvert.SerializeObject(AddressVerifReq);
            var requestTime = DateTime.Now;
            try
            {
                using (var client = new HttpClient())
                {
                    Utils.AddCustomHeadersToHttpClient(client);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    requestTime = DateTime.Now;
                    var httpResponseMsg = client.PostAsync(fullUrl, data).Result;

                    if (httpResponseMsg.IsSuccessStatusCode)
                    {
                        responseString = httpResponseMsg.Content.ReadAsStringAsync().Result;
                    }
                }
                var responseTime = DateTime.Now;
                RequestResponseRepository.SaveRequestResponse("POST", json, requestTime, fullUrl, responseString, "", responseTime);

            }
            catch (Exception e)
            {
                ExceptionLogRepository.SaveExceptionLog(e);
            }
            return responseString;
        
            
            }
    
    }
}