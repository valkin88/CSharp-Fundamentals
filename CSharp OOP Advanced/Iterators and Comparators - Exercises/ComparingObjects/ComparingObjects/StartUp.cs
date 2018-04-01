using System;
using System.Collections.Generic;

class StartUp
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();
        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            string[] inputData = input.Split(' ');

            string personName = inputData[0];
            int personAge = int.Parse(inputData[1]);
            string personTown = inputData[2];

            Person person = new Person(personName, personAge, personTown);
            people.Add(person);
        }

        int indexOfPersonToCompare = int.Parse(Console.ReadLine()) - 1;
        var personToCompare = people[indexOfPersonToCompare];
        int countOfEqualPeople = 0;

        foreach (var person in people)
        {
            int resultOfComparison = personToCompare.CompareTo(person);

            if (resultOfComparison == 0)
            {
                countOfEqualPeople++;
            }
        }

        if (countOfEqualPeople - 1 == 0)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            int notEqualPeople = people.Count - countOfEqualPeople;

            Console.WriteLine($"{countOfEqualPeople} {notEqualPeople} {people.Count}");
        }
        
    }
}
