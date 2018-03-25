using Logger.Models.Contracts.Input_OutputContracts;
using System;

namespace Logger.Models.Input_Output
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string content)
        {
            Console.WriteLine(content);
        }
    }
}
