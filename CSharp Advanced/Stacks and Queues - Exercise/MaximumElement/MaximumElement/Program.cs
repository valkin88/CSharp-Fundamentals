using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumElement
{
    class MaximumElement
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();
            var maxNumbers = new Stack<int>();
            var maxValue = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                if (input[0] == 1)
                {
                    stack.Push(input[1]);

                    if (maxValue < input[1])
                    {
                        maxValue = input[1];
                        maxNumbers.Push(maxValue);
                    }
                }
                else if (input[0] == 2)
                {
                    if (stack.Pop() == maxValue)
                    {
                        maxNumbers.Pop();

                        if (maxNumbers.Count() != 0)
                        {
                            maxValue = maxNumbers.Peek();
                        }
                        else
                        {
                            maxValue = int.MinValue;
                        }
                    }
                }
                else if (input[0] == 3)
                {
                    Console.WriteLine(maxValue);
                }
            }
        }
    }
}
