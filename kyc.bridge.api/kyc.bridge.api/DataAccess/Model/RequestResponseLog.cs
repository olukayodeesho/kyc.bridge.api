//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace kyc.bridge.api.DataAccess.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class RequestResponseLog
    {
        public long Id { get; set; }
        public string RequestBody { get; set; }
        public string RequestUrl { get; set; }
        public string HttpMethodType { get; set; }
        public Nullable<System.DateTime> RequestTime { get; set; }
        public string ResponseBody { get; set; }
        public Nullable<System.DateTime> ResponseTime { get; set; }
        public string ResponseHttpCode { get; set; }
    }
}
