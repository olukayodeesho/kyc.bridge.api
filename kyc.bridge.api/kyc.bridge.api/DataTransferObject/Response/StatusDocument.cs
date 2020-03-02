using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kyc.bridge.api.DataTransferObject.Response
{
    public class StatusDocument
    {
        public string type { get; set; }
        public string verified { get; set; }
    }
}