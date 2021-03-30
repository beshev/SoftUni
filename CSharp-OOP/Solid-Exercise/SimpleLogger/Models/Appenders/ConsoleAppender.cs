using SimpleLogger.Appenders.Contracts;
using SimpleLogger.Enums;
using SimpleLogger.Layout.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleLogger.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private ILayout layout;
        private int messageAppended;
        public ConsoleAppender(ILayout layout)
        {
            this.layout = layout;
            this.ReportLevel = ReportLevel.INFO;
        }

        public ReportLevel ReportLevel { get; set; }

        public void Append(DateTime dateTime, string message, ReportLevel reportLevel)
        {
            if (reportLevel >= this.ReportLevel)
            {
                Console.WriteLine(this.layout.Format, dateTime, reportLevel, message);
                messageAppended++;
            }
        }

        public void AppendLoggerInfo(string loggerInfo)
        {
            Console.WriteLine(loggerInfo);
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {this.messageAppended}";
        }
    }
}
