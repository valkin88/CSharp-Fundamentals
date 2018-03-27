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

        var valueForComparison = Console.ReadLine();
        var result = box.CompareTo(valueForComparison);
        Console.WriteLine(result);
    }
}
