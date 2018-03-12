using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private Dictionary<string, Harvester> harvesters;
    private Dictionary<string, Provider> providers;

    private double harvesterEnergyMultiplier;
    private double harvesterOreMultiplier;

    private double totalEnergyStored;
    private double totalMinedOre;

    public DraftManager()
    {
        this.harvesters = new Dictionary<string, Harvester>();
        this.providers = new Dictionary<string, Provider>();
        this.harvesterEnergyMultiplier = 1;
        this.harvesterOreMultiplier = 1;
        this.totalEnergyStored = 0;
        this.totalMinedOre = 0;
    }

    public string RegisterHarvester(List<string> arguments)
    {

        string msg = String.Empty;

        try
        {
            string type = arguments[0];
            string id = arguments[1];
            double oreOutput = double.Parse(arguments[2]);
            double energyRequirement = double.Parse(arguments[3]);

            Harvester harvester;
            if (type == "Sonic")
            {
                int sonicFactor = int.Parse(arguments[4]);
                harvester = new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
                harvesters.Add(id, harvester);
            }
            else if (type == "Hammer")
            {
                harvester = new HammerHarvester(id, oreOutput, energyRequirement);
                harvesters.Add(id, harvester);
            }

            msg = $"Successfully registered {type} Harvester - {id}";
        }
        catch (ArgumentException ex)
        {
            msg = ex.Message;
        }
        

        return msg;
    }

    public string RegisterProvider(List<string> arguments)
    {
        string msg = String.Empty;

        try
        {
            string type = arguments[0];
            string id = arguments[1];
            double energyOutput = double.Parse(arguments[2]);


            Provider provider;
            if (type == "Solar")
            {
                provider = new SolarProvider(id, energyOutput);
                providers.Add(id, provider);
            }
            else if (type == "Pressure")
            {
                provider = new PressureProvider(id, energyOutput);
                providers.Add(id, provider);
            }

            msg = $"Successfully registered {type} Provider - {id}";
        }
        catch (ArgumentException ex)
        {
            msg = ex.Message;
        }
        

        return msg;
    }

    public string Day()
    {
        StringBuilder sb = new StringBuilder();
        double summedEnergyOutput = providers.Sum(x => x.Value.EnergyOutput);
        this.totalEnergyStored += summedEnergyOutput;
        double totalHarvesterEnergyPerDay = (harvesters.Sum(x => x.Value.EnergyRequirement)) * this.harvesterEnergyMultiplier;
        double summedOreOutput = 0;

        if (this.totalEnergyStored >= totalHarvesterEnergyPerDay)
        {
            this.totalEnergyStored -= totalHarvesterEnergyPerDay;
            summedOreOutput = (harvesters.Sum(x => x.Value.OreOutput)) * this.harvesterOreMultiplier;
            this.totalMinedOre += summedOreOutput;
        }


        sb.AppendLine($"A day has passed.");
        sb.AppendLine($"Energy Provided: {summedEnergyOutput}");
        sb.AppendLine($"Plumbus Ore Mined: {summedOreOutput}");

        return sb.ToString().Trim();
    }

    public string Mode(List<string> arguments)
    {
        var mode = arguments[0];

        if (mode == "Full")
        {
            this.harvesterEnergyMultiplier = 1;
            this.harvesterOreMultiplier = 1;
        }
        else if (mode == "Half")
        {
            this.harvesterEnergyMultiplier = 0.6;
            this.harvesterOreMultiplier = 0.5;
        }
        else if (mode == "Energy")
        {
            this.harvesterEnergyMultiplier = 0;
            this.harvesterOreMultiplier = 0;
        }

        return $"Successfully changed working mode to {mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];
        StringBuilder sb = new StringBuilder();

        if (providers.Any(x => x.Key == id))
        {
            sb.AppendLine($"{providers[id].Type} Provider - {id}");
            sb.AppendLine($"Energy Output: {providers[id].EnergyOutput}");
        }
        else if (harvesters.Any(x => x.Key == id))
        {
            sb.AppendLine($"{harvesters[id].Type} Harvester - {id}");
            sb.AppendLine($"Ore Output: {harvesters[id].OreOutput}");
            sb.AppendLine($"Energy Requirement: {harvesters[id].EnergyRequirement}");
        }
        else
        {
            sb.AppendLine($"No element found with id - {id}");
        }

        return sb.ToString().Trim();
    }

    public string ShutDown()
    {

        StringBuilder sb = new StringBuilder();

        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Stored: {totalEnergyStored}");
        sb.AppendLine($"Total Mined Plumbus Ore: {totalMinedOre}");

        return sb.ToString().Trim();
    }

}
