using Logger.Models.Contracts;
using Logger.Models.Contracts.Input_OutputContracts;
using Logger.Models.Factories;

namespace Logger
{
    public class Engine
    {
        private ILogger logger;
        private IReader reader;
        private IWriter writer;
        private ErrorFactory errorFactory;

        public Engine(ILogger logger, IReader reader, IWriter writer, ErrorFactory errorFactory)
        {
            this.logger = logger;
            this.reader = reader;
            this.writer = writer;
            this.errorFactory = errorFactory;
        }

        public void Run()
        {
            string input;

            while ((input = reader.ReadLine()) != "END")
            {
                string[] errorArgs = input.Split('|');
                string errorLevel = errorArgs[0];
                string dateTime = errorArgs[1];
                string message = errorArgs[2];

                IError error = this.errorFactory.CreateError(dateTime, errorLevel, message);
                this.logger.Log(error);
            }

            writer.WriteLine("Logger Info");

            foreach (IAppender appender in this.logger.Appenders)
            {
                writer.WriteLine(appender.ToString());
            }
        }
    }
}
