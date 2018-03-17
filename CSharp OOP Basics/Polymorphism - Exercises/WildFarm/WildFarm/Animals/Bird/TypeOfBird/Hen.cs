using System;

public class Hen : Bird
{
    private const double WeightIncrease = 0.35;

    public Hen(string name, double weight, double wingSize)
        : base(name, weight, wingSize)
    {
    }

    public override void EatFood(Food food)
    {
        this.Weight += food.Quantity * WeightIncrease;
        this.FoodEaten += food.Quantity;
    }

    public override void ProduceSound()
    {
        Console.WriteLine("Cluck");
    }
}
