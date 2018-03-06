using System;
using System.Collections.Generic;
using System.Linq;

namespace KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = n => Console.WriteLine($"Sir {n}");
            var input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            input.ToList().ForEach(print);
        }
    }
}
