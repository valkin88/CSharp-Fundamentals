using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                               .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                switch (command)
                {
                    case "add": input = input.Select(n => n + 1).ToList(); break;
                    case "multiply": input = input.Select(n => n * 2).ToList(); break;
                    case "subtract":  input = input.Select(n => n - 1).ToList(); break;
                    case "print": input.ForEach(n => Console.Write($"{n} ")); Console.WriteLine(); break;
                }

                command = Console.ReadLine();
            }
            
        }
    }
}
