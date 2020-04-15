using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kyc.bridge.api.DataTransferObject.Response
{
     /// <summary>
     /// Response for 'Post'
     /// </summary>
    public class AddressVerificationResponse
    {
        public string description { get; set; }
        public string referenceNo{ get; set; }
    }
}