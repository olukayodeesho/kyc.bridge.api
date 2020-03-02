using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kyc.bridge.api.DataTransferObject
{
    public class DocumentServiceRequest
    {

        public string firstname { get; set; }
        public string surname { get; set; }
        public string dob { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string transactionRef { get; set; }
        public Document[] documents { get; set; }
       
         
    }
  
}