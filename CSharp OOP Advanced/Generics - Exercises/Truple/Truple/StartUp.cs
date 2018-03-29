using System;

class StartUp
{
    static void Main(string[] args)
    {
        string[] inputArgs = Console.ReadLine().Split();

        string fullName = inputArgs[0] + " " + inputArgs[1];
        string address = inputArgs[2];

        Tuple<string, string> firstTuple =
            new Tuple<string, string>(fullName, address);

        inputArgs = Console.ReadLine().Split();
        string personName = inputArgs[0];
        int beerAmount = int.Parse(inputArgs[1]);

        Tuple<string, int> secondTuple =
            new Tuple<string, int>(personName, beerAmount);

        inputArgs = Console.ReadLine().Split();
        int anInteger = int.Parse(inputArgs[0]);
        double aDouble = double.Parse(inputArgs[1]);

        Tuple<int, double> thirdTuple =
            new Tuple<int, double>(anInteger, aDouble);

        Console.WriteLine($"{firstTuple.Item1} -> {firstTuple.Item2}");
        Console.WriteLine($"{secondTuple.Item1} -> {secondTuple.Item2}");
        Console.WriteLine($"{thirdTuple.Item1} -> {thirdTuple.Item2}");

    }
}
