using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using kyc.bridge.api.DataAccess.Model;
using kyc.bridge.api.BusinessLogic;

namespace kyc.bridge.api.DataAccess.Repository
{
    public class ExceptionLogRepository
    {
        public static void SaveExceptionLog(Exception e) 
        {
            try
            {
                using (var context = new kyc.bridge.api.DataAccess.Model.kycbridgeEntities())
                {
                    var ex = new ExceptionLog();
                    ex.ErrorDatetime = DateTime.Now;
                    ex.ErrorMessage = e.Message;
                    ex.ErrorSource = e.Source;
                    ex.ErrorStacktrace = e.StackTrace;

                    context.ExceptionLogs.Add(ex);
                    context.SaveChanges();
                }
            }
            catch (Exception ext)
            {
                Utils.LogError(e, "Original exception meant to be saved on the db ");
                Utils.LogError(ext, "Failed to create SaveExceptionLog ");
            }
         }
    }
}