using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using kyc.bridge.api.DataAccess.Repository;
using kyc.bridge.api.DataAccess.Seamfix;
using kyc.bridge.api.DataTransferObject;
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
                string jsonResponse = KycService.BvnServiceRequestValidation(bvnReq);
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
   
        
        

         }
}