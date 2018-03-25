using Logger.Enums;
using Logger.Models.Contracts;

namespace Logger.Models.Appenders
{
    public class FileAppender : IAppender
    {
        private ILogFile logFile;

        public FileAppender(ILayout layout, ErrorLevel errorLevel, ILogFile logFile)
        {
            this.Layout = layout;
            this.ErrorLevel = errorLevel;
            this.logFile = logFile;
            this.CountOfAppendedMessages = 0;
        }

        public ErrorLevel ErrorLevel { get; }

        public ILayout Layout { get; }
        public int CountOfAppendedMessages { get; private set; }

        public void Append(IError error)
        {
            string formattedError = this.Layout.FormatError(error);
            this.logFile.WriteToFile(formattedError);
            this.CountOfAppendedMessages++;
        }

        public override string ToString()
        {
            string appenderType = this.GetType().Name;
            string layoutType = this.Layout.GetType().Name;
            string errorLevel = this.ErrorLevel.ToString();

            return $"Appender type: {appenderType}, Layout type: {layoutType}, Report level: {errorLevel}, Messages appended: {this.CountOfAppendedMessages}, File size {this.logFile.Size}";
        }
    }
}
