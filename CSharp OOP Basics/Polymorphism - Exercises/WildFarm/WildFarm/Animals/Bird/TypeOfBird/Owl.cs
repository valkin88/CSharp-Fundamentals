using System;

public class Owl : Bird
{
    private const double WeightIncrease = 0.25;

    public Owl(string name, double weight, double wingSize)
        : base(name, weight, wingSize)
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
        Console.WriteLine("Hoot Hoot");
    }
}
