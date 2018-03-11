using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        
        List<Team> teams = new List<Team>();

        var input = Console.ReadLine();

        while (input != "END")
        {
            var inputLine = input.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            switch (inputLine[0])
            {
                case "Team": CreateTeam(teams, inputLine); break;
                case "Add": AddPlayer(teams, inputLine); break;
                case "Remove": RemovePlayer(teams, inputLine); break;
                case "Rating": PrintRating(teams, inputLine); break;
                default:
                    break;
            }

            input = Console.ReadLine();

        }
    }

    private static void PrintRating(List<Team> teams, string[] inputLine)
    {
        if (teams.Any(x => x.Name == inputLine[1]))
        {
            Team team = teams.First(x => x.Name == inputLine[1]);
            if (team.Players.Count == 0)
            {
                Console.WriteLine($"{team.Name} - 0");
            }
            else
            {
                Console.WriteLine($"{team.Name} - {team.AverageRating}");
            }

        }
        else
        {
            Console.WriteLine($"Team {inputLine[1]} does not exist.");
        }
    }

    private static void RemovePlayer(List<Team> teams, string[] inputLine)
    {
        if (teams.Any(x => x.Players.Any(c => c.Name == inputLine[2])))
        {
            Team team = teams.First(x => x.Name == inputLine[1]);
            Player player = team.Players.First(x => x.Name == inputLine[2]);
            team.RemovePlayer(player);
            teams.Remove(teams.First(x => x.Name == inputLine[1]));
            teams.Add(team);
        }
        else
        {
            Console.WriteLine($"Player {inputLine[2]} is not in {inputLine[1]} team.");
        }
    }

    private static void AddPlayer(List<Team> teams, string[] inputLine)
    {
        if (teams.Any(x => x.Name == inputLine[1]))
        {
            Team team = teams.First(x => x.Name == inputLine[1]);
            try
            {
                team.AddPlayer(inputLine[2], double.Parse(inputLine[3]), double.Parse(inputLine[4]), double.Parse(inputLine[5]), double.Parse(inputLine[6]), double.Parse(inputLine[7]));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            teams.Remove(teams.First(x => x.Name == inputLine[1]));
            teams.Add(team);
        }
        else
        {
            Console.WriteLine($"Team {inputLine[1]} does not exist.");
        }
    }

    private static void CreateTeam(List<Team> teams, string[] inputLine)
    {
        if (inputLine.Length > 1)
        {
            string teamName = inputLine[1];
            Team team = new Team(teamName);
            teams.Add(team);
        }
        else
        {
            throw new ArgumentException("A name should not be empty.");
        }
    }
}
