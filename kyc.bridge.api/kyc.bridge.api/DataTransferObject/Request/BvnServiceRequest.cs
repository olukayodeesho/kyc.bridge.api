using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kyc.bridge.api.DataTransferObject
{
    public class BvnServiceRequest
    {
        
        public string transactionRef { get; set; } 
        public string bvn { get; set; }
      
    }
}