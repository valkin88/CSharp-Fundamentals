using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfNumbers = Console.ReadLine()
                                             .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                             .Select(int.Parse)
                                             .OrderBy(n => n)
                                             .ToList();

            var listOfOrderedNumbers = AddEvenAndOddNumbers(listOfNumbers);
            
            listOfOrderedNumbers.ForEach(n => Console.Write($"{n} "));
            Console.WriteLine();


        }

        public static List<int> AddEvenAndOddNumbers(List<int> listOfNumbers)
        {
            List<int> listOfOrderedNumbers = new List<int>();

            foreach (var number in listOfNumbers)
            {
                if (number % 2 == 0)
                {
                    listOfOrderedNumbers.Add(number);
                }
            }

            foreach (var number in listOfNumbers)
            {
                if (number % 2 != 0)
                {
                    listOfOrderedNumbers.Add(number);
                }
            }

            return listOfOrderedNumbers;
        }

    }
}
