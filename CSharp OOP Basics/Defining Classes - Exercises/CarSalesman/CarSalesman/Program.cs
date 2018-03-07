using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int numberOfEngines = int.Parse(Console.ReadLine());
        Engine[] engines = new Engine[numberOfEngines];

        for (int i = 0; i < numberOfEngines; i++)
        {
            string[] inputOfEngines = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            string model = inputOfEngines[0];
            int power = int.Parse(inputOfEngines[1]);
            string displacement = String.Empty;
            string efficiency = String.Empty;

            DetermineTheOptionalVariables(inputOfEngines, out displacement, out efficiency);

            engines[i] = new Engine(model, power, displacement, efficiency);
        }

        int numberOfCars = int.Parse(Console.ReadLine());

        Car[] cars = new Car[numberOfCars];

        for (int i = 0; i < numberOfCars; i++)
        {
            string[] inputOfCars = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string model = inputOfCars[0];
            string engineModel = inputOfCars[1];
            Engine engine = null;
            string weight = String.Empty;
            string color = String.Empty;

            engine = FindEngine(engines, engineModel, engine);

            DetermineTheOptionalVariables(inputOfCars, out weight, out color);

            cars[i] = new Car(model, engine, weight, color);
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Model}:");
            Console.WriteLine($"  {car.Engine.Model}:");
            Console.WriteLine($"    Power: {car.Engine.Power}");
            Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
            Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
            Console.WriteLine($"  Weight: {car.Weight}");
            Console.WriteLine($"  Color: {car.Color}");
        }
    }
    private static void DetermineTheOptionalVariables(string[] input, out string firstVariable, out string secondVariable)
    {
        if (input.Length == 4)
        {
            firstVariable = input[2];
            secondVariable = input[3];
        }
        else if (input.Length == 2)
        {
            firstVariable = "n/a";
            secondVariable = "n/a";
        }
        else
        {
            if (Char.IsDigit(input[2][0]))
            {
                firstVariable = input[2];
                secondVariable = "n/a";
            }
            else
            {
                firstVariable = "n/a";
                secondVariable = input[2];
            }
        }
    }

    private static Engine FindEngine(Engine[] engines, string engineModel, Engine engine)
    {
        foreach (var e in engines)
        {
            if (e.Model == engineModel)
            {
                engine = e;
                break;
            }
        }

        return engine;
    }
}
