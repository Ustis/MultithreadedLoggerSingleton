using System;
using System.Configuration;
using System.IO;
using System.Text;

namespace MultithreadedLoggerSingleton
{
    public class Logger
    {
        private static Logger _logger;
        private static readonly object _lock = new object();

        private static String _logType;
        private static String _txtPath;
        private static String _xmlPath;

        private Logger()
        {
            _logType = ConfigurationManager.AppSettings["logType"];
            if (_logType == "Txt")
            {
                _txtPath = ConfigurationManager.AppSettings["txtPath"];
            }
            else if(_logType == "Xml")
            {
                _xmlPath = ConfigurationManager.AppSettings["xmlPath"];
            }
            else
            {            
                _txtPath = ConfigurationManager.AppSettings["txtPath"];
                _xmlPath = ConfigurationManager.AppSettings["xmlPath"];
            }
        }

        public static void log(Message message)
        {
            if (_logger == null)
            {
                lock (_lock)
                {
                    if (_logger == null)
                    {
                        _logger = new Logger();
                    }
                }
            }

            lock (_lock)
            {
                if (_logType == "Txt")
                    LogTxt(message);
                else if (_logType == "Xml")
                    LogTxt(message);
                else
                {
                    LogTxt(message);
                    LogXml(message);
                }
            }
        }

        private static void LogTxt(Message message)
        {
            using (StreamWriter file = new StreamWriter(_txtPath, true, Encoding.Default))
            {
                file.WriteAsync(message.ToString());
            }
        }

        private static void LogXml(Message message)
        {
            using (StreamWriter file = new StreamWriter(_xmlPath, true, Encoding.Default))
            {
                file.WriteAsync(message.toXML());
            }
        }
    }
}