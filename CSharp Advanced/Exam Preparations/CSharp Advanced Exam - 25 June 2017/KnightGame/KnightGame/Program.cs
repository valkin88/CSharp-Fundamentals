using System;
using System.Collections.Generic;
using System.Linq;

namespace KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfBoard = int.Parse(Console.ReadLine());

            string[,] board = new string[sizeOfBoard, sizeOfBoard];

            for (int row = 0; row < sizeOfBoard; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < sizeOfBoard; col++)
                {
                    board[row, col] = input[col].ToString();
                }
            }

            int counter = 0;
            int mostCounts = 0;
            int countOfRemovedKnights = 0;

            int badRow = 0;
            int badCol = 0;

            while (true)
            {
                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {

                        if (board[row, col] != "0")
                        {

                            if ((row - 2 >= 0 && col - 1 >= 0) && board[row - 2, col - 1] == "K")
                            {

                                counter++;
                            }
                            if ((row - 2 >= 0 && col + 1 <= sizeOfBoard - 1) && board[row - 2, col + 1] == "K")
                            {
                                counter++;
                            }
                            if ((row - 1 >= 0 && col - 2 >= 0) && board[row - 1, col - 2] == "K")
                            {
                                counter++;
                            }
                            if ((row - 1 >= 0 && col + 2 <= sizeOfBoard - 1) && board[row - 1, col + 2] == "K")
                            {
                                counter++;
                            }
                            if ((row + 1 <= sizeOfBoard - 1 && col - 2 >= 0) && board[row + 1, col - 2] == "K")
                            {
                                counter++;
                            }
                            if ((row + 1 <= sizeOfBoard - 1 && col + 2 <= sizeOfBoard - 1) && board[row + 1, col + 2] == "K")
                            {
                                counter++;
                            }
                            if ((row + 2 <= sizeOfBoard - 1 && col - 1 >= 0) && board[row + 2, col - 1] == "K")
                            {
                                counter++;
                            }
                            if ((row + 2 <= sizeOfBoard - 1 && col + 1 <= sizeOfBoard - 1) && board[row + 2, col + 1] == "K")
                            {
                                counter++;
                            }
                        }
                        if (counter > mostCounts)
                        {
                            mostCounts = counter;
                            badRow = row;
                            badCol = col;
                        }
                        counter = 0;
                    }
                    
                    
                }
                if (mostCounts > 0)
                {
                    board[badRow, badCol] = "0";
                    countOfRemovedKnights++;
                    mostCounts = 0;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(countOfRemovedKnights);
        }
    }
}
