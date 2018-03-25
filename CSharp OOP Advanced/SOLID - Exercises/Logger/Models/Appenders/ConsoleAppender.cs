using Logger.Enums;
using Logger.Models.Contracts;
using Logger.Models.Contracts.Input_OutputContracts;
using Logger.Models.Input_Output;

namespace Logger.Models.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private IWriter writer;

        public ConsoleAppender(ILayout layout, ErrorLevel errorLevel)
        {
            this.Layout = layout;
            this.ErrorLevel = errorLevel;
            this.writer = new ConsoleWriter();
            this.CountOfAppendedMessages = 0;
        }

        public ErrorLevel ErrorLevel { get; }

        public ILayout Layout { get; }

        public int CountOfAppendedMessages { get; private set; }

        public void Append(IError error)
        { 
            string formatedError = this.Layout.FormatError(error);
            writer.WriteLine(formatedError);
            this.CountOfAppendedMessages++;
        }

        public override string ToString()
        {
            string appenderType = this.GetType().Name;
            string layoutType = this.Layout.GetType().Name;
            string errorLevel = this.ErrorLevel.ToString();

            return $"Appender type: {appenderType}, Layout type: {layoutType}, Report level: {errorLevel}, Messages appended: {this.CountOfAppendedMessages}";
        }
    }
}
