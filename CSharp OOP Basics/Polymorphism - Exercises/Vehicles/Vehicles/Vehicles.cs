using System;

public abstract class Vehicles
{
    private double fuelQuantity;
    private double consumptionPerKm;

    public Vehicles(double fuelQuantity, double consumptionPerKm)
    {
        this.FuelQuantity = fuelQuantity;
        this.ConsumptionPerKm = consumptionPerKm;
    }

    public double FuelQuantity
    {
        get { return fuelQuantity; }
        set
        {
            fuelQuantity = value;
        }
    }

    public double ConsumptionPerKm
    {
        get { return consumptionPerKm; }
        private set { consumptionPerKm = value; }
    }

    public void Drive(double distance)
    {
        if (distance * this.ConsumptionPerKm > this.fuelQuantity)
        {
            Console.WriteLine($"{this.GetType().Name} needs refueling");
        }
        else
        {
            this.FuelQuantity -= distance * this.ConsumptionPerKm;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }
        
    }

    public virtual void Refuel(double amountOfFuel)
    {
        this.FuelQuantity += amountOfFuel;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}
