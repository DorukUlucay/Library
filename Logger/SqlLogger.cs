using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Logger
{
    public class SqlLogger : ILogger
    {
        public void WriteLog(string Exception, DateTime TakenOn)
        {
            try
            {
                throw new NotImplementedException("sql logger'ı henüz implemente etmedim");
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}