using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using kyc.bridge.api.BusinessLogic;
using kyc.bridge.api.DataTransferObject;
using kyc.bridge.api.DataTransferObject.Request;
using kyc.bridge.api.DataTransferObject.Response;

namespace kyc.bridge.api.Controllers
{
    [System.Web.Http.RoutePrefix("api/kyc/seamfix/v1")]
    public class SeamfixController : ApiController
    {
        // GET: Seamfix
        //public ActionResult Index()
        //{
        //    return View();
        //}
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("id-validation")]
        public IdValidationResponse DoIdServicesValidation(IdValidationRequest idValidationRequest)
        {
           return KycLogic.IdValidationProcessor(idValidationRequest);
        }


        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("id-Face")]
        public IdFacematchResponse DoIdFacematch(IdFaceMatchRequest idFaceMatchRequest)
        {
            return KycLogic.IdFaceMatchProcessor(idFaceMatchRequest);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("bvn")]
        public BvnResponse DoBvn(BvnServiceRequest bvnServiceRequest)
        {
            return KycLogic.BvnProcessor(bvnServiceRequest);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("bvn-Face")]
        public BvnFacematchResponse DoBvnFacematch(BvnServiceFaceMatch bvnFaceMatchReq)
        {
            return KycLogic.BvnFacematchProcessor(bvnFaceMatchReq);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("document")]
        public DocumentServiceResponse DoDocumentService(DocumentServiceRequest documentReq)
        {
            return KycLogic.DocumentServiceProcessor(documentReq);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("status")]
        public StatusResponse DoStatus(StatusServiceRequest statusReq)
        {
            return KycLogic.StatusResponseProcessor(statusReq);
        }


        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("KycTier3")]
        public KycTier3VerifResponse DoKycTier3Req(KycTier3Verification KycTier3Req)
        {
            return KycLogic.KycTier3VerifResponseProcessor(KycTier3Req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("id-validation")]
        public AddressVerificationResponse DoAddressVerifReq(AddressVerificationRequest AddressVerifReq)
        {
            return KycLogic.AddressVerificationResponseProcessor(AddressVerifReq);
        }
    }
}