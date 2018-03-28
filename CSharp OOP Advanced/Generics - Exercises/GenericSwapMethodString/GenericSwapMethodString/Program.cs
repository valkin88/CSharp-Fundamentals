using System;
using System.Linq;

class StartUp
{
    static void Main(string[] args)
    {
        var countOfInput = int.Parse(Console.ReadLine());
        Box<string> box = new Box<string>();

        for (int count = 0; count < countOfInput; count++)
        {
            var value = Console.ReadLine();

            box.Add(value);
        }

        var swapComand = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        var firstIndex = swapComand[0];
        var secondIndex = swapComand[1];

        box.Swap(firstIndex, secondIndex);

        foreach (var value in box)
        {
            Console.WriteLine($"{value.GetType().FullName}: {value}");
        }
    }
}
