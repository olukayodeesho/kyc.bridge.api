using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using kyc.bridge.api.BusinessLogic;
using kyc.bridge.api.DataAccess.Repository;
using kyc.bridge.api.DataTransferObject;
using Newtonsoft.Json;

namespace kyc.bridge.api.DataAccess.Seamfix
{
    public class KycService
    {
        private static string seamFixBaseUrl = ConfigurationManager.AppSettings["seamFixBaseUrl"].ToString();

        public static string IdServiceValidation(IdValidationRequest idValidation)
        {
            var responseString = "";
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
            try
            {
                using (var client = new WebClient())
                {
                    client.Headers.Add("USERID", "206410f2-3ba8-493e-8112-7e38a8e6212e");
                    client.Headers.Add("API-KEY", "QE2pQwOEi0wJ5px8eQECDoLYoz3b70z");
                    var fullUrl = seamFixBaseUrl + "id-service/" + idType;
                    var values = new NameValueCollection();
                    values["idNo"] = idValidation.idNo;
                    values["idBase64String"] = idValidation.idBase64String;
                    values["surname"] = idValidation.surname;
                    values["firstname"] = idValidation.firstname;
                    values["dob"] = idValidation.dob;
                    values["passportBase64String"] = idValidation.passportBase64String;
                    idValidation.transactionRef = KycLogic.GenerateTransactionRef();
                    values["transactionRef"] = idValidation.transactionRef;

                    var requestTime = DateTime.Now;
                    var response = client.UploadValues(fullUrl, values);
                    var responseTime = DateTime.Now;
                    responseString = Encoding.Default.GetString(response);

                    RequestResponseRepository.SaveRequestResponse("POST", values.ToString(), requestTime, fullUrl, responseString, "", responseTime);
                }
            }
            catch (Exception e)
            {
                ExceptionLogRepository.SaveExceptionLog(e);
            }
            return responseString;
        }

        public static string IdServiceFaceMatch(IdFaceMatchRequest idFaceValidation)
        {
            var responseString = "";
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
            try
            {
                using (var client = new WebClient())
                {
                    var fullUrl = seamFixBaseUrl + "id-service/" + idType;
                    var values = new NameValueCollection();
                    values["idNo"] = idFaceValidation.idNo;
                    values["idBase64String"] = idFaceValidation.idBase64String;
                    values["surname"] = idFaceValidation.surname;
                    values["firstname"] = idFaceValidation.firstname;
                    values["dob"] = idFaceValidation.dob;
                    values["passportBase64String"] = idFaceValidation.passportBase64String;
                    idFaceValidation.transactionRef = KycLogic.GenerateTransactionRef();
                    values["transactionRef"] = idFaceValidation.transactionRef;
                    var requestTime = DateTime.Now;
                    var response = client.UploadValues(fullUrl, values);
                    var responseTime = DateTime.Now;
                    responseString = Encoding.Default.GetString(response);

                    RequestResponseRepository.SaveRequestResponse("POST", values.ToString(), requestTime, fullUrl, responseString, "", responseTime);

                }
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
            try
            {

                using (var client = new WebClient())
                {
                    var fullUrl = seamFixBaseUrl + "bvn";
                    var values = new NameValueCollection();
                    bvnValidation.transactionRef = KycLogic.GenerateTransactionRef();
                    values["transactionRef"] = bvnValidation.transactionRef;
                    values["bvn"] = bvnValidation.bvn;
                    var requestTime = DateTime.Now;
                    var response = client.UploadValues(fullUrl, values);
                    var responseTime = DateTime.Now;

                    responseString = Encoding.Default.GetString(response);

                    RequestResponseRepository.SaveRequestResponse("POST", values.ToString(), requestTime, fullUrl, responseString, "", responseTime);
                }

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
            try
            {
                using (var client = new WebClient())
                {
                    var fullUrl = seamFixBaseUrl + "bvn";
                    var values = new NameValueCollection();
                    bvnFaceMatchValidation.transactionRef = KycLogic.GenerateTransactionRef();
                    values["transactionRef"] = bvnFaceMatchValidation.transactionRef;
                    values["bvn"] = bvnFaceMatchValidation.bvn;
                    values["passportBase64String"] = bvnFaceMatchValidation.passportBase64String;
                    var requestTime = DateTime.Now;
                    var response = client.UploadValues(fullUrl, values);
                    var responseTime = DateTime.Now;

                    responseString = Encoding.Default.GetString(response);
                    RequestResponseRepository.SaveRequestResponse("POST", values.ToString(), requestTime, fullUrl, responseString, "", responseTime);
                }
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
            try
            {

            using (var client = new WebClient())
            {
                var fullUrl = seamFixBaseUrl + "document/check/";
                var values = new NameValueCollection();

                values["firstname"] = documentsValidation.firstname;
                values["surname"] = documentsValidation.surname;
                values["dob"] = documentsValidation.dob;
                values["phone"] = documentsValidation.phone;
                values["email"] = documentsValidation.email;
                values["documents"] = JsonConvert.SerializeObject(documentsValidation.documents);
                var requestTime = DateTime.Now;
                var response = client.UploadValues(fullUrl, values);
                var responseTime = DateTime.Now;

                responseString = Encoding.Default.GetString(response);
                RequestResponseRepository.SaveRequestResponse("POST", values.ToString(), requestTime, fullUrl, responseString, "", responseTime);
                }
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
             try
             {
             using (var client = new WebClient())
             {
                 var fullUrl = seamFixBaseUrl + "verification-status/";
                 var values = new NameValueCollection();
                    statusService.transactionRef = KycLogic.GenerateTransactionRef();
                    values["transactionRef"] = statusService.transactionRef;
                 var requestTime = DateTime.Now;
                 var response = client.UploadValues(fullUrl, values);
                 var responseTime = DateTime.Now;

                 responseString = Encoding.Default.GetString(response);
                 RequestResponseRepository.SaveRequestResponse("POST", values.ToString(), requestTime, fullUrl, responseString, "", responseTime);
              }
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
            try
            {
                using (var client = new WebClient())
                {
                   
                    var fullUrl = seamFixBaseUrl + "KYC Tier-3 Verification";
                    var values = new NameValueCollection();
                    values["bvn"] = KycTier3Verif.bvn;
                    values["firstname"] = KycTier3Verif.firstname;
                    values["surname"] = KycTier3Verif.surname;
                    values["idNo"] = KycTier3Verif.idNo;
                    KycTier3Verif.transactionRef = KycLogic.GenerateTransactionRef();
                    values["transactionRef"] = KycTier3Verif.transactionRef;
                    values["dob"] = KycTier3Verif.dob;
                    values["idBase64Strihg"] = KycTier3Verif.idBase64Strihg;
                    values["idType"] = KycTier3Verif.idType;
                    values["documents"] = JsonConvert.SerializeObject(KycTier3Verif.documents);
                    var requestTime = DateTime.Now;
                    var response = client.UploadValues(fullUrl, values);
                    var responseTime = DateTime.Now;
       
                    responseString = Encoding.Default.GetString(response);
                    RequestResponseRepository.SaveRequestResponse("POST", values.ToString(), requestTime, fullUrl, responseString, "", responseTime);


                }
            }
            catch (Exception e)
            {
                ExceptionLogRepository.SaveExceptionLog(e);
            }
            return responseString;
         }

       
    }
}