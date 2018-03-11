using System;
using System.Collections.Generic;
using System.Text;

public class Commando : Private
{
    private string typeOfCorps;
    private List<Mission> missions;

    public Commando(string firstName, string lastName, string id, double salary, string typeOfCorps, List<Mission> missions) : base(firstName, lastName, id, salary)
    {
        this.TypeOfCorps = typeOfCorps;
        this.Missions = missions;
    }

    public string TypeOfCorps
    {
        get { return typeOfCorps; }
        private set { typeOfCorps = value; }
    }

    public List<Mission> Missions
    {
        get { return missions; }
        private set { missions = value; }
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder(base.ToString() + Environment.NewLine);
        builder.AppendLine($"Corps: {this.TypeOfCorps}");
        builder.AppendLine("Missions:");

        foreach (var mission in this.Missions)
        {
            builder.AppendLine($"Code Name: {mission.CodeName} State: {mission.State}");
        }

        string result = builder.ToString().TrimEnd();
        return result;
    }
}
