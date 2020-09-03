using Microsoft.Extensions.Logging;
using System;

namespace NetCore31Skeleton.Library.Log
{
    public interface IGenericLogger : ILogger
    {
        void WriteLog(LogLevel logType, Exception exception, string message);
        void Warning(Exception exception, string message);
        void Warning(string message);
        void Info(Exception exception, string message);
        void Info(string message);
        void Fatal(Exception exception, string message);
        void Fatal(string message);
        void Error(Exception exception, string message);
        void Error(string message);
        void Debug(Exception exception, string message);
        void Debug(string message);
    }
}
