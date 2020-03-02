using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kyc.bridge.api.DataTransferObject
{
    public class KycTier3Verification
    {
        public string bvn { get; set; } 
        public string firstname { get; set; }
        public string surname { get; set; }
        public string idNo { get; set; }
        public string transactionRef { get; set; }
        public string dob { get; set; }
        public string idBase64Strihg { get; set; }
        public string idType { get; set; }
        public KycTier3document[] documents { get; set; }
       
    }
}