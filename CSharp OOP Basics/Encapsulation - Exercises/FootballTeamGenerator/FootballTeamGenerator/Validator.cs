using System;
using System.Collections.Generic;
using System.Text;

public static class Validator
{
    public static void ValidateName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("A name should not be empty.");
        }
        else if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("A name should not be empty.");
        }
    }
}
