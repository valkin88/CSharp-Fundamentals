using System;
using System.Collections.Generic;
using System.Linq;

namespace SequenceWithQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = long.Parse(Console.ReadLine());
            Queue<long> queue = new Queue<long>();
            long firstNumber = input;
            Console.Write($"{firstNumber} ");
            queue.Enqueue(firstNumber);
            var counter = 1;

            while (counter <= 50)
            {
                firstNumber = queue.Dequeue();

                long s1 = firstNumber + 1;
                Console.Write($"{s1} ");
                queue.Enqueue(s1);
                counter++;

                if (counter == 50)
                {
                    break;
                }

                long s2 = 2 * firstNumber + 1;
                Console.Write($"{s2} ");
                queue.Enqueue(s2);
                counter++;

                if (counter == 50)
                {
                    break;
                }

                long s3 = firstNumber + 2;
                Console.Write($"{s3} ");
                queue.Enqueue(s3);
                counter++;

                if (counter == 50)
                {
                    break;
                }
            }
            Console.WriteLine();
        }
    }
}
