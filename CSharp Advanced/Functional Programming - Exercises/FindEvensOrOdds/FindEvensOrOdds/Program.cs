using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] rangeOfNumbers = Console.ReadLine()
                               .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToArray();

            string command = Console.ReadLine();

            List<int> listOfNumbers = new List<int>();
            for (int i = rangeOfNumbers[0]; i <= rangeOfNumbers[1]; i++)
            {
                listOfNumbers.Add(i);
            }

            if (command == "even")
            {
                List<int> result = listOfNumbers.Where(n => n % 2 == 0).ToList();
                result.ForEach(n => Console.Write($"{n} "));

            }
            else
            {
                List<int> result = listOfNumbers.Where(n => n % 2 != 0).ToList();
                result.ForEach(n => Console.Write($"{n} "));

            }
            Console.WriteLine();
            

            
        }
    }
}
