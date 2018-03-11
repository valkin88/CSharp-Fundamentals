using System;

class Program
{
    static void Main(string[] args)
    {
        Vehicles car = CreateVehicle();
        Vehicles truck = CreateVehicle();

        int numberOfCommands = int.Parse(Console.ReadLine());

        for (int count = 0; count < numberOfCommands; count++)
        {
            string[] command = Console.ReadLine().Split();

            if (command[0] == "Drive")
            {
                Drive(car, truck, command);
            }
            else
            {
                Refuel(car, truck, command);
            }
        }

        Console.WriteLine(car);
        Console.WriteLine(truck);
    }

    private static Vehicles CreateVehicle()
    {
        string[] input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        if (input[0] == "Car")
        {
            Vehicles car = new Car(double.Parse(input[1]), double.Parse(input[2]));
            return car;
        }
        else
        {
            Vehicles truck = new Truck(double.Parse(input[1]), double.Parse(input[2]));
            return truck;
        }
        
    }

    private static void Refuel(Vehicles car, Vehicles truck, string[] command)
    {
        if (command[1] == "Car")
        {
            car.Refuel(double.Parse(command[2]));
        }
        else
        {
            truck.Refuel(double.Parse(command[2]));
        }
    }

    private static void Drive(Vehicles car, Vehicles truck, string[] command)
    {
        if (command[1] == "Car")
        {
            car.Drive(double.Parse(command[2]));
        }
        else
        {
            truck.Drive(double.Parse(command[2]));
        }
    }
}
