using System;

public class Truck : Vehicles
{
    public Truck(double fuelQuantity, double consumptionPerKm) : base(fuelQuantity, consumptionPerKm + 1.6)
    {
    }

    public override void Refuel(double amountOfFuel)
    {
        this.FuelQuantity += amountOfFuel * 0.95;
    }
}
