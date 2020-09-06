using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace NetCore31Skeleton.Library.Log
{
    public class NLogLogger : GenericLogger
    {
        private readonly ConcurrentDictionary<string, NLogLogger> _loggers = new ConcurrentDictionary<string, NLogLogger>();
        private readonly NLog.ILogger logger = NLog.LogManager.CreateNullLogger();

        public NLogLogger()
        {
            logger = NLog.LogManager.GetCurrentClassLogger();
        }

        public NLogLogger(Type type)
        {
            logger = NLog.LogManager.GetLogger(type.FullName);
        }

        public override void Debug(Exception exception, string message)
        {
            logger.Debug(exception, message);
        }

        public override void Debug(object message)
        {
            logger.Debug(JsonConvert.SerializeObject(message));
        }

        public override void Debug(string message)
        {
            logger.Debug(message);
        }

        public override void Error(Exception exception, string message)
        {
            logger.Error(exception, message);
        }

        public override void Error(string message)
        {
            logger.Error(message);
        }

        public override void Fatal(Exception exception, string message)
        {
            logger.Fatal(exception, message);
        }

        public override void Fatal(string message)
        {
            logger.Fatal(message);
        }

        public override void Info(Exception exception, string message)
        {
            logger.Info(exception, message);
        }

        public override void Info(string message)
        {
            logger.Info(message);
        }

        public override void Warning(Exception exception, string message)
        {
            logger.Warn(exception, message);
        }

        public override void Warning(string message)
        {
            logger.Warn(message);
        }

        public override bool IsEnabled(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Critical:
                    return logger.IsFatalEnabled;
                case LogLevel.Debug:
                case LogLevel.Trace:
                    return logger.IsDebugEnabled;
                case LogLevel.Error:
                    return logger.IsErrorEnabled;
                case LogLevel.Information:
                    return logger.IsInfoEnabled;
                case LogLevel.Warning:
                    return logger.IsWarnEnabled;
                default:
                    return false;
            }
        }

        public override void Log<TState>(Microsoft.Extensions.Logging.LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            var message = string.Empty;
            if (formatter != null)
            {
                message = formatter(state, exception);
            }

            if (!string.IsNullOrEmpty(message) || exception != null)
            {
                var exp = exception != null ? exception : null;
                switch (logLevel)
                {
                    case LogLevel.Critical:
                        WriteLog(LogLevel.Critical, exp, message);
                        break;
                    case LogLevel.Debug:
                    case LogLevel.Trace:
                        WriteLog(LogLevel.Debug, exp, message);
                        break;
                    case LogLevel.Error:
                        WriteLog(LogLevel.Error, exp, message);
                        break;
                    case LogLevel.Information:
                        WriteLog(LogLevel.Information, exp, message);
                        break;
                    case LogLevel.Warning:
                        WriteLog(LogLevel.Warning, exp, message);
                        break;
                    default:
                        WriteLog(LogLevel.Warning, exp, message);
                        break;
                }
            }
        }

        public override void WriteLog(Microsoft.Extensions.Logging.LogLevel logType, Exception exception, string message)
        {
            if (IsEnabled(logType))
            {
                switch (logType)
                {
                    case LogLevel.Information:
                        logger.Info(exception, message);
                        break;
                    case LogLevel.Debug:
                        logger.Debug(exception, message);
                        break;
                    case LogLevel.Warning:
                        logger.Warn(exception, message);
                        break;
                    case LogLevel.Error:
                        logger.Error(exception, message);
                        break;
                    case LogLevel.Critical:
                        logger.Fatal(exception, message);
                        break;
                    default:
                        logger.Info(exception, message);
                        break;
                }
            }
        }

        public override IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public NLogLogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, new NLogLogger());
        }

        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}
