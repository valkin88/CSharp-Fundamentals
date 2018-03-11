using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public static class Validator
{
    
    public static void ValidateName(string value, string type, int minLenght)
    {
        if (Char.IsLower(value[0]))
        {
            throw new ArgumentException($"Expected upper case letter! Argument: {type}");
        }

        if (value.Length < minLenght)
        {
            throw new ArgumentException($"Expected length at least {minLenght} symbols! Argument: {type}");
        }


    }

    public static void ValidateFacultyNumber(string number)
    {
        string pattern = @"^([a-zA-Z\d]{5,10})$";

        if (!Regex.IsMatch(number, pattern))
        {
            throw new ArgumentException("Invalid faculty number!");
        }
    }

    public static void ValidateSalary(double salary, string type)
    {
        if (salary <= 10.0)
        {
            throw new ArgumentException($"Expected value mismatch! Argument: {type}");
        }
    }

    public static void ValidateWorkingHours(double hours, string type)
    {
        if (hours < 1 || hours > 12)
        {
            throw new ArgumentException($"Expected value mismatch! Argument: {type}");
        }
    }
}
