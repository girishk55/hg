using log4net;

namespace Application.Common.Log
{
    public interface ILogService
    {
        ILog Logger();
    }
}
