using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<IBirthDate> citizens = new List<IBirthDate>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputCitizens = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if (inputCitizens[0] == "Pet")
            {
                Pet pet = new Pet(inputCitizens[1], inputCitizens[2]);
                citizens.Add(pet);
            }
            else if (inputCitizens[0] == "Citizen")
            {
                Person person = new Person(inputCitizens[1], int.Parse(inputCitizens[2]), inputCitizens[3], inputCitizens[4]);
                citizens.Add(person);
            }
        }

        string yearToSearch = Console.ReadLine();

        foreach (var citizen in citizens)
        {
            if (citizen.BirthDate.EndsWith(yearToSearch))
            {
                Console.WriteLine(citizen);
            }
        }
    }
}
