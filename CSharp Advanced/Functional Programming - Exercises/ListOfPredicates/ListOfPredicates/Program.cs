using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int rangeOfSequance = int.Parse(Console.ReadLine());

            int[] arrayOfDividers = Console.ReadLine()
                                           .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                           .Distinct()
                                           .Select(int.Parse)
                                           .OrderByDescending(n => n)
                                           .ToArray();
            List<int> finalReasult = new List<int>();
            for (int i = 1; i <= rangeOfSequance; i++)
            {
                finalReasult.Add(i);
            }

            foreach (var divider in arrayOfDividers)
            {
                finalReasult = finalReasult.Where(n => n % divider == 0).ToList();
            }

            finalReasult.ForEach(n => Console.Write($"{n} "));
            Console.WriteLine();
        }
    }
}
