using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kyc.bridge.api.DataTransferObject
{
    public class KycTier3document
    {
        public string documentType { get; set; }
        public string idBase64String { get; set; }
        
    }
}