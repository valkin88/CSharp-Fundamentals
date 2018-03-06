using System;
using System.Linq;

namespace Cubic_s_Rube
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            if (n == 0)
            {
                return;
            }
            var cube = new long[n, n, n];
            long counter = 0;
            var input = Console.ReadLine();
            long sumAllCells = 0;
            long rowToHit = 0;
            long colToHit = 0;
            long deepToHit = 0;



            while (input != "Analyze")
            {
                var inputSplit = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();

                long rowIndex = inputSplit[0];
                long colIndex = inputSplit[1];
                long deepIndex = inputSplit[2];
                long particles = inputSplit[3];



                if (rowIndex >= 0 && rowIndex < cube.GetLength(0) && colIndex >= 0 && colIndex < cube.GetLength(1) && deepIndex >= 0 && deepIndex < cube.GetLength(2) && particles != 0)
                {
                    if (rowIndex != rowToHit || colIndex != colToHit || deepIndex != deepToHit)
                    {

                        cube[rowIndex, colIndex, deepIndex] = particles;
                        rowToHit = rowIndex;
                        colToHit = colIndex;
                        deepToHit = deepIndex;
                        counter++;
                        sumAllCells += particles;
                    }

                }

                input = Console.ReadLine();
            }
            long notHittedCells = (n * n * n) - counter;

            Console.WriteLine(sumAllCells);
            Console.WriteLine(notHittedCells);



        }
    }
}