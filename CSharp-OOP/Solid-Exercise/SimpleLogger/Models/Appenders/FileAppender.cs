using SimpleLogger.Appenders.Contracts;
using SimpleLogger.Enums;
using SimpleLogger.Files.Contracts;
using SimpleLogger.Layout.Contracts;
using System;

namespace SimpleLogger.Appenders
{
    public class FileAppender : IAppender
    {
        private ILayout _layout;
        private IFile _file;
        private int _messageAppended;

        public FileAppender(ILayout layout, IFile file)
        {
            this._layout = layout;
            this._file = file;
            this.ReportLevel = ReportLevel.INFO;
        }


        public ReportLevel ReportLevel { get; set; }

        public void Append(DateTime dateTime, string message, ReportLevel reportLevel)
        {
            string format = string.Format(this._layout.Format, dateTime, reportLevel, message);
            if (reportLevel >= this.ReportLevel)
            {
                this._file.Write(format);
                this._messageAppended++;
            }
        }

        public void AppendLoggerInfo(string loggerInfo)
        {
            this._file.Write(loggerInfo);
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this._layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {this._messageAppended}, File size: {this._file.FileSize}";
        }
    }
}
