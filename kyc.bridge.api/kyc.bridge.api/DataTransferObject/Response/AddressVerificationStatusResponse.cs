using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kyc.bridge.api.DataTransferObject.Response
{
/// <summary>
/// Response for 'Get'
/// </summary>
    public class AddressVerificationStatusResponse
    {
        public string id { get; set; }
        public string status { get; set; }
        public string taskStatus { get; set; }
        public string packageName { get; set; }
        public int isFlagged { get; set; }
        public string candidateId { get; set; }
        public string package { get; set; }
        public string reason { get; set; }
        
    }
}