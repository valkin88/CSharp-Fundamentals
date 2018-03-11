using System;

public class Car : Vehicle
{
    private const double summerConsumption = 0.9;

    public Car(string type, double fuelQuantity, double consumptionPerKm, double tankCapacity) : base(type, fuelQuantity, consumptionPerKm, tankCapacity)
    {
    }

    public override void Drive(double distance)
    {
        double fuelNeeded = distance * (this.ConsumptionPerKm + summerConsumption);

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
}
