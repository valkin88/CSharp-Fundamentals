using System;
using System.Globalization;
public class Program
{
    static void Main(string[] args)
    {
        DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "yyyy MM dd", CultureInfo.InvariantCulture);
        DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "yyyy MM dd", CultureInfo.InvariantCulture);
        DateModifier date = new DateModifier(startDate, endDate);

        Console.WriteLine(date.CountInDays());
    }
}
