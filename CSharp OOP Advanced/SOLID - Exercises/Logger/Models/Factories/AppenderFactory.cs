using Logger.Enums;
using Logger.Models.Appenders;
using Logger.Models.Contracts;
using Logger.Models.Files;
using System;

namespace Logger.Models.Factories
{
    public class AppenderFactory
    {
        const string DefaultFileName = "logFile{0}.txt";

        private LayoutFactory layoutFactory;
        private int fileNumber;

        public AppenderFactory(LayoutFactory layoutFactory)
        {
            this.layoutFactory = layoutFactory;
            this.fileNumber = 0;
        }

        public IAppender CreateAppender(string appenderType, string errorToString, string layoutType)
        {
            ErrorLevelParser errorLevelParser = new ErrorLevelParser();
            ILayout layout = this.layoutFactory.CreateLayout(layoutType);
            ErrorLevel errorLevel = errorLevelParser.ParseErrorLevel(errorToString);
            IAppender appender = null;

            switch (appenderType)
            {
                case "ConsoleAppender":
                    appender = new ConsoleAppender(layout, errorLevel);
                    break;
                case "FileAppender":
                    ILogFile logFile = new LogFile(string.Format(DefaultFileName, this.fileNumber));
                    appender = new FileAppender(layout, errorLevel, logFile);
                    break;
                default:
                    throw new ArgumentException("Invalid Appender Type!");
            }

            return appender;
        }
    }
}
