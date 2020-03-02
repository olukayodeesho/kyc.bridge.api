using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kyc.bridge.api.DataTransferObject
{
    public class IdFaceMatchRequest
    {
        public string idType { get; set; }
        public string idNo { get; set; }
        public string idBase64String { get; set; }
        public string surname { get; set; }
        public string firstname { get; set; }
        public string dob { get; set; }
        public string transactionRef { get; set; }
        public string passportBase64String { get; set; }
    }
}