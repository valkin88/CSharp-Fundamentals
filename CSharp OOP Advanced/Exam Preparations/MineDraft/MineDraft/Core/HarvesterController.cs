using System;
using System.Collections.Generic;

public class HarvesterController : IHarvesterController
{
    private string mode;
    private readonly List<IHarvester> harvesters;
    private IEnergyRepository energyRepository;
    private IHarvesterFactory harvesterFactory;

    public HarvesterController(IEnergyRepository energyRepository, IHarvesterFactory harvesterFactory)
    {
        this.energyRepository = energyRepository;
        this.harvesterFactory = harvesterFactory;

        this.mode = Constants.DefaultMode;
        this.harvesters = new List<IHarvester>();
    }

    public double OreProduced { get; private set; }

    public IReadOnlyCollection<IEntity> Entities => (IReadOnlyCollection<IEntity>)this.harvesters;

    public string Register(IList<string> arguments)
    {
        var harvester = this.harvesterFactory.GenerateHarvester(arguments);
        this.harvesters.Add(harvester);

        return string.Format(Constants.SuccessfullRegistration,
            harvester.GetType().Name);
    }

    public string ChangeMode(string mode)
    {
        this.mode = mode;

        this.DecreaseDurabilityAfterChangeMode();

        return string.Format(Constants.ChangeMode, this.mode);
    }

    private void DecreaseDurabilityAfterChangeMode()
    {
        List<IHarvester> reminder = new List<IHarvester>();

        foreach (var harvester in this.harvesters)
        {
            try
            {
                harvester.Broke();
            }
            catch (Exception)
            {
                reminder.Add(harvester);
            }
        }

        RemoveBrokenHarvesters(reminder);
    }

    private void RemoveBrokenHarvesters(List<IHarvester> reminder)
    {
        foreach (var entity in reminder)
        {
            this.harvesters.Remove(entity);
        }
    }

    public string Produce()
    {
        double neededEnergy = GetEnergyNeeded();

        double minedOres = GetAllMinedOres(neededEnergy);

        if (this.mode == Constants.EnergyMode)
        {
            minedOres = minedOres * 20 / 100;
        }
        else if (this.mode == Constants.HalfMode)
        {
            minedOres = minedOres * 50 / 100;
        }

        this.OreProduced += minedOres;

        return string.Format(Constants.OreOutputToday, minedOres);
    }

    private double GetAllMinedOres(double neededEnergy)
    {
        double minedOres = 0;

        if (this.energyRepository.TakeEnergy(neededEnergy))
        {
            foreach (var harvester in this.harvesters)
            {
                minedOres += harvester.Produce();
            }
        }

        return minedOres;
    }

    private double GetEnergyNeeded()
    {
        double neededEnergy = 0;

        foreach (var harvester in this.harvesters)
        {
            if (this.mode == Constants.DefaultMode)
            {
                neededEnergy += harvester.EnergyRequirement;
            }
            else if (this.mode == Constants.HalfMode)
            {
                neededEnergy += harvester.EnergyRequirement * 50 / 100;
            }
            else if (this.mode == Constants.EnergyMode)
            {
                neededEnergy += harvester.EnergyRequirement * 20 / 100;
            }
        }

        return neededEnergy;
    }
}
