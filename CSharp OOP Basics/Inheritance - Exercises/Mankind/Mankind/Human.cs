using System;
using System.Collections.Generic;
using System.Text;

public class Human
{
    private const int firstNameMinLenght = 4;
    private const int lastNameMinLenght = 3;
    private string firstName;
    private string lastName;

    public virtual string FirstName
    {
        get { return firstName; }
        set
        {
            Validator.ValidateName(value, nameof(firstName), firstNameMinLenght);
            firstName = value;
        }
    }

    public virtual string LastName
    {
        get { return lastName; }
        set
        {
            Validator.ValidateName(value, nameof(lastName), lastNameMinLenght);
            lastName = value;
        }
    }

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"First Name: {this.FirstName}");
        builder.AppendLine($"Last Name: {this.LastName}");

        return builder.ToString();
    }
}
