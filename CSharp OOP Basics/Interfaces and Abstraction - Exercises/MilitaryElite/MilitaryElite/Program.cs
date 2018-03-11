using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Private> privates = new List<Private>();
        string input;

        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputSoldiers = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            GetType(privates, inputSoldiers);
        }
    }

    private static void GetType(List<Private> privates, string[] inputSoldiers)
    {
        switch (inputSoldiers[0])
        {
            case "Private":
                if (inputSoldiers.Length == 5)
                {
                    WorkWithPrivate(privates, inputSoldiers);
                }
                break;
            case "LeutenantGeneral":
                if (inputSoldiers.Length >= 5)
                {
                    WorkWithLeutenantGeneral(privates, inputSoldiers);
                }
                break;
            case "Engineer":
                if (inputSoldiers.Length >= 6)
                {
                    WorkWithEngineer(inputSoldiers);
                }
                break;
            case "Commando":
                if (inputSoldiers.Length >= 6)
                {
                    WorkWithCommando(inputSoldiers);
                }
                break;
            case "Spy":
                if (inputSoldiers.Length == 5)
                {
                    WorkWithSpy(inputSoldiers);
                }
                break;
            default:
                break;
        }
    }

    private static void WorkWithPrivate(List<Private> privates, string[] inputSoldiers)
    {
        Private privateSoldier = new Private(inputSoldiers[2], inputSoldiers[3], inputSoldiers[1], double.Parse(inputSoldiers[4]));

        privates.Add(privateSoldier);

        Console.WriteLine(privateSoldier);
    }

    private static void WorkWithLeutenantGeneral(List<Private> privates, string[] inputSoldiers)
    {
        List<Private> privateByIds = AddPrivates(privates, inputSoldiers);

        LeutenantGeneral leutenantGeneral = new LeutenantGeneral(inputSoldiers[2], inputSoldiers[3], inputSoldiers[1], double.Parse(inputSoldiers[4]), privateByIds);

        Console.WriteLine(leutenantGeneral);
    }

    private static void WorkWithEngineer(string[] inputSoldiers)
    {
        if (inputSoldiers[5] == "Airforces" || inputSoldiers[5] == "Marines")
        {
            List<Repair> repairs = AddRepairs(inputSoldiers);

            Engineer engineer = new Engineer(inputSoldiers[2], inputSoldiers[3], inputSoldiers[1], double.Parse(inputSoldiers[4]), inputSoldiers[5], repairs);

            Console.WriteLine(engineer);
        }
    }

    private static void WorkWithCommando(string[] inputSoldiers)
    {
        List<Mission> missions = AddMissions(inputSoldiers);

        Commando commando = new Commando(inputSoldiers[2], inputSoldiers[3], inputSoldiers[1], double.Parse(inputSoldiers[4]), inputSoldiers[5], missions);

        Console.WriteLine(commando);
    }

    private static void WorkWithSpy(string[] inputSoldiers)
    {
        Spy spy = new Spy(inputSoldiers[2], inputSoldiers[3], inputSoldiers[1], int.Parse(inputSoldiers[4]));

        Console.WriteLine(spy);
    }

    private static List<Mission> AddMissions(string[] inputSoldiers)
    {
        List<Mission> missions = new List<Mission>();
        if (inputSoldiers.Length >= 8)
        {
            for (int i = 6; i < inputSoldiers.Length; i += 2)
            {
                if (inputSoldiers[i + 1] == "inProgress" || inputSoldiers[i + 1] == "Finished")
                {
                    missions.Add(new Mission(inputSoldiers[i], inputSoldiers[i + 1]));
                }
            }
        }

        return missions;
    }

    private static List<Repair> AddRepairs(string[] inputSoldiers)
    {
        List<Repair> repairs = new List<Repair>();
        if (inputSoldiers.Length >= 8)
        {
            for (int i = 6; i < inputSoldiers.Length; i += 2)
            {
                repairs.Add(new Repair(inputSoldiers[i], int.Parse(inputSoldiers[i + 1])));

            }
        }

        return repairs;
    }

    private static List<Private> AddPrivates(List<Private> privates, string[] inputSoldiers)
    {
        List<Private> privateByIds = new List<Private>();
        for (int i = 5; i < inputSoldiers.Length; i++)
        {
            if (privates.Any(x => x.Id == inputSoldiers[i]))
            {
                privateByIds.Add(privates.First(x => x.Id == inputSoldiers[i]));
            }
        }

        return privateByIds;
    }
}
