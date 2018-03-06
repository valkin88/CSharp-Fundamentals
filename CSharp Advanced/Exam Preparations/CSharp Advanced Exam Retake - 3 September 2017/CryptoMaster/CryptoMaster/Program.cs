using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                               .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToArray();
            int maxSequance = 0;
            for (int step = 1; step < numbers.Length; step++)
            {
                for (int index = 0; index < numbers.Length; index++)
                {
                    int currentIndex = index;
                    int nextIndex = (index + step) % numbers.Length;
                    int currentSequance = 1;
                    while (numbers[currentIndex] < numbers[nextIndex])
                    {
                        currentIndex = nextIndex;
                        nextIndex = (nextIndex + step) % numbers.Length;
                        currentSequance++;
                    }

                    if (currentSequance > maxSequance)
                    {
                        maxSequance = currentSequance;
                    }
                }
            }

            Console.WriteLine(maxSequance);
            
        }
    }
}
