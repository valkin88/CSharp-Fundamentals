using System;
using System.Collections.Generic;

public static class FoodFactory
{
    public static Food GetFood(string[] foodInput)
    {
        string typeOfFood = foodInput[0];
        int foodQuantity = int.Parse(foodInput[1]);

        switch (typeOfFood)
        {
            case "Vegetable": return new Vegetable(foodQuantity);
            case "Meat": return new Meat(foodQuantity);
            case "Fruit": return new Fruit(foodQuantity);
            case "Seeds": return new Seeds(foodQuantity);
            default:
                throw new ArgumentException();
        }
    }
}