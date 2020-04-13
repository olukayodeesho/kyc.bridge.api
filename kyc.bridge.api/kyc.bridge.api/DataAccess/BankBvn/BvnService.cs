using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using kyc.bridge.api.DataAccess.Repository;
using kyc.bridge.api.DataTransferObject.Response;

namespace kyc.bridge.api.DataAccess.bvn
{
    public class BvnService
    {
        public static BankBvnResponse getBvn(string bvn, string bankCode)
        {
            var bankBvnResponse = new BankBvnResponse();
            try
            {
                //str1 = o2.ResponseCode + "|" + o2.FirstName + "|" + o2.MiddleName + "|" + o2.LastName + "|" + o2.DateOfBirth + "|" + o2.ImageBase64
                BankBvnService.BVNProcessorSoapClient client = new BankBvnService.BVNProcessorSoapClient();
                var requestTime = DateTime.Now;
                var response = client.VerifySingleBVN(bvn, bankCode);
                var responseTime = DateTime.Now;
                RequestResponseRepository.SaveRequestResponse("ASMX", "bvn : " + bvn + "; bankcode :" + bankCode, requestTime, "bankBvnService", response, "", responseTime);
                bankBvnResponse = kyc.bridge.api.BusinessLogic.KycLogic.RetrieveBvnDetailsFromResponse(response);

            }
            catch (Exception e)
            {
                ExceptionLogRepository.SaveExceptionLog(e);
            }
            return bankBvnResponse;
        }
    }
}