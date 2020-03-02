using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kyc.bridge.api.DataTransferObject
{
    public class IdValidationResponse
    {
        public string message { get; set; }
        public decimal faceMatchScore { get; set; }
        public Boolean verified { get; set; }
        public string status { get; set; }
        public Boolean validFace { get; set; }
        public string faceMatchStatus    { get; set; }
        public string transactionRef { get; set; }
    }
}