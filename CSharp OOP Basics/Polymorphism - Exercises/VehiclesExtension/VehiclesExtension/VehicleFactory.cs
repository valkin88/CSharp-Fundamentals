using System;

public static class VehicleFactory
{
    public static IVehicle CreateVehicle(Func<string> reader)
    {
        string[] input = reader().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

        if (input[0] == "Car")
        {
            return new Car(input[0], double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]));
        }
        else if (input[0] == "Truck")
        {
            return new Truck(input[0], double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]));
        }
        else
        {
            return new Bus(input[0], double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]));
        }

    }
}
