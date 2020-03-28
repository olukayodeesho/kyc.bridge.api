using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using kyc.bridge.api.DataAccess.bvn;
using kyc.bridge.api.DataAccess.Repository;
using kyc.bridge.api.DataAccess.Seamfix;
using kyc.bridge.api.DataTransferObject;
using kyc.bridge.api.DataTransferObject.Request;
using kyc.bridge.api.DataTransferObject.Response;
using Newtonsoft.Json;

namespace kyc.bridge.api.BusinessLogic
{
    public class KycLogic
    {
        public static IdValidationResponse IdValidationProcessor(IdValidationRequest idValidationRequest)
        {
            var resp = new IdValidationResponse();
            try
            {
                string jsonResponse = KycService.IdServiceValidation(idValidationRequest);

                resp = JsonConvert.DeserializeObject<IdValidationResponse>(jsonResponse);
            }
            catch (Exception e)
            {
                ExceptionLogRepository.SaveExceptionLog(e);
            }
            return resp;
        }

        public static IdFacematchResponse IdFaceMatchProcessor(IdFaceMatchRequest idFaceMatchReq)
        {
            var resp = new IdFacematchResponse();
            try
            {
                string jsonResponse = KycService.IdServiceFaceMatch(idFaceMatchReq);
                resp = JsonConvert.DeserializeObject<IdFacematchResponse>(jsonResponse);
            }
            catch (Exception e)
            {
                ExceptionLogRepository.SaveExceptionLog(e);

            }
            return resp;
        }

        public static BvnResponse BvnProcessor(BvnServiceRequest bvnReq)
        {
            var resp = new BvnResponse();
            try
            {
                //string jsonResponse = KycService.BvnServiceRequestValidation(bvnReq);
                string jsonResponse = KycService.BvnServiceRequestValidation0(bvnReq);
                resp = JsonConvert.DeserializeObject<BvnResponse>(jsonResponse);

            }
            catch (Exception e)
            {
                ExceptionLogRepository.SaveExceptionLog(e);

            }
            return resp;
        }

        public static BvnFacematchResponse BvnFacematchProcessor(BvnServiceFaceMatch bvnFacematchReq)
        {
            var resp = new BvnFacematchResponse();
            try
            {
                string jsonResponse = KycService.BvnServiceFaceMatchRequest(bvnFacematchReq);
                resp = JsonConvert.DeserializeObject<BvnFacematchResponse>(jsonResponse);

            }
            catch (Exception e)
            {
                ExceptionLogRepository.SaveExceptionLog(e);
            }
            return resp;
        }

        public static DocumentServiceResponse DocumentServiceProcessor(DocumentServiceRequest documentReq)
        {
            var resp = new DocumentServiceResponse();
            try
            {
                string jsonResponse = KycService.DocumentServiceRequest(documentReq);
                resp = JsonConvert.DeserializeObject<DocumentServiceResponse>(jsonResponse);

            }
            catch (Exception e)
            {
                ExceptionLogRepository.SaveExceptionLog(e);
            }
            return resp;
        }

        public static StatusResponse StatusResponseProcessor(StatusServiceRequest statusReq)
        {
            var resp = new StatusResponse();
            try
            {
                string jsonResponse = KycService.StatusServiceRequest(statusReq);
                resp = JsonConvert.DeserializeObject<StatusResponse>(jsonResponse);

            }
            catch (Exception e)
            {
                ExceptionLogRepository.SaveExceptionLog(e);
            }
            return resp;
        }

        public static KycTier3VerifResponse KycTier3VerifResponseProcessor(KycTier3Verification KycTier3Req)
        {
            var resp = new KycTier3VerifResponse();
            try
            {
                string jsonResponse = KycService.KycTier3Verification(KycTier3Req);
                resp = JsonConvert.DeserializeObject<KycTier3VerifResponse>(jsonResponse);

            }
            catch (Exception e)
            {
                ExceptionLogRepository.SaveExceptionLog(e);
            }
            return resp;
        }
        public static BankBvnResponse GetCustomerBvnDetails(BankBvnRequest bankBvnRequest)
        {
            var resp = new BankBvnResponse();
            try
            {
                if (bankBvnRequest != null)
                {
                    if ( !string.IsNullOrEmpty(bankBvnRequest.bvn) && !string.IsNullOrEmpty(bankBvnRequest.bankCode))
                    {
                        resp = BvnService.getBvn(bankBvnRequest.bvn, bankBvnRequest.bankCode);
                    }
                    else { resp.ResponseCode = "99"; resp.ResponseDescription = "missing  required field in request"; }
                }
                else { resp.ResponseCode = "99"; resp.ResponseDescription = "null request"; }
            }
            catch (Exception e)
            {
                ExceptionLogRepository.SaveExceptionLog(e);
            }
            return resp;
        }

        public static string GenerateTransactionRef()
        {
            var txnRef = "";
            Random rnd = new Random();
            int myRandomNo = rnd.Next(1000000, 9999999);
            txnRef = "SF|KYC|BS|HBN|" + DateTime.Now.ToString("HHmmssfff") + myRandomNo.ToString();
            return txnRef;
        }

        public static BankBvnResponse RetrieveBvnDetailsFromResponse(string pipeDelimitedBvnString)
        {
            var bvnDetails = new BankBvnResponse();
            if (!string.IsNullOrEmpty(pipeDelimitedBvnString))
            {
                if (pipeDelimitedBvnString.Contains("|"))
                {
                    string[] responseArray = pipeDelimitedBvnString.Split('|');
                    if (responseArray.Length == 6)
                    {
                        bvnDetails.ResponseCode = responseArray[0];
                        bvnDetails.FirstName = responseArray[1];
                        bvnDetails.MiddleName = responseArray[2];
                        bvnDetails.LastName = responseArray[3];
                        bvnDetails.DateOfBirth = responseArray[4];
                        bvnDetails.ImageBase64String = responseArray[5];
                    }
                    else
                    {
                        var e = new Exception("unsupported bvn response format : " + pipeDelimitedBvnString);
                        ExceptionLogRepository.SaveExceptionLog(e);
                    }
                }
            }
            return bvnDetails;
        }

    }
}