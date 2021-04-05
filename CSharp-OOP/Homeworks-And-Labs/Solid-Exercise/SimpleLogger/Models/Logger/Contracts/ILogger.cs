using System;

namespace SimpleLogger.Logger.Contracts
{
    public interface ILogger
    {
        public void Info(DateTime dateTime,string message);

        public void Warning(DateTime dateTime, string message);

        public void Error(DateTime dateTime, string message);

        public void Critical(DateTime dateTime, string message);

        public void Fatal(DateTime dateTime, string message);

        public void GetLoggerInfo();
    }
}
