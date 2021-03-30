using SimpleLogger.Appenders.Contracts;
using SimpleLogger.Enums;
using SimpleLogger.Files;
using SimpleLogger.Layout.Contracts;
using SimpleLogger.Logger.Contracts;
using SimpleLogger.Models.AppenderFactory;
using SimpleLogger.Models.Factories;
using System;
using System.Collections.Generic;

namespace SimpleLogger.CommandInterpreter
{
    public class CommandInterpreter
    {
        private readonly ICollection<IAppender> _appenders;
        private readonly  ICollection<string> _reports;

        public CommandInterpreter(ICollection<IAppender> appenders,ICollection<string> reports)
        {
            this._appenders = appenders;
            this._reports = reports;
        }

        public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>)this._appenders;

        public IReadOnlyCollection<string> Reports => (IReadOnlyCollection<string>)this._reports;

        public void SetAppenders()
        {
            int appendersCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < appendersCount; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string appenderName = cmdArgs[0];
                string layoutName = cmdArgs[1];

                ILayout layout = LayoutFactory.CreateLayout(layoutName);
                IAppender appender = AppenderFactory.CreateAppender(appenderName, layout, new LogFile());
                if (cmdArgs.Length == 3)
                {
                    appender.ReportLevel = SetReportLevel(cmdArgs[2]);
                }
                this._appenders.Add(appender);
            }

        }

        public void SetMessages()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                this._reports.Add(input);
            }
        }

        private ReportLevel SetReportLevel(string reportLevel)
        {
            int result = 0;
            if (reportLevel == ReportLevel.INFO.ToString())
            {
                result = 1;
            }
            else if (reportLevel == ReportLevel.WARNING.ToString())
            {
                result = 2;
            }
            else if (reportLevel == ReportLevel.ERROR.ToString())
            {
                result = 3;
            }
            else if (reportLevel == ReportLevel.CRITICAL.ToString())
            {
                result = 4;
            }
            else if (reportLevel == ReportLevel.FATAL.ToString())
            {
                result = 5;
            }
            return (ReportLevel)result;
        }
    }
}
