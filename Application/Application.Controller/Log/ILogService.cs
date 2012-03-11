using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace Application.Controller.Log
{
    public interface ILogService
    {
        ILog Logger();
    }
}
