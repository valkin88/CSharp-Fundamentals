using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<IVehicle> vehicles = new List<IVehicle>();

        for (int i = 0; i < 3; i++)
        {
            vehicles.Add(VehicleFactory.CreateVehicle(Console.ReadLine));
        }

        int numberOfCommands = int.Parse(Console.ReadLine());

        for (int count = 0; count < numberOfCommands; count++)
        {
            string[] command = Console.ReadLine().Split();

            if (command[0] == "Drive")
            {
                vehicles.First(x => x.Type == command[1]).IsEmpty = false;
                vehicles.First(x => x.Type == command[1]).Drive(double.Parse(command[2]));
            }
            else if (command[0] == "DriveEmpty")
            {
                vehicles.First(x => x.Type == command[1]).IsEmpty = true;
                vehicles.First(x => x.Type == command[1]).Drive(double.Parse(command[2]));
            }
            else
            {
                vehicles.First(x => x.Type == command[1]).Refuel(double.Parse(command[2]));
            }
        }

        foreach (var vehicle in vehicles)
        {
            Console.WriteLine(vehicle);
        }
    }
}
