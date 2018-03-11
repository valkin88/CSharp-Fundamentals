using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<IBuyer> buyers = new List<IBuyer>();

        int numberOfBuyers = int.Parse(Console.ReadLine());
        for (int count = 0; count < numberOfBuyers; count++)
        {
            string[] buyersInput = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if (buyersInput.Length == 3)
            {
                var rebel = new Rebel(buyersInput[0], int.Parse(buyersInput[1]), buyersInput[2]);
                buyers.Add(rebel);
            }
            else if (buyersInput.Length == 4)
            {
                var citizen = new Citizen(buyersInput[0], int.Parse(buyersInput[1]), buyersInput[2], buyersInput[3]);
                buyers.Add(citizen);
            }
        }

        string inputName;
        while ((inputName = Console.ReadLine()) != "End")
        {
            if (buyers.Any(n => n.Name == inputName))
            {
                buyers.First(n => n.Name == inputName).BuyFood();
            }
        }

        Console.WriteLine(buyers.Sum(x => x.Food));
        
    }
}
