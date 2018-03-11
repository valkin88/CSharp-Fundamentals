using System;
using System.Collections.Generic;
using System.Text;

public class Engineer : Private
{
    private string typeOfCorps;
    private List<Repair> repairs;

    public Engineer(string firstName, string lastName, string id, double salary, string typeOfCorps, List<Repair> repairs) 
        : base(firstName, lastName, id, salary)
    {
        this.TypeOfCorps = typeOfCorps;
        this.Repairs = repairs;
    }

    public string TypeOfCorps
    {
        get { return typeOfCorps; }
        private set { typeOfCorps = value; }
    }

    public List<Repair> Repairs
    {
        get { return repairs; }
        private set { repairs = value; }
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder(base.ToString() + Environment.NewLine);
        builder.AppendLine($"Corps: {this.TypeOfCorps}");

        builder.Append("Repairs:" + Environment.NewLine);
        foreach (var repair in this.Repairs)
        {
            builder.AppendLine($"Part Name: {repair.NameOfPart} Hours Worked: {repair.HoursWorked}");
        }

        string result = builder.ToString().TrimEnd();
        return result;
    }
}
