using System;
using System.Collections.Generic;
using System.Linq;

namespace Crossfire
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsAndCols = Console.ReadLine()
                                     .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                     .Select(int.Parse)
                                     .ToArray();

            int[,] matrix = new int[rowsAndCols[0], rowsAndCols[1]];
            int number = 1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = number;
                    number++;
                }
            }

            var input = Console.ReadLine();

            while (input != "Nuke it from orbit")
            {
                var commands = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

                int indexRow = commands[0];
                int indexCol = commands[1];
                int radius = commands[2];
                bool isItTrue = false;


                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[indexRow, indexCol] == matrix[row, col])
                        {
                            for (int i = 1; i <= radius; i++)
                            {
                                matrix[row, col] = 0;
                                if (row + i < matrix.GetLength(0))
                                {
                                    matrix[row + i, col] = 0;
                                }

                                if (row - i >= 0)
                                {
                                    matrix[row - i, col] = 0;
                                }

                                if (col + i < matrix.GetLength(1))
                                {
                                    matrix[row, col + i] = 0;
                                }

                                if (col - i >= 0)
                                {
                                    matrix[row, col - i] = 0;

                                }

                            }
                            isItTrue = true;
                        }
                        if (isItTrue == true)
                        {
                            break;
                        }
                    }
                    if (isItTrue == true)
                    {
                        break;
                    }

                }

                for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (col == matrix.GetLength(1) - 1)
                        {
                            continue;
                        }
                        if (matrix[row, col] == 0 && matrix[row, col + 1] != 0)
                        {

                            matrix[row, col] = matrix[row, col + 1];
                            matrix[row, col + 1] = 0;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        Console.Write($"{matrix[row, col]} ");
                    }

                }
                Console.WriteLine();
            }
        }
    }
}