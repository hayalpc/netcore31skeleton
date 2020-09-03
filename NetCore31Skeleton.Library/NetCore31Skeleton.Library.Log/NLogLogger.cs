using Microsoft.Extensions.Logging;
using NetCore31Skeleton.Library.Log.Interfaces;
using NLog;
using NLog.Fluent;
using System;

namespace NetCore31Skeleton.Library.Log
{
    public class NLogLogger : IGenericLogger
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public void Debug(Exception exception, string message)
        {
            logger.Debug(exception, message);
        }

        public void Debug(string message)
        {
            logger.Debug(message);
        }

        public void Error(Exception exception, string message)
        {
            logger.Error(exception, message);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Fatal(Exception exception, string message)
        {
            logger.Fatal(exception, message);
        }

        public void Fatal(string message)
        {
            logger.Fatal(message);
        }

        public void Info(Exception exception, string message)
        {
            logger.Info(exception, message);
        }

        public void Info(string message)
        {
            logger.Info(message);
        }

        public void Warning(Exception exception, string message)
        {
            logger.Warn(exception, message);
        }

        public void Warning(string message)
        {
            logger.Warn(message);
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(Microsoft.Extensions.Logging.LogLevel logLevel)
        {
            throw new NotImplementedException();
        }

        public void Log<TState>(Microsoft.Extensions.Logging.LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            throw new NotImplementedException();
        }

        public void WriteLog(Microsoft.Extensions.Logging.LogLevel logType, Exception exception, string message)
        {
            throw new NotImplementedException();
        }
    }
}
