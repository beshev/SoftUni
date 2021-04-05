using SimpleLogger.Appenders.Contracts;
using SimpleLogger.Enums;
using SimpleLogger.Logger.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleLogger.Logger
{
    public class Logger : ILogger
    {
        private ICollection<IAppender> _appenders;

        public Logger(params IAppender[] appenders)
        {
            this._appenders = appenders;
        }


        public void Critical(DateTime dateTime, string message)
        {
            LogToAllAppenders(dateTime, message, ReportLevel.CRITICAL);
        }

        public void Error(DateTime dateTime, string message)
        {
            LogToAllAppenders(dateTime, message, ReportLevel.ERROR);
        }

        public void Fatal(DateTime dateTime, string message)
        {
            LogToAllAppenders(dateTime, message, ReportLevel.FATAL);
        }

        public void Info(DateTime dateTime, string message)
        {
            LogToAllAppenders(dateTime, message, ReportLevel.INFO);
        }

        public void Warning(DateTime dateTime, string message)
        {
            LogToAllAppenders(dateTime, message, ReportLevel.WARNING);
        }

        private void LogToAllAppenders(DateTime dateTime, string message, ReportLevel reportLevel)
        {
            foreach (var appender in this._appenders)
            {
                appender.Append(dateTime, message, reportLevel);
            }
        }

        public void GetLoggerInfo()
        {
            foreach (var appender in this._appenders)
            {
                appender.AppendLoggerInfo(this.ToString());
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Logger info");
            foreach (var appender in this._appenders)
            {
                sb.AppendLine(appender.ToString());
            }
            return sb.ToString();
        }
    }
}
