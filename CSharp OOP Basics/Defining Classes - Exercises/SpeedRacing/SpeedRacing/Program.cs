using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int numberOfCars = int.Parse(Console.ReadLine());
        
        List<Car> cars = new List<Car>();
        string model = String.Empty;
        decimal amountOfFuel = 0;
        decimal fuelConsumption = 0;

        for (int countCars = 0; countCars < numberOfCars; countCars++)
        {
            string[] input = Console.ReadLine().Split();
            Car car = new Car();
            car.CarModel = input[0];
            car.FuelAmount = decimal.Parse(input[1]);
            car.FuelConsumptionFor1km = decimal.Parse(input[2]);
            car.DistanceTraveled = 0;
            cars.Add(car);

        }

        var inputLines = Console.ReadLine();
        decimal kmToDrive = 0;
        
        while (inputLines != "End")
        {
            var enteringCarsInput = inputLines.Split();

            model = enteringCarsInput[1];
            kmToDrive = decimal.Parse(enteringCarsInput[2]);
            cars.Where(c => c.CarModel == model).ToList().ForEach(c => c.Drive(kmToDrive));


            inputLines = Console.ReadLine();

        }

        foreach (var c in cars)
        {
            Console.WriteLine($"{c.CarModel} {c.FuelAmount:F2} {c.DistanceTraveled}");
        }


    }

}
