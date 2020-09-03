using Microsoft.Extensions.Logging;
using System;

namespace NetCore31Skeleton.Library.Log
{
    public abstract class GenericLogger : IGenericLogger
    {
        public abstract void WriteLog(LogLevel logType, Exception exception, string message);

        public abstract void Debug(string message);

        public abstract void Debug(Exception exception, string message);

        public abstract void Error(string message);

        public abstract void Error(Exception exception, string message);

        public abstract void Fatal(string message);

        public abstract void Fatal(Exception exception, string message);

        public abstract void Info(string message);

        public abstract void Info(Exception exception, string message);

        public abstract void Warning(string message);

        public abstract void Warning(Exception exception, string message);

        public abstract void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter);

        public abstract bool IsEnabled(LogLevel logLevel);

        public abstract IDisposable BeginScope<TState>(TState state);

    }
}
