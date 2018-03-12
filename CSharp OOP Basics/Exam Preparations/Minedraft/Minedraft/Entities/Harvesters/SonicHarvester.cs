using System;

public class SonicHarvester : Harvester
{
    private int sonicFactor;

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor) : base(id, oreOutput, energyRequirement)
    {
        this.SonicFactor = sonicFactor;
        base.EnergyRequirement /= this.SonicFactor;
        base.Type = "Sonic";
    }

    public int SonicFactor
    {
        get { return sonicFactor; }
        private set
        {
            if (value >= 1 && value <= 10)
            {
                sonicFactor = value; 
            }
            else
            {
                throw new ArgumentException("Harvester is not registered, because of it's SonicFactor");
            }
            
        }
    }

}
