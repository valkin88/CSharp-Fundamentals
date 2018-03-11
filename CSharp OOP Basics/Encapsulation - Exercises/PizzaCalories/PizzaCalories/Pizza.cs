using System;
using System.Collections.Generic;
using System.Linq;

public class Pizza
{
    private string name;
    private Dough dough;
    private List<Topping> toppings;

    public string Name
    {
        get { return name; }
        private set
        {
            Validator.PizzaNameValidator(value);
            name = value;
        }
    }

    public Dough Dough
    {
        get { return dough; }
        private set { dough = value; }
    }

    public List<Topping> Toppings
    {
        get { return toppings; }
        private set
        {
            toppings = value;
        }
    }

    public Pizza(string name, Dough dough)
    {
        this.Name = name;
        this.Dough = dough;
        this.Toppings = new List<Topping>();
    }

    public double CountTotalCalories
    { 
        get
        {
            return this.Dough.CalculateDoughCalories + this.Toppings.Sum(x => x.CalculateToppingCalories);
        }
    }

    public void AddTopping(string toppingName, double toppingWeight)
    {
        Topping topping = new Topping(toppingName, toppingWeight);
        this.Toppings.Add(topping);
    }

}
