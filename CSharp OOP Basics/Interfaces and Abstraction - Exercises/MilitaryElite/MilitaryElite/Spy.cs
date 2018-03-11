using System;
using System.Text;

public class Spy : Soldier
{

    private int codeNumber;

    public Spy(string firstName, string lastName, string id, int codeNumber) 
        : base(firstName, lastName, id)
    {
        this.CodeNumber = codeNumber;
    }

    public int CodeNumber
    {
        get { return codeNumber; }
        private set { codeNumber = value; }
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder(base.ToString() + Environment.NewLine);
        builder.AppendLine($"Code Number: {this.CodeNumber}");

        string result = builder.ToString().TrimEnd();
        return result;
    }
}
