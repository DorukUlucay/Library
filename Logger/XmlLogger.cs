using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Logger
{
    public class XmlLogger : ILogger
    {

        string _XmlPath = null;
        public XmlLogger(string XmlPath)
        {
            _XmlPath = XmlPath;
        }

        public void WriteLog(string Exception, DateTime TakenOn)
        {
            XDocument XLogUsage = XDocument.Load(_XmlPath);
            XElement xe = XLogUsage.Element("ErrorLogs");
            XElement x0 = new XElement("ErrorLog");
            XElement x = new XElement("OccuredOn", DateTime.Now.ToString());
            XElement x2 = new XElement("Exception", Exception);
            x0.Add(x, x2);
            xe.Add(x0);
            XLogUsage.Save(_XmlPath);
        }
    }
}