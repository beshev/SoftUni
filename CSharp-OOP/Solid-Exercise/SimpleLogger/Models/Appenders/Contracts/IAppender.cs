using SimpleLogger.Enums;
using System;

namespace SimpleLogger.Appenders.Contracts
{
    public interface IAppender
    {
        public ReportLevel ReportLevel { get; set; }

        public void Append(DateTime dateTime,string message,ReportLevel reportLevel);

        public void AppendLoggerInfo(string loggerInfo);
    }
}
