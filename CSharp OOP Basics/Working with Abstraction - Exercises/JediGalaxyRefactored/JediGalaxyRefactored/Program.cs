using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        string inputLine = Console.ReadLine();
        int matrixRow, matrixCol;

        GetRowAndCol(inputLine, out matrixRow, out matrixCol);

        int[,] matrix = CreateMatrix(matrixRow, matrixCol);

        long sumOfStars = 0;

        while ((inputLine = Console.ReadLine()) != "Let the Force be with you")
        {
            int ivoCurrentRow, ivoCurrentCol;
            int evilCurrentRow, evilCurrentCol;

            GetRowAndCol(inputLine, out ivoCurrentRow, out ivoCurrentCol);

            inputLine = Console.ReadLine();

            GetRowAndCol(inputLine, out evilCurrentRow, out evilCurrentCol);

            GoingThroughCurrentRotation(matrix, ref sumOfStars, ref ivoCurrentRow, ref ivoCurrentCol, ref evilCurrentRow, ref evilCurrentCol);
        }

        Console.WriteLine(sumOfStars);
    }

    private static void GoingThroughCurrentRotation(int[,] matrix, ref long sumOfStars, ref int ivoCurrentRow, ref int ivoCurrentCol, ref int evilCurrentRow, ref int evilCurrentCol)
    {
        GoThroughEvilTurn(matrix, evilCurrentRow, evilCurrentCol);

        sumOfStars = SumPositionsOfIvo(matrix, sumOfStars, ivoCurrentRow, ivoCurrentCol);
    }

    private static void GetRowAndCol(string inputLine, out int row, out int col)
    {
        int[] coordinates = inputLine.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        row = coordinates[0];
        col = coordinates[1];
    }

    private static long SumPositionsOfIvo(int[,] matrix, long sumOfStars, int ivoCurrentRow, int ivoCurrentCol)
    {
        int col = ivoCurrentCol;
        for (int row = ivoCurrentRow; row >= 0; row--)
        {
            if (col >= 0 && col < matrix.GetLength(1) && row < matrix.GetLength(0))
            {
                sumOfStars += matrix[row, col];
            }
            col++;
        }

        return sumOfStars;
    }

    private static void GoThroughEvilTurn(int[,] matrix, int evilCurrentRow, int evilCurrentCol)
    {
        int col = evilCurrentCol;
        for (int row = evilCurrentRow; row >= 0; row--)
        {
            if (col >= 0 && col < matrix.GetLength(1) && row < matrix.GetLength(0))
            {
                matrix[row, col] = 0;
            }
            col--;
        }
    }

    private static int[,] CreateMatrix(int matrixRows, int matrixCols)
    {
        int[,] matrix = new int[matrixRows, matrixCols];

        int value = 0;
        for (int row = 0; row < matrixRows; row++)
        {
            for (int col = 0; col < matrixCols; col++)
            {
                matrix[row, col] = value++;
            }
        }

        return matrix;
    }
}
