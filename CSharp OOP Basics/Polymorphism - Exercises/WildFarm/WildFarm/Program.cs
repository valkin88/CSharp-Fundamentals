using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>();

        while (true)
        {
            string animalInput = Console.ReadLine();
            if (animalInput == "End")
            {
                break;
            }
            string foodInput = Console.ReadLine();

            Animal animal = AnimalFactory.GetAnimal(animalInput.Split());
            Food food = FoodFactory.GetFood(foodInput.Split());

            animal.ProduceSound();
            animal.EatFood(food);
            animals.Add(animal);
        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }
    }
}
