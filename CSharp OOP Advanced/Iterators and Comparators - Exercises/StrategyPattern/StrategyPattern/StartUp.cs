using System;
using System.Collections.Generic;

class StartUp
{
    static void Main(string[] args)
    {
        SortedSet<Person> sortedSetByName = new SortedSet<Person>(new ComparerByName());
        SortedSet<Person> sortedSetByAge = new SortedSet<Person>(new ComparerByAge());

        int numberOfPeople = int.Parse(Console.ReadLine());

        for (int count = 0; count < numberOfPeople; count++)
        {
            var inputData = Console.ReadLine().Split(' ');

            string personName = inputData[0];
            int personAge = int.Parse(inputData[1]);

            Person person = new Person(personName, personAge);

            sortedSetByName.Add(person);
            sortedSetByAge.Add(person);
        }

        if (numberOfPeople != 0)
        {
            Console.WriteLine(string.Join(Environment.NewLine, sortedSetByName));
            Console.WriteLine(string.Join(Environment.NewLine, sortedSetByAge));
        }
    }
}
