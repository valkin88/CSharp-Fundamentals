using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<ICitizen> citizens = new List<ICitizen>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputCitizens = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if (inputCitizens.Length == 2)
            {
                ICitizen robot = new Robot(inputCitizens[0], inputCitizens[1]);
                citizens.Add(robot);
            }
            else if (inputCitizens.Length == 3)
            {
                ICitizen person = new Person(inputCitizens[0], int.Parse(inputCitizens[1]), inputCitizens[2]);
                citizens.Add(person);
            }
        }

        string numberToSearch = Console.ReadLine();

        foreach (var citizen in citizens)
        {
            if (citizen.Id.Substring(citizen.Id.Length - numberToSearch.Length) == numberToSearch)
            {
                Console.WriteLine(citizen);
            }
        }
    }
}
