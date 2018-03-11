using System;
using System.Collections.Generic;
using System.Text;

public class Player
{
    private string name;
    private Stats stats;

    public string Name
    {
        get { return name; }
        set
        {
            Validator.ValidateName(value);
            name = value;
        }
    }

    public Stats Stats
    {
        get { return stats; }
        private set { stats = value; }
    }

    public double AverageStats
    {
        get
        {
            return (stats.Dribble + stats.Endurance + stats.Passing + stats.Shooting + stats.Sprint) / 5.0;
        }
    }

    public Player(string name, Stats stats)
    {
        this.Name = name;
        this.Stats = stats;
    }
}
