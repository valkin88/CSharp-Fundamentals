using Logger.Models.Contracts.Input_OutputContracts;
using System;

namespace Logger.Models.Input_Output
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
