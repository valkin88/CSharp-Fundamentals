﻿using System;

public class Tiger : Feline
{
    private const double WeightIncrease = 1.00;

    public Tiger(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion, breed)
    {
    }

    public override void EatFood(Food food)
    {
        if (food is Meat)
        {
            this.Weight += food.Quantity * WeightIncrease;
            this.FoodEaten += food.Quantity;
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }

    public override void ProduceSound()
    {
        Console.WriteLine("ROAR!!!");
    }
}
