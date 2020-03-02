using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kyc.bridge.api.DataTransferObject.Response
{
    public class StatusResponse
    {
        public Boolean bvnVerified { get; set; }
        public string bvnStatus { get; set; }
        public decimal bvnFaceMatchScore { get; set; }
        public string bvnFaceMatchStatus { get; set; }
        public Boolean idVerified { get; set; }
        public string idStatus { get; set; }
        public decimal idFaceMatchScore { get; set; }
        public Boolean validFace { get; set; }
        public string idFaceMatchStatus { get; set; }
        public string transactionRef { get; set; }
        public StatusDocument[] documents { get; set; }

    }
}