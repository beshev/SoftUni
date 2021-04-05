using SimpleLogger.Appenders;
using SimpleLogger.Appenders.Contracts;
using SimpleLogger.Files.Contracts;
using SimpleLogger.Layout.Contracts;

namespace SimpleLogger.Models.AppenderFactory
{
    public static class AppenderFactory
    {
        public static IAppender CreateAppender(string appenderType,ILayout layout,IFile file)
        {
            IAppender appender = null;
            if (appenderType == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout);
            }
            else if (appenderType == "FileAppender" && file != null)
            {
                appender = new FileAppender(layout,file);
            }
            return appender;
        }
    }
}
