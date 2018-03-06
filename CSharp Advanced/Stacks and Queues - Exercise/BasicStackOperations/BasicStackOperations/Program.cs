using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;

namespace BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            
            int countOfNumbers = input[0];
            int countOfNumbersToPop = input[1];
            int numberToFind = input[2];
            Stack<int> stackOfNumbers = new Stack<int>();

            var seconfInput = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            for (int i = 0; i < countOfNumbers; i++)
            {
                stackOfNumbers.Push(seconfInput[i]);   
            }

            for (int i = 0; i < countOfNumbersToPop; i++)
            {
                stackOfNumbers.Pop();
            }
            int minNumber = int.MaxValue;
            bool findNumber = false;
            foreach (var number in stackOfNumbers)
            {

                if (number <= minNumber)
                {
                    minNumber = number;
                }
                if (number == numberToFind)
                {
                    findNumber = true;
                    Console.WriteLine("true");
                }
            }
            if (stackOfNumbers.Count == 0)
            {
                Console.WriteLine("0");
            }
            else if (findNumber == false)
            {
                Console.WriteLine(minNumber);
            }

            

        }
    }
}
