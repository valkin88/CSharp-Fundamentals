namespace Logger
{
    using Logger.Models.Contracts;
    using Logger.Models.Contracts.Input_OutputContracts;
    using Logger.Models.Factories;
    using Logger.Models.Input_Output;
    using Logger.Models.Loggers;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            ILogger logger = InitializeLogger(reader);
            ErrorFactory errorFactory = new ErrorFactory();
            Engine engine = new Engine(logger, reader, writer, errorFactory);
            engine.Run();
        }

        static ILogger InitializeLogger(IReader reader)
        {
            ICollection<IAppender> appenders = new List<IAppender>();

            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory(layoutFactory);
            int appenderCount = int.Parse(reader.ReadLine());

            for (int count = 0; count < appenderCount; count++)
            {
                string[] inputArgs = reader.ReadLine().Split();
                string appenderType = inputArgs[0];
                string layoutType = inputArgs[1];
                string errorLevel = "INFO";

                if (inputArgs.Length == 3)
                {
                    errorLevel = inputArgs[2];
                }

                IAppender appender = appenderFactory.CreateAppender(appenderType, errorLevel, layoutType);
                appenders.Add(appender);
            }

            ILogger logger = new Logger(appenders);

            return logger;
        }
    }
}
