using System;
using System.Collections.Generic;
using System.Text;

public class Topping
{
    private string toppingType;
    private double weight;

    public string ToppingType
    {
        get { return toppingType; }
        private set
        {
            if (value.ToLower() == "meat" ||
            value.ToLower() == "veggies" ||
            value.ToLower() == "cheese" ||
            value.ToLower() == "sauce")
            {
                toppingType = value;
            }
            else
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            
        }
    }

    public double Weight
    {
        get { return weight; }
        private set
        {
            if (value < 1.0 || value > 50.0)
            {
                throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
            }
            weight = value;
        }
    }

    public Topping(string toppingType, double weight)
    {
        this.ToppingType = toppingType;
        this.Weight = weight;
    }

    public double CalculateToppingCalories
    {
        get
        {
            return (2 * this.Weight) * this.ToppingModifier();
        }
    }

    private double ToppingModifier()
    {
        if (this.ToppingType.ToLower() == "meat")
        {
            return 1.2;
        }
        else if (this.ToppingType.ToLower() == "veggies")
        {
            return 0.8;
        }
        else if (this.ToppingType.ToLower() == "cheese")
        {
            return 1.1;
        }
        else
        {
            return 0.9;
        }
        
    }

}
