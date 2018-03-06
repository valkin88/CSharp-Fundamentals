using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = n => int.Parse(n);

            var input = Console.ReadLine()
                               .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(parser);

            Console.WriteLine(input.Min());

        }
    }
}
