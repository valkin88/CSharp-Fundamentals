using System;

class StartUp
{
    static void Main(string[] args)
    {
        var countOfInput = int.Parse(Console.ReadLine());

        for (int count = 0; count < countOfInput; count++)
        {
            var value = Console.ReadLine();

            Box<string> box = new Box<string>(value);

            Console.WriteLine(box);
        }
    }
}
