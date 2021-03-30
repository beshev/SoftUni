using SimpleLogger.Appenders.Contracts;
using SimpleLogger.Logger.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleLogger
{
    class StartUp
    {
        static void Main(string[] args)
        {
            CommandInterpreter.CommandInterpreter commandInterpreter = new CommandInterpreter.CommandInterpreter(new List<IAppender>(), new List<string>());

            commandInterpreter.SetAppenders();
            commandInterpreter.SetMessages();

            ILogger logger = new Logger.Logger(commandInterpreter.Appenders.ToArray());
            LogReports(logger,commandInterpreter.Reports.ToArray());
            logger.GetLoggerInfo();

        }

        private static void LogReports(ILogger logger, ICollection<string> reports)
        {
            foreach (var report in reports)
            {
                string[] tokens = report
                    .Split('|', System.StringSplitOptions.RemoveEmptyEntries);

                string reportType = tokens[0].ToUpper();
                string message = tokens[2];
                GetReportType(logger, reportType, message);
            }
        }

        private static void GetReportType(ILogger logger, string reportType, string message)
        {
            if (reportType == "INFO")
            {
                logger.Info(DateTime.Now, message);
            }
            else if (reportType == "WARNING")
            {
                logger.Warning(DateTime.Now, message);
            }
            else if (reportType == "ERROR")
            {
                logger.Error(DateTime.Now, message);
            }
            else if (reportType == "CRITICAL")
            {
                logger.Critical(DateTime.Now, message);
            }
            else if (reportType == "FATAL")
            {
                logger.Fatal(DateTime.Now, message);
            }
        }
    }
}
