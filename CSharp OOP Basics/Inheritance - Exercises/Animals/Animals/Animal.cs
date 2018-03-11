using System;
using System.Text;

public class Animal : ISoundProducable
{
    private const string ErrorMessage = "Invalid input!";

    private string name;
    private int age;
    private string gender;

    public Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }
    public string Name
    {
        get { return name; }
        set
        {
            NotEmptyValidation(value);
            name = value;
        }
    }

    public int Age
    {
        get { return age; }
        set
        {
            AgeValidation(value);
            age = value;
        }
    }

    public string Gender
    {
        get { return gender; }
        set
        {
            NotEmptyValidation(value);
            gender = value;
        }
    }

    public virtual string ProduceSound()
    {
        return "NOISE!!!!!!!!";
    }

    private static void NotEmptyValidation(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException(ErrorMessage);
        }
    }

    private static void AgeValidation(int value)
    {
        if (value < 0)
        {
            throw new ArgumentException(ErrorMessage);
        }
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"{this.GetType().Name}")
               .AppendLine($"{this.Name} {this.Age} {this.Gender}")
               .AppendLine($"{this.ProduceSound()}");
        var result = builder.ToString().TrimEnd();
        return result;
    }
}
