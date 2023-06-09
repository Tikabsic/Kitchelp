using Application.Interfaces;
using NLog;

namespace Infrastructure.Logging
{
    public class LoggingHandler : ILoggingHandler
    {
        private static  Logger _logger = LogManager.GetCurrentClassLogger();

        public void LogException(Exception ex)
        {
            _logger.Error(ex);
        }
    }
}
