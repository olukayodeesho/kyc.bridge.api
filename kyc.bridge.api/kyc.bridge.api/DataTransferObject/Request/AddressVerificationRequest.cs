using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kyc.bridge.api.DataTransferObject.Request
{
    public class AddressVerificationRequest
    {
        public string firstname { get; set; }
        public string surname { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string dob { get; set; }
        public string buildingNumber { get; set; }
        public string street { get; set; }
        public string landmark { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string callbackURL { get; set; }
        public string image { get; set; }
    }
}