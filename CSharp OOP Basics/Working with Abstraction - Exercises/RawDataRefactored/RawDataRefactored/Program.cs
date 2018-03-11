using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int amountOfCars = int.Parse(Console.ReadLine());
        Car[] cars = new Car[amountOfCars];

        for (int i = 0; i < amountOfCars; i++)
        {
            AddCars(cars, i);
        }

        string carsToPrintByCargoType = Console.ReadLine();

        if (carsToPrintByCargoType == "fragile")
        {
            PrintCarsIfFragileType(cars, carsToPrintByCargoType);
        }
        else
        {
            PrintCarsIfFlamableType(cars, carsToPrintByCargoType);
        }
    }

    private static void PrintCarsIfFlamableType(Car[] cars, string carsToPrintByCargoType)
    {
        cars.Where(c => c.Cargo.Type == carsToPrintByCargoType &&
                        c.Engine.Power > 250)
            .ToList()
            .ForEach(c => Console.WriteLine(c));
    }

    private static void PrintCarsIfFragileType(Car[] cars, string carsToPrintByCargoType)
    {
        cars.Where(c => c.Cargo.Type == carsToPrintByCargoType &&
                         c.Tires.Any(p => p.Pressure < 1))
            .ToList()
            .ForEach(c => Console.WriteLine(c));
    }

    private static void AddCars(Car[] cars, int i)
    {
        string[] input = Console.ReadLine().Split();

        string model = input[0];
        int engineSpeed = int.Parse(input[1]);
        int enginePower = int.Parse(input[2]);
        double cargoWeight = double.Parse(input[3]);
        string cargoType = input[4];
        double firstTirePreassure = double.Parse(input[5]);
        int firstTireAge = int.Parse(input[6]);
        double secondTirePreassure = double.Parse(input[7]);
        int secondTireAge = int.Parse(input[8]);
        double thirdTirePreassure = double.Parse(input[9]);
        int thirdTireAge = int.Parse(input[10]);
        double fourthTirePreassure = double.Parse(input[11]);
        int fourthTireAge = int.Parse(input[12]);

        cars[i] = new Car(model, new Engine(engineSpeed, enginePower),
                          new Cargo(cargoType, cargoWeight), new List<Tire>
                          { new Tire(firstTirePreassure, firstTireAge),
                            new Tire(secondTirePreassure, secondTireAge),
                            new Tire(thirdTirePreassure, thirdTireAge),
                            new Tire(fourthTirePreassure, fourthTireAge)
                          });
    }

}
