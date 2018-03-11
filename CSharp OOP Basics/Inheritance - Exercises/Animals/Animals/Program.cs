using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>();
        string animalType;
        while ((animalType = Console.ReadLine()) != "Beast!")
        {
            try
            {
                ReadAndCreateAnimals(animals, animalType);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }
        
    }

    private static void ReadAndCreateAnimals(List<Animal> animals, string animalType)
    {
        string[] tokens = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        string animalName = tokens[0];
        int animalAge = int.Parse(tokens[1]);
        string animalGender = null;

        if (tokens.Length == 3)
        {
            animalGender = tokens[2];
        }

        switch (animalType)
        {
            case "Cat":
                var cat = new Cat(animalName, animalAge, animalGender);
                animals.Add(cat);
                break;
            case "Dog":
                var dog = new Dog(animalName, animalAge, animalGender);
                animals.Add(dog);
                break;
            case "Frog":
                var frog = new Frog(animalName, animalAge, animalGender);
                animals.Add(frog);
                break;
            case "Kitten":
                var kitten = new Kitten(animalName, animalAge);
                animals.Add(kitten);
                break;
            case "Tomcat":
                var tomcat = new Tomcat(animalName, animalAge);
                animals.Add(tomcat);
                break;
            default:
                throw new ArgumentException("Invalid input!");
                break;
        }
    }
}
