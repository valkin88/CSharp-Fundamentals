using System;
using System.Collections.Generic;

public static class AnimalFactory
{
    public static Animal GetAnimal(string[] animalInput)
    {
        string type = animalInput[0];
        string name = animalInput[1];
        double weight = double.Parse(animalInput[2]);

        switch (type)
        {
            case "Hen":
                double wingSize = double.Parse(animalInput[3]);
                return new Hen(name, weight, wingSize);
            case "Owl":
                wingSize = double.Parse(animalInput[3]);
                return new Owl(name, weight, double.Parse(animalInput[3]));
            case "Mouse":
                string livingRegion = animalInput[3];
                return new Mouse(name, weight, livingRegion);
            case "Dog":
                livingRegion = animalInput[3];
                return new Dog(name, weight, livingRegion);
            case "Cat":
                livingRegion = animalInput[3];
                string breed = animalInput[4];
                return new Cat(name, weight, livingRegion, breed);
            case "Tiger":
                livingRegion = animalInput[3];
                breed = animalInput[4];
                return new Tiger(name, weight, livingRegion, breed);
            default:
                throw new ArgumentException();
        }
    }
}
