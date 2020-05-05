using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using kyc.bridge.api.BusinessLogic;

namespace kyc.bridge.api
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BvnVal();
            // IdVal();
            //createAuth();
           // ValidateAuth();
        }

       
        protected void createAuth()
        {
       var obj =   ClientAuthentication.Processor.CreateClientAuthenticationDetails("KycBridgeTest");

        }
        protected void ValidateAuth()
        {
            bool result = ClientAuthentication.Processor.ValidateClientAuthenticationDetails("yVFJ4jCt3rzmm1hXHb6IQPrr!YsLpCStV7OkbiXp", "9911bbbd-7f59-4dd2-8b31-33a46f73ac12");

        }
        protected void IdVal() 
        {
            try
            {
                using (var client = new WebClient())
                {

                    var fullUrl = "http://localhost:52353/api/kyc/seamfix/v1/id-validation";
                    var values = new NameValueCollection();
                    values["idNo"] = "121290909090";
                    values["idBase64String"] = "wyueryiew";
                    values["surname"] = "bayo";
                    values["firstname"] = "ade";
                    values["dob"] = "1990-04-01";
                    values["passportBase64String"] = "";
                    values["idtype"] = "frsc";
                    values["transactionRef"] = KycLogic.GenerateTransactionRef();

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
        protected void BvnVal()
        {
            try
            {
                using (var client = new WebClient())
                {

                    var fullUrl = "http://localhost:52353/api/kyc/seamfix/v1/bvn";
                    var values = new NameValueCollection();
                    //client.Headers.Add("Content-Type", "application/json");
                   //client.Headers.Add("Accept", "application/json");
                    values["bvn"] = "22222222223";
                    values["transactionRef"] = KycLogic.GenerateTransactionRef();


                    var requestTime = DateTime.Now;
                    var response = client.UploadValues(fullUrl, values);
                    //var response = client.UploadData(fullUrl, values);
                    var responseTime = DateTime.Now;
                    var responseString = Encoding.Default.GetString(response);

                }
            }
            catch (Exception e)
            {
            }
        }
        //public static string GenerateTransactionRef()
        //{
        //    var txnRef = "";
        //    Random rnd = new Random();
        //    int myRandomNo = rnd.Next(1000000, 9999999);
        //    txnRef = "SF|KYC|BS|HBN|" + DateTime.Now.ToString("HHmmssfff") + myRandomNo.ToString();
        //    return txnRef;
        //}
    }
}