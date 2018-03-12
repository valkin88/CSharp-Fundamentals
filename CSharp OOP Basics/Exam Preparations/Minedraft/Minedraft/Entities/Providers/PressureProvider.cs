using System;

public class PressureProvider : Provider
{
    public PressureProvider(string id, double energyOutput) : base(id, energyOutput)
    {
        base.EnergyOutput += base.EnergyOutput * 0.5;
        base.Type = "Pressure";
    }
}
