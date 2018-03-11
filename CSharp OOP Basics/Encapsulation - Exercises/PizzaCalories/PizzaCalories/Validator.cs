using System;
using System.Collections.Generic;

public static class Validator
{
    public static void DoughTypeValidator(string value)
    {
        if (value.ToLower() == "white" ||
            value.ToLower() == "wholegrain" ||
            value.ToLower() == "crispy" ||
            value.ToLower() == "chewy" ||
            value.ToLower() == "homemade")
        {
           
        }
        else
        {
            throw new ArgumentException("Invalid type of dough.");
        }
    }

    public static void DoughWeightValidator(double value)
    {
        if (value < 1.0 || value > 200.0)
        {
            throw new ArgumentException("Dough weight should be in the range [1..200].");
        }
    }

    public static void PizzaNameValidator(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
        }
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
        }
        else if (value.Length < 1 || value.Length > 15)
        {
            throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
        }
    }

}
