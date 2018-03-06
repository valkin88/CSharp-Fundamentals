using System;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;

namespace Reverse_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            Stack<string> stackOfNumbers = new Stack<string>(input);


            while (stackOfNumbers.Count != 0)
            {
                Console.Write($"{stackOfNumbers.Pop()} ");
            }
            Console.WriteLine();

        }
    }
}
