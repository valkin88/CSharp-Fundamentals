using System;

public static class Validator
{
    public static void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be empty.");
        }
    }

    public static void ValidateAge(int age)
    {
        if (age < 0 || age > 15)
        {
            throw new ArgumentException("Age should be between 0 and 15.");
        }
    }
}
