using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kyc.bridge.api.DataTransferObject.Request
{
    public class BankBvnRequest
    {
        public string bvn { get; set; }
        public string bankCode { get; set; }
    }
}