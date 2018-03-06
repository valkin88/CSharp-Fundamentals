using System;
using System.Collections.Generic;
using System.Linq;

namespace MatrixOfPalindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            

            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);
            string[,] palindromes = new string[rows, cols];

            for (int row = 0; row < palindromes.GetLength(0); row++)
            {
                for (int col = 0; col < palindromes.GetLength(1); col++)
                {
                    Console.Write($"{alphabet[row]}{alphabet[row + col]}{alphabet[row]} ");
                }
                Console.WriteLine();
            }

        }
    }
}
