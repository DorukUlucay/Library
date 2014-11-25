using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;
using System.Text;
using System.Configuration;

namespace Logger
{
    public class LoggerFactory
    {
        public static ILogger Create(string LoggerType, string XmlLogFilePath)
        {
            ILogger logger = null;
            Type T = Type.GetType(LoggerType);

            string loggerType = LoggerType;
            string[] loggerTypes = loggerType.Split(',');
            object objectHandle = Activator.CreateInstance(T, XmlLogFilePath);
            object obj = objectHandle;
            if (obj != null)
            {
                if (obj is ILogger)
                {
                    logger = (ILogger)obj;
                }
                else
                {
                    throw new Exception(string.Format("{0} tipi bir LoggerBase olmalı.", loggerTypes[1]));
                }
            }
            else
            {
                throw new Exception(string.Format("{0} tipi üretilemiyor.", loggerTypes[1]));
            }
            return logger;
        }
    }
}