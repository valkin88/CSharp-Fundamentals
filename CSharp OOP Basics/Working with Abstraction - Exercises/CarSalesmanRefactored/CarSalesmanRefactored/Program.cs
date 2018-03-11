using System;
using System.Collections.Generic;
using System.Linq;

public class CarSalesman
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();
        List<Engine> engines = new List<Engine>();

        int engineCount = int.Parse(Console.ReadLine());

        AddEngines(engines, engineCount);

        int carCount = int.Parse(Console.ReadLine());

        AddCars(cars, engines, carCount);

        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }

    private static void AddCars(List<Car> cars, List<Engine> engines, int carCount)
    {
        for (int i = 0; i < carCount; i++)
        {
            string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string model = parameters[0];
            string engineModel = parameters[1];
            int weight = -1;
            string color = "n/a";
            Engine engine = engines.FirstOrDefault(x => x.model == engineModel);

            Checker(ref weight, ref color, parameters);

            cars.Add(new Car(model, engine, weight, color));
        }
    }

    private static void AddEngines(List<Engine> engines, int engineCount)
    {
        for (int i = 0; i < engineCount; i++)
        {
            string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string model = parameters[0];
            int power = int.Parse(parameters[1]);
            int displacement = -1;
            string efficiency = "n/a";

            Checker(ref displacement, ref efficiency, parameters);

            engines.Add(new Engine(model, power, displacement, efficiency));
        }
    }

    private static void Checker(ref int firstVariable, ref string secondVariable, string[] parameters)
    {
        if (parameters.Length == 3)
        {
            if (Char.IsDigit(parameters[2][0]))
            {
                firstVariable = int.Parse(parameters[2]);
            }
            else
            {
                secondVariable = parameters[2];
            }

        }
        else if (parameters.Length == 4)
        {
            firstVariable = int.Parse(parameters[2]);
            secondVariable = parameters[3];
        }
    }
}
