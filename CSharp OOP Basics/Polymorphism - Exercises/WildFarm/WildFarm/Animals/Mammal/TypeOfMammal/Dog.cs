using System;

public class Dog : Mammal
{
    private const double WeightIncrease = 0.40;

    public Dog(string name, double weight, string livingRegion)
        : base(name, weight, livingRegion)
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
        Console.WriteLine("Woof!");
    }

    public override string ToString()
    {
        return $"{GetType().Name} [{this.Name}, {this.Weight}, {this.LivingReagion}, {this.FoodEaten}]";
    }
}
