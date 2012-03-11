using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;

namespace Application.Controller.Log
{
    public class LogService : ILogService
    {
        private ILog logger;
        private bool isConfigured = false;

        public LogService()
        {
            if (!isConfigured)
            {
                logger = LogManager.GetLogger(typeof(LogService));
                log4net.Config.XmlConfigurator.Configure();
            }
        }

        public ILog Logger()
        {
            return logger;
        }

    }
}