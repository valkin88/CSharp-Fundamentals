using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;

namespace StackFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            long editedNumber = long.Parse(Console.ReadLine());
            Stack<long> fibonacciStack = new Stack<long>();
            FindingFibonacciNumber(fibonacciStack, editedNumber);

        }

        static long FindingFibonacciNumber(Stack<long> fibonacciStack, long editedNumber)
        {
            long result = 0;
            long f0 = 0;
            long f1 = 1;
            fibonacciStack.Push(f0);
            fibonacciStack.Push(f1);
            long fNext = 0;

            for (long i = 0; i < editedNumber; i++)
            {
                fNext = f0 + fibonacciStack.Peek();
                f0 = fibonacciStack.Peek();
                f1 = fNext;
                fibonacciStack.Push(fNext);
            }
            result = f0;
            Console.WriteLine(result);

            return result;
        }
    }
}
