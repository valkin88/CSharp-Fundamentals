using System;
using System.Collections.Generic;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizeOfMatrix = int.Parse(Console.ReadLine());

            int sumFirstDiagonal = 0;
            int sumSecondDiagonal = 0;

            int[,] matrix = new int[sizeOfMatrix, sizeOfMatrix];
            var index = matrix.GetLength(1);
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    
                    
                    matrix[row, col] = int.Parse(input[col]);
                    if (row == col)
                    {
                        sumFirstDiagonal += matrix[row, col];
                    }
                    if (col == index - 1)
                    {
                        sumSecondDiagonal += matrix[row, col];
                        index--;
                    }
                }
            }

            Console.WriteLine(Math.Abs(sumFirstDiagonal - sumSecondDiagonal));
        }
    }
}
