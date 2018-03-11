using System;

public abstract class Vehicle : IVehicle
{
    private string type;
    private double fuelQuantity;
    private double consumptionPerKm;
    private double tankCapacity;
    private bool isEmpty;

    public Vehicle(string type, double fuelQuantity, double consumptionPerKm, double tankCapacity)
    {
        this.Type = type;
        this.ConsumptionPerKm = consumptionPerKm;
        this.TankCapacity = tankCapacity;
        this.FuelQuantity = fuelQuantity;
    }

    public string Type
    {
        get { return type; }
        private set { type = value; }
    }

    public double FuelQuantity
    {
        get { return this.fuelQuantity; }
        set
        {
            if (value > this.TankCapacity)
            {
                value = 0;
            }

            this.fuelQuantity = value;
        }
    }

    public double ConsumptionPerKm
    {
        get { return consumptionPerKm; }
        set { consumptionPerKm = value; }
    }

    public double TankCapacity
    {
        get { return tankCapacity; }
        private set { tankCapacity = value; }
    }

    public bool IsEmpty
    {
        get { return isEmpty; }
        set { isEmpty = value; }
    }

    public abstract void Drive(double distance);

    public virtual void Refuel(double amountOfFuel)
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
                this.FuelQuantity += amountOfFuel;
            }
        }
        
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}
