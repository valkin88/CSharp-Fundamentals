using System;
using System.Collections.Generic;
using System.Linq;

namespace RubiksMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsAndCols = Console.ReadLine()
                                     .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                     .Select(int.Parse)
                                     .ToArray();

            int[,] rubikCube = new int[rowsAndCols[0], rowsAndCols[1]];
            int number = 1;
            for (int row = 0; row < rubikCube.GetLength(0); row++)
            {
                for (int col = 0; col < rubikCube.GetLength(1); col++)
                {
                    rubikCube[row, col] = number;
                    number++;
                }
            }

            var numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                var command = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                int countOfTimesToShift = int.Parse(command[2]);
                if (command[1] == "down" || command[1] == "up")
                {
                    int colToShift = int.Parse(command[0]);
                    if (command[1] == "down")
                    {
                        ShiftDown(rubikCube, colToShift, countOfTimesToShift);
                    }
                    else
                    {
                        ShiftUp(rubikCube, colToShift, countOfTimesToShift);
                    }
                }
                if (command[1] == "left" || command[1] == "right")
                {
                    int rowToShift = int.Parse(command[0]);
                    if (command[1] == "left")
                    {
                        ShiftLeft(rubikCube, rowToShift, countOfTimesToShift);
                    }
                    else
                    {
                        ShiftRight(rubikCube, rowToShift, countOfTimesToShift);
                    }
                }
            }

            PrintResult(rubikCube);

        }

        private static void PrintResult(int[,] rubikCube)
        {
            int number = 1;
            int correctRow = 0;
            int correctCol = 0;
            int numberToSave = 0;
            for (int row = 0; row < rubikCube.GetLength(0); row++)
            {
                for (int col = 0; col < rubikCube.GetLength(1); col++)
                {
                    if (rubikCube[row, col] == number)
                    {
                        Console.WriteLine("No swap required");
                        number++;
                    }
                    else
                    {
                        bool isItTrue = false;
                        for (int rows = row; rows < rubikCube.GetLength(0); rows++)
                        {
                            for (int cols = 0; cols < rubikCube.GetLength(1); cols++)
                            {
                                if (rubikCube[rows, cols] == number)
                                {
                                    correctRow = rows;
                                    correctCol = cols;
                                    isItTrue = true;
                                    break;
                                }
                            }
                            if (isItTrue == true)
                            {
                                break;
                            }
                        }

                        numberToSave = rubikCube[row, col];
                        rubikCube[row, col] = rubikCube[correctRow, correctCol];
                        rubikCube[correctRow, correctCol] = numberToSave;
                        Console.WriteLine($"Swap ({row}, {col}) with ({correctRow}, {correctCol})");
                        number++;
                    }
                }
            }
        }

        private static void ShiftRight(int[,] rubikCube, int rowToShift, int countOfTimesToShift)
        {
            for (int i = 0; i < countOfTimesToShift % rubikCube.GetLength(1); i++)
            {
                int lastNumberOfArray = rubikCube[rowToShift, rubikCube.GetLength(1) - 1];
                for (int col = rubikCube.GetLength(1) - 1; col >= 1; col--)
                {
                    rubikCube[rowToShift, col] = rubikCube[rowToShift, col - 1]; ;
                }
                rubikCube[rowToShift, 0] = lastNumberOfArray;
            }
        }

        private static void ShiftLeft(int[,] rubikCube, int rowToShift, int countOfTimesToShift)
        {
            for (int i = 0; i < countOfTimesToShift % rubikCube.GetLength(1); i++)
            {
                int lastNumberOfArray = rubikCube[rowToShift, 0];
                for (int col = 0; col < rubikCube.GetLength(1) - 1; col++)
                {
                    rubikCube[rowToShift, col] = rubikCube[rowToShift, col + 1];
                }
                rubikCube[rowToShift, rubikCube.GetLength(1) - 1] = lastNumberOfArray;
            }
        }

        private static void ShiftUp(int[,] rubikCube, int colToShift, int countOfTimesToShift)
        {
            for (int i = 0; i < countOfTimesToShift % rubikCube.GetLength(0); i++)
            {
                int lastNumberOfArray = rubikCube[0, colToShift];
                for (int row = 0; row < rubikCube.GetLength(1) - 1; row++)
                {
                    rubikCube[row, colToShift] = rubikCube[row + 1, colToShift];
                }
                rubikCube[rubikCube.GetLength(0) - 1, colToShift] = lastNumberOfArray;
            }
        }

        private static void ShiftDown(int[,] rubikCube, int colToShift, int countOfTimesToShift)
        {
            for (int i = 0; i < countOfTimesToShift % rubikCube.GetLength(0); i++)
            {
                int lastNumberOfArray = rubikCube[rubikCube.GetLength(0) - 1, colToShift];
                for (int row = rubikCube.GetLength(0) - 1; row >= 1; row--)
                {
                    rubikCube[row, colToShift] = rubikCube[row - 1, colToShift]; ;
                }
                rubikCube[0, colToShift] = lastNumberOfArray;
            }
        }
    }
}