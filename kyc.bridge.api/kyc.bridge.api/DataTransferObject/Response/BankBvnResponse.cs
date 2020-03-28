using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kyc.bridge.api.DataTransferObject.Response
{
    public class BankBvnResponse
    {
        public string ResponseDescription { get; set; }
        public string ResponseCode { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string ImageBase64String { get; set; }
    }
}