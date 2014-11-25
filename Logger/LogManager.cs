using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Logger
{
    public class LogManager
    {
        private ILogger Logger = null;

        public LogManager(string LoggerType, string XmlLogFilePath)
        {
            if (Logger == null)
            {
                Logger = LoggerFactory.Create(LoggerType, XmlLogFilePath);
            }
        }

        public void WriteLog(string Message, DateTime TakenOn)
        {
            try
            {
                Logger.WriteLog(Message, DateTime.Now);
            }
            catch (Exception)
            {
                EventLog.WriteEntry("CronoLib", TakenOn.ToString() + "Internal Logger dont work");
                EventLog.WriteEntry("CronoLib", TakenOn.ToString() + Message);
                return;
            }
        }
    }
}