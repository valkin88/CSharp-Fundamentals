using System;

public abstract class Animal
{
    private string name;
    private double weight;
    private int foodEaten;

    public Animal(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
        this.FoodEaten = 0;
    }

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    public double Weight
    {
        get { return weight; }
        protected set { weight = value; }
    }

    public int FoodEaten
    {
        get { return foodEaten; }
        protected set { foodEaten = value; }
    }

    public abstract void ProduceSound();

    public abstract void EatFood(Food food);

}
