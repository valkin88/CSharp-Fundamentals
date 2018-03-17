using System;

public class Truck : Vehicle
{
    private const double SummerConsumption = 1.6;

    public Truck(string type, double fuelQuantity, double consumptionPerKm, double tankCapacity) : base(type, fuelQuantity, consumptionPerKm, tankCapacity)
    {
    }

    public override void Drive(double distance)
    {
        double fuelNeeded = distance * (this.ConsumptionPerKm + SummerConsumption);

        if (fuelNeeded > this.FuelQuantity)
        {
            Console.WriteLine($"{this.GetType().Name} needs refueling");
        }
        else
        {
            this.FuelQuantity -= fuelNeeded;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }
    }

    public override void Refuel(double amountOfFuel)
    {
        if (amountOfFuel <= 0)
        {
            Console.WriteLine("Fuel must be a positive number");
        }
        else
        {
            if (this.FuelQuantity + amountOfFuel > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {amountOfFuel} fuel in the tank");
            }
            else
            {
                this.FuelQuantity += amountOfFuel * 0.95;
            }
        }
    }
}
