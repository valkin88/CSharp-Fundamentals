using System;

public class Mouse : Mammal
{
    private const double weightIncrease = 0.10;

    public Mouse(string name, double weight, string livingRegion) 
        : base(name, weight, livingRegion)
    {
    }

    public override void EatFood(Food food)
    {
        if ((food is Vegetable) || (food is Fruit))
        {
            this.Weight += food.Quantity * weightIncrease;
            this.FoodEaten += food.Quantity;
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }

    public override void ProduceSound()
    {
        Console.WriteLine("Squeak");
    }

    public override string ToString()
    {
        return $"{GetType().Name} [{this.Name}, {this.Weight}, {this.LivingReagion}, {this.FoodEaten}]";
    }
}
