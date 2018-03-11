using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            List<Person> people = ParsePeople();
            List<Product> products = ParseProducts();

            BuyProduct(people, products);

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }

    private static void BuyProduct(List<Person> people, List<Product> products)
    {
        string command;

        while ((command = Console.ReadLine()) != "END")
        {
            string[] tokens = command.Split();

            string personName = tokens[0];
            string productName = tokens[1];

            Person person = people.First(p => p.Name == personName);
            Product product = products.First(p => p.Name == productName);

            string output = person.TryBuyProduct(product);
            Console.WriteLine(output);
        }
    }

    private static List<Product> ParseProducts()
    {
        string[] productsInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

        List<Product> products = new List<Product>();

        foreach (var itemInput in productsInput)
        {
            string[] itemTokens = itemInput.Split('=', StringSplitOptions.RemoveEmptyEntries);

            string productName = itemTokens[0];
            decimal productPrice = decimal.Parse(itemTokens[1]);

            Product product = new Product(productName, productPrice);
            products.Add(product);

        }

        return products;
    }

    private static List<Person> ParsePeople()
    {
        string[] peopleInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

        List<Person> people = new List<Person>();

        foreach (var personInput in peopleInput)
        {
            string[] personTokens = personInput.Split('=', StringSplitOptions.RemoveEmptyEntries);

            string personName = personTokens[0];
            decimal personMoney = decimal.Parse(personTokens[1]);

            Person person = new Person(personName, personMoney);
            people.Add(person);

        }

        return people;
    }
}
