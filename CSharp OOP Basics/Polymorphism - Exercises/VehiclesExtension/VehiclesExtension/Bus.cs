using System;

public class Bus : Vehicle
{
    private const double AirConditionarConsumption = 1.4;

    public Bus(string type, double fuelQuantity, double consumptionPerKm, double tankCapacity) : base(type, fuelQuantity, consumptionPerKm, tankCapacity)
    {
    }

    public override void Drive(double distance)
    {
        if (base.IsEmpty)
        {
            Drive(distance, base.ConsumptionPerKm);
        }
        else
        {
            Drive(distance, base.ConsumptionPerKm + AirConditionarConsumption);
        } 
    }

    private void Drive(double distance, double consumption)
    {
        if (distance * consumption > this.FuelQuantity)
        {
            Console.WriteLine($"{this.GetType().Name} needs refueling");
        }
        else
        {
            this.FuelQuantity -= distance * consumption;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }
    }

    
}
