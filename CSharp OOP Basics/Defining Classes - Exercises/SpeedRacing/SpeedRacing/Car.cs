using System;
using System.Collections.Generic;
using System.Linq;

public class Car
{
    private string carModel;
    private decimal fuelAmount;
    private decimal fuelConsumptionFor1km;
    private decimal distanceTraveled;

    private List<Car> cars;

    public List<Car> Cars
    {
        get { return cars; }
        set { cars = value; }
    }

    public Car()
    {
        this.cars = new List<Car>();
    }


    public string CarModel
    {
        get { return carModel; }
        set { carModel = value; }
    }

    public decimal FuelAmount
    {
        get { return fuelAmount; }
        set { fuelAmount = value; }
    }

    public decimal FuelConsumptionFor1km
    {
        get { return fuelConsumptionFor1km; }
        set { fuelConsumptionFor1km = value; }
    }

    public decimal DistanceTraveled
    {
        get { return distanceTraveled; }
        set { distanceTraveled = value; }
    }

    public void Drive(decimal kmToDrive)
    {
        if (this.FuelAmount < kmToDrive * this.FuelConsumptionFor1km)
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
        else
        {
            this.FuelAmount -= kmToDrive * this.FuelConsumptionFor1km;
            this.DistanceTraveled += kmToDrive;
        }
    }
}
