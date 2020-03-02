using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kyc.bridge.api.DataTransferObject.Response
{
    public class BvnResponse
    {
        public Boolean verified { get; set; }
        public string status { get; set; }
        public string transactionRef { get; set; }
    }
}