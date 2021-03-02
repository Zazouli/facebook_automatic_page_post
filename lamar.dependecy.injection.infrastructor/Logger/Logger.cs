using System;
using System.Collections.Generic;
using System.Text;
using log4net;

namespace lamar.dependecy.injection.infrastructor.Logger
{
    public class Logger : ILogger
    {
        private ILog _logger;
        public static Logger GetLogger(Type type)
        {
            return new Logger(type);
        }
        public Logger(Type type)
        {
            _logger = LogManager.GetLogger(type);
        }

        public void Info(string message, Exception ex = null)
        {
            _logger.Info(message, ex);
        }
    }
}
