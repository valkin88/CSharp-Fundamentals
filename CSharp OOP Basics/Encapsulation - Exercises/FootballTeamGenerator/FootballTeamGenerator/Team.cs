using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    private string name;
    private List<Player> players;

    public string Name
    {
        get { return name; }
        private set
        {
            Validator.ValidateName(value);
            name = value;
        }
    }

    public List<Player> Players
    {
        get { return players; }
        private set { players = value; }
    }

    public Team(string name)
    {
        this.Name = name;
        this.Players = new List<Player>();
    }

    public int AverageRating
    {
        get
        {
            return (int)(Math.Round(this.Players.Sum(x => x.AverageStats) / this.Players.Count));
        }
    }

    public void AddPlayer(string name, double endurance, double sprint, double dribble, double passing, double shooting)
    {
        Stats stats = new Stats(endurance, sprint, dribble, passing, shooting);
        Player player = new Player(name, stats);
        this.Players.Add(player);
    }

    public void RemovePlayer(Player player)
    {
        this.Players.Remove(player);
    }
}
