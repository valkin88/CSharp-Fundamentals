using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                               .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToList();
            int devider = int.Parse(Console.ReadLine());

            var result = input.Where(n => n % devider != 0).Reverse().ToList();

            foreach (var number in result)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();
        }
    }
}
