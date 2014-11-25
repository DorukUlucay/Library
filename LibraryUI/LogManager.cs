using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryUI
{
    public static class LogManager
    {
        //TODO: LogManager burada.
        private static Logger.LogManager _LogManager = null;

        static LogManager()
        {
            string path = HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["XmlLogFilePath"].ToString()).Replace("User", "");
            //TODO:burada bir sıkıntı olduğu için .Replace("User", "");


            _LogManager = new Logger.LogManager(
                System.Configuration.ConfigurationManager.AppSettings["LoggerType"].ToString(),
                path);
        }

        public static void WriteLog(string Message, DateTime TakenOn)
        {
            _LogManager.WriteLog(Message, TakenOn);
        }
    }
}