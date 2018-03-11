using System;
using System.Text;

public class Private : Soldier
{
    private double salary;

    public Private(string firstName, string lastName, string id, double salary)
        : base(firstName, lastName, id)
    {
        this.Salary = salary;
    }

    public double Salary
    {
        get { return salary; }
        private set { salary = value; }
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder(base.ToString());
        builder.AppendLine($" Salary: {this.Salary:f2}");

        string result = builder.ToString().TrimEnd();
        return result;
    }
}
