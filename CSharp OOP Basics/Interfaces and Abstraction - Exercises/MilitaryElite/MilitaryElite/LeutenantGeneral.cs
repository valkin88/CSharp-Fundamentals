using System;
using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Private
{
    private List<Private> privates;

    public LeutenantGeneral(string firstName, string lastName, string id, double salary, List<Private> privates)
        : base(firstName, lastName, id, salary)
    {
        this.Privates = privates;
    }

    public List<Private> Privates
    {
        get { return privates; }
        private set { privates = value; }
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder(base.ToString() + Environment.NewLine);
        builder.Append("Privates:" + Environment.NewLine);

        foreach (var privateSoldier in this.Privates)
        {
            builder.AppendLine($"Name: {privateSoldier.FirstName} {privateSoldier.LastName} Id: {privateSoldier.Id} Salary: {privateSoldier.Salary:f2}");
        }

        string result = builder.ToString().TrimEnd();
        return result;
    }
}
