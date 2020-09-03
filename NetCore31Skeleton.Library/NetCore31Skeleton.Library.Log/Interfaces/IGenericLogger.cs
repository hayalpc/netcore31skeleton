using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore31Skeleton.Library.Log.Interfaces
{
    public interface IGenericLogger : Microsoft.Extensions.Logging.ILogger
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
