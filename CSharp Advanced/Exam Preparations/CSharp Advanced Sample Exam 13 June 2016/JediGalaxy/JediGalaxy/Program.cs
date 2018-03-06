namespace _02.JediGalaxy
{
    using System;
    using System.Linq;

    public static class JediGalaxy
    {
        public static void Main()
        {
            var size = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var matrix = new int[size[0], size[1]];
            long result = 0;
            var counter = 0;
            for (int row = 0; row < size[0]; row++)
            {
                for (int col = 0; col < size[1]; col++)
                {
                    matrix[row, col] = counter;
                    counter++;
                }
            }
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Let the Force be with you")
                {
                    break;
                }

                var ivoStart = input.Split().Select(int.Parse).ToArray();
                var evilStart = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var col = evilStart[1];
                for (int row = evilStart[0]; row >= 0; row--)
                {
                    if (col >= 0 && col < size[1] && row < size[0])
                    {
                        matrix[row, col] = 0;
                    }
                    col--;
                }

                col = ivoStart[1];
                for (int row = ivoStart[0]; row >= 0; row--)
                {
                    if (col >= 0 && col < size[1] && row < size[0])
                    {
                        result += matrix[row, col];
                    }
                    col++;
                }
            }
            Console.WriteLine(result);
        }
    }
}