using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kyc.bridge.api.DataTransferObject
{
    public class BvnServiceFaceMatch
    {
        public string bvn { get; set; }
        public string transactionRef { get; set; }
        public string passportBase64String { get; set; }
    }
}