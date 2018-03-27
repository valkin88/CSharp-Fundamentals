using System;
using System.Linq;

class StartUp
{
    static void Main(string[] args)
    {
        var countOfInput = int.Parse(Console.ReadLine());
        Box<double> box = new Box<double>();

        for (int count = 0; count < countOfInput; count++)
        {
            var value = double.Parse(Console.ReadLine());

            box.Add(value);
        }

        var valueForComparison = double.Parse(Console.ReadLine());
        var result = box.CompareTo(valueForComparison);
        Console.WriteLine(result);
    }
}
