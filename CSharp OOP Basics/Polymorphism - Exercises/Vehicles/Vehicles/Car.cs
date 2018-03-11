using System;

public class Car : Vehicles
{
    public Car(double fuelQuantity, double consumptionPerKm) : base(fuelQuantity, consumptionPerKm + 0.9)
    {
    }
}
