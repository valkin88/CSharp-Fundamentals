using System;
using System.Text.RegularExpressions;

namespace DangerousFloor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] matrix = new string[8, 8];

            for (int row = 0; row < 8; row++)
            {
                var input = Console.ReadLine().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < 8; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            string pattern = @"([A-Z])(\d)(\d)-(\d)(\d)";
            Regex regex = new Regex(pattern);
            var inputCommands = Console.ReadLine();

            while (inputCommands != "END")
            {
                var matches = regex.Match(inputCommands);
                string pieceType = matches.Groups[1].Value;
                int rowPiece = int.Parse(matches.Groups[2].Value);
                int colPiece = int.Parse(matches.Groups[3].Value);
                int rowToMove = int.Parse(matches.Groups[4].Value);
                int colToMove = int.Parse(matches.Groups[5].Value);

                if (matrix[rowPiece, colPiece] == pieceType)
                {
                    switch (pieceType)
                    {
                        case "K":
                            CheckWhereToGo(matrix, rowPiece, colPiece, rowToMove, colToMove, pieceType);
                            inputCommands = Console.ReadLine();
                            continue;
                        case "R":
                            CheckWhereToGo(matrix, rowPiece, colPiece, rowToMove, colToMove, pieceType);
                            inputCommands = Console.ReadLine();
                            continue;
                        case "B":
                            CheckWhereToGo(matrix, rowPiece, colPiece, rowToMove, colToMove, pieceType);
                            inputCommands = Console.ReadLine();
                            continue;
                        case "Q":
                            CheckWhereToGo(matrix, rowPiece, colPiece, rowToMove, colToMove, pieceType);
                            inputCommands = Console.ReadLine();
                            continue;
                        case "P":
                            CheckWhereToGo(matrix, rowPiece, colPiece, rowToMove, colToMove, pieceType);
                            inputCommands = Console.ReadLine();
                            continue; 
                    }
                }
                else
                {
                    Console.WriteLine("There is no such a piece!");
                    inputCommands = Console.ReadLine();
                }
            }
        }

        public static void CheckWhereToGo(string[,] matrix, int rowPiece, int colPiece, int rowToMove, int colToMove, string pieceType)
        {
            if ((pieceType == "P" && Math.Abs(rowToMove - rowPiece) > 1) ||
                (pieceType == "K" && Math.Abs(rowToMove - rowPiece) > 1) ||
                (pieceType == "K" && Math.Abs(colToMove - colPiece) > 1))
            {
                Console.WriteLine("Invalid move!");
            }
            else if (rowToMove < rowPiece)
            {
                if (colToMove < colPiece)
                {
                    if (pieceType == "K" || pieceType == "Q" || pieceType == "B")
                    {
                        WorkingWithUpLeftDiagonal(matrix, rowPiece, colPiece, rowToMove, colToMove);
                    }
                    else
                    {
                        Console.WriteLine("Invalid move!");
                    }
                }
                else if (colToMove == colPiece)
                {
                    if (pieceType == "K" || pieceType == "Q" || pieceType == "R" || pieceType == "P")
                    {
                        WorkingWithUp(matrix, rowPiece, colPiece, rowToMove, colToMove);
                    }
                    else
                    {
                        Console.WriteLine("Invalid move!");
                    }
                }
                else if (colToMove > colPiece)
                {
                    if (pieceType == "K" || pieceType == "Q" || pieceType == "B")
                    {
                        WorkingWithUpRightDiagonal(matrix, rowPiece, colPiece, rowToMove, colToMove);
                    }
                    else
                    {
                        Console.WriteLine("Invalid move!");
                    }
                }
            }
            else if (rowToMove == rowPiece)
            {
                if (colToMove < colPiece)
                {
                    if (pieceType == "K" || pieceType == "Q" || pieceType == "R")
                    {
                        WorkingWithLeft(matrix, rowPiece, colPiece, rowToMove, colToMove);
                    }
                    else
                    {
                        Console.WriteLine("Invalid move!");
                    }
                }
                else if (colToMove > colPiece)
                {
                    if (pieceType == "K" || pieceType == "Q" || pieceType == "R")
                    {
                        WorkingWithRight(matrix, rowPiece, colPiece, rowToMove, colToMove);
                    }
                    else
                    {
                        Console.WriteLine("Invalid move!");
                    }
                }
                else if (colToMove == colPiece)
                {
                    Console.WriteLine("Invalid move!");
                }
            }
            else if (rowToMove > rowPiece)
            {
                if (colToMove < colPiece)
                {
                    if (pieceType == "K" || pieceType == "Q" || pieceType == "B")
                    {
                        WorkingWithDownLeftDiagonal(matrix, rowPiece, colPiece, rowToMove, colToMove);
                    }
                    else
                    {
                        Console.WriteLine("Invalid move!");
                    }
                }
                else if (colToMove == colPiece)
                {
                    if (pieceType == "K" || pieceType == "Q" || pieceType == "R")
                    {
                        WorkingWithDown(matrix, rowPiece, colPiece, rowToMove, colToMove);
                    }
                    else
                    {
                        Console.WriteLine("Invalid move!");
                    }
                }
                else if (colToMove > colPiece)
                {
                    if (pieceType == "K" || pieceType == "Q" || pieceType == "B")
                    {
                        WorkingWithDownRightDiagonal(matrix, rowPiece, colPiece, rowToMove, colToMove);
                    }
                    else
                    {
                        Console.WriteLine("Invalid move!");
                    }
                }
            }
        }

        public static void WorkingWithUpLeftDiagonal(string[,] matrix, int rowPiece, int colPiece, int rowToMove, int colToMove)
        {
            if (rowToMove >= 0 && colToMove >= 0)
            {
                matrix[rowToMove, colToMove] = matrix[rowPiece, colPiece];
                matrix[rowPiece, colPiece] = "x";
            }
            else
            {
                Console.WriteLine("Move go out of board!");
            }
        }

        public static void WorkingWithUpRightDiagonal(string[,] matrix, int rowPiece, int colPiece, int rowToMove, int colToMove)
        {
            if (rowToMove >= 0 && colToMove < 8)
            {
                matrix[rowToMove, colToMove] = matrix[rowPiece, colPiece];
                matrix[rowPiece, colPiece] = "x";
            }
            else
            {
                Console.WriteLine("Move go out of board!");
            }
        }

        public static void WorkingWithDownLeftDiagonal(string[,] matrix, int rowPiece, int colPiece, int rowToMove, int colToMove)
        {
            if (rowToMove < 8 && colToMove >= 0)
            {
                matrix[rowToMove, colToMove] = matrix[rowPiece, colPiece];
                matrix[rowPiece, colPiece] = "x";
            }
            else
            {
                Console.WriteLine("Move go out of board!");
            }
        }

        public static void WorkingWithDownRightDiagonal(string[,] matrix, int rowPiece, int colPiece, int rowToMove, int colToMove)
        {
            if (rowToMove < 8 && colToMove < 8)
            {
                matrix[rowToMove, colToMove] = matrix[rowPiece, colPiece];
                matrix[rowPiece, colPiece] = "x";
            }
            else
            {
                Console.WriteLine("Move go out of board!");
            }
        }

        public static void WorkingWithUp(string[,] matrix, int rowPiece, int colPiece, int rowToMove, int colToMove)
        {
            if (rowToMove >= 0 && colToMove == colPiece)
            {
                matrix[rowToMove, colToMove] = matrix[rowPiece, colPiece];
                matrix[rowPiece, colPiece] = "x";
            }
            else
            {
                Console.WriteLine("Move go out of board!");
            }
        }

        public static void WorkingWithLeft(string[,] matrix, int rowPiece, int colPiece, int rowToMove, int colToMove)
        {
            if (rowToMove == rowPiece && colToMove >= 0)
            {
                matrix[rowToMove, colToMove] = matrix[rowPiece, colPiece];
                matrix[rowPiece, colPiece] = "x";
            }
            else
            {
                Console.WriteLine("Move go out of board!");
            }
        }

        public static void WorkingWithRight(string[,] matrix, int rowPiece, int colPiece, int rowToMove, int colToMove)
        {
            if (rowToMove == rowPiece && colToMove < 8)
            {
                matrix[rowToMove, colToMove] = matrix[rowPiece, colPiece];
                matrix[rowPiece, colPiece] = "x";
            }
            else
            {
                Console.WriteLine("Move go out of board!");
            }
        }

        public static void WorkingWithDown(string[,] matrix, int rowPiece, int colPiece, int rowToMove, int colToMove)
        {
            if (rowToMove < 8 && colToMove == colPiece)
            {
                matrix[rowToMove, colToMove] = matrix[rowPiece, colPiece];
                matrix[rowPiece, colPiece] = "x";
            }
            else
            {
                Console.WriteLine("Move go out of board!");
            }
        }
    }
}
