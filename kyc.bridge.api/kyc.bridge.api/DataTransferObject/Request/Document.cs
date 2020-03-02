using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kyc.bridge.api.DataTransferObject
{
    public class Document
    {
        public string passportBase64String { get; set; }
        public string docBase64String { get; set; }
        public string documentType { get; set; }
    }
}