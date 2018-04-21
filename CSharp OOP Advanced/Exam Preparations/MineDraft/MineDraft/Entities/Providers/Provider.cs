using System;

public class Provider : IProvider
{
    private double durability;

    protected Provider(int id, double energyOutput)
    {
        this.Durability = Constants.InitialDurability;
        this.ID = id;
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput { get; protected set; }

    public int ID { get; }

    public double Durability
    {
        get
        {
            return this.durability;
        }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException(string.Format(Constants.BrokenEntity,
                    this.GetType().Name, this.ID));
            }

            this.durability = value;
        }
    }

    public void Broke()
    {
        this.Durability -= Constants.DurabilityDecreaser;
    }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Repair(double val)
    {
        this.Durability += val;
    }
}