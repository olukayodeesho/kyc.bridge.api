using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace kyc.bridge.api.test
{
    class Program
    {
        static void Main(string[] args)
        {
            //test id-validation
            try
            {
                using (var client = new WebClient())
                {
                   
                    var fullUrl = "http://localhost:52353/api/kyc/seamfix/v1/id-validation";
                    var values = new NameValueCollection();
                    values["idNo"] = "121290909090";
                    values["idBase64String"] = "wyueryiew";
                    values["surname"] = "bayo";
                    values["firstname"] ="ade";
                    values["dob"] = "1990-04-01";
                    values["passportBase64String"] = "";
                    values["idtype"] = "frsc";
                    values["transactionRef"] = GenerateTransactionRef();

                    var requestTime = DateTime.Now;
                    var response = client.UploadValues(fullUrl, values);
                    var responseTime = DateTime.Now;
                   var responseString = Encoding.Default.GetString(response);

                 }
            }
            catch (Exception e)
            { 
            }
        }
        public static string GenerateTransactionRef()
        {
            var txnRef = "";
            txnRef = "SF|KYC|BS|UBN|" + DateTime.Now.ToString("HHmmssfff");
            return txnRef;
        }
    }
}
