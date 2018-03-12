using System;

public abstract class Provider
{
    private string id;
    private double energyOutput;

    protected Provider(string id, double energyOutput)
    {
        this.Id = id;
        this.EnergyOutput = energyOutput;
    }

    public string Type { get; set; }

    public string Id
    {
        get { return id; }
        private set
        {
            id = value;
        }
    }

    public double EnergyOutput
    {
        get { return energyOutput; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Provider is not registered, because of it's EnergyOutput");
            }
            if (value > 10000)
            {
                throw new ArgumentException("Provider is not registered, because of it's EnergyOutput");
            }
            energyOutput = value;
        }
    }


}
