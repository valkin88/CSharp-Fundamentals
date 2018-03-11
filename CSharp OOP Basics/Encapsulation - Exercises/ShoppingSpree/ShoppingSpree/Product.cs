using System;
using System.Collections.Generic;

public class Product
{
    private string name;
    private decimal price;

    public Product(string name, decimal price)
    {
        this.Name = name;
        this.Price = price;
    }

    public string Name
    {
        get { return name; }
        set
        {
            Validator.ValidateName(value);
            name = value;
        }
    }

    public decimal Price
    {
        get { return price; }
        set
        {
            Validator.ValidateMoney(value);
            price = value;
        }
    }

    public override string ToString()
    {
        return this.Name;
    }
}
