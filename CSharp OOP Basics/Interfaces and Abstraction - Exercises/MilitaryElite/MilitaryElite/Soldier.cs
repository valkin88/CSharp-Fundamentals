using System;
using System.Text;

public class Soldier
{
    private string firstName;
    private string lastName;
    private string id;
    
    public Soldier(string firstName, string lastName, string id)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Id = id;
    }
    public string FirstName
    {
        get { return firstName; }
        private set { firstName = value; }
    }

    public string LastName
    {
        get { return lastName; }
        private set { lastName = value; }
    }

    public string Id
    {
        get { return id; }
        private set { id = value; }
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append($"Name: {this.FirstName} {this.LastName} Id: {this.Id}");

        string result = builder.ToString().TrimEnd();
        return result;
    }
}
