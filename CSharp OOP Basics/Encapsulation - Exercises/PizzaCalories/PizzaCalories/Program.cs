using System;

class Program
{
    static void Main(string[] args)
    {
        
        try
        {
            string[] inputNameOfPizza = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string[] inputDough = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if (inputNameOfPizza.Length < 2)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");

            }
            Pizza pizza = new Pizza(inputNameOfPizza[1], new Dough(inputDough[1], inputDough[2], double.Parse(inputDough[3])));

            string input = Console.ReadLine();
            bool IsTheTrue = AddToppings(pizza, ref input);

            if (IsTheTrue == false)
            {
                Console.WriteLine($"{pizza.Name} - {pizza.CountTotalCalories:f2} Calories.");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }

    private static bool AddToppings(Pizza pizza, ref string input)
    {
        int counter = 1;
        bool IsTheTrue = false;
        while (input != "END")
        {
            string[] inputTopping = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            string type = inputTopping[1];
            double toppingWeight = double.Parse(inputTopping[2]);
            pizza.AddTopping(type, toppingWeight);

            input = Console.ReadLine();
            if (counter == 10)
            {
                Console.WriteLine("Number of toppings should be in range [0..10].");
                IsTheTrue = true;
                break;
            }
            counter++;
        }

        return IsTheTrue;
    }
}
