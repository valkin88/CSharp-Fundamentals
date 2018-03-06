using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenghtOfName = int.Parse(Console.ReadLine());

            List<string> listOfNames = Console.ReadLine()
                                        .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                        .ToList();

            listOfNames.Where(n => n.Length <= lenghtOfName)
                       .ToList()
                       .ForEach(n => Console.WriteLine(n));
        }
    }
}
