using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using kyc.bridge.api.BusinessLogic;
using kyc.bridge.api.DataAccess.bvn;
using kyc.bridge.api.DataTransferObject.Request;
using kyc.bridge.api.DataTransferObject.Response;

namespace kyc.bridge.api.Controllers
{
    [System.Web.Http.RoutePrefix("api/bank/services/v1")]
    public class BankController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("get-bvn-details")]
        public BankBvnResponse DoIdServicesValidation(BankBvnRequest bankBvnRequest)
        {
            return KycLogic.GetCustomerBvnDetails(bankBvnRequest);
        }
    }
}
