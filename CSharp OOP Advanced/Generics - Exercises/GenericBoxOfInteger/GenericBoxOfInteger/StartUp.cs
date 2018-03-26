using System;

class Program
{
    static void Main(string[] args)
    {
        var countOfInput = int.Parse(Console.ReadLine());

        for (int count = 0; count < countOfInput; count++)
        {
            int number = int.Parse(Console.ReadLine());

            Box<int> box = new Box<int>(number);

            Console.WriteLine(box);
        }
    }
}
