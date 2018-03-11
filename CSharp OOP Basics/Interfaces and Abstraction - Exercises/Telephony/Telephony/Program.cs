using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string[] phoneNumbersInput = Console.ReadLine().Split();
        string[] websitesInput = Console.ReadLine().Split();

        Smartphone smartphone = new Smartphone();

        foreach (var number in phoneNumbersInput)
        {
            try
            {
                Console.WriteLine(smartphone.Calling(number));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        foreach (var website in websitesInput)
        {
            try
            {
                Console.WriteLine(smartphone.Browsing(website));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
