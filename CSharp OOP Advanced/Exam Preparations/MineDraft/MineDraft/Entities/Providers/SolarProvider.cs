public class SolarProvider : Provider
{
    private const int DurabilityIncreser = 500;

    public SolarProvider(int id, double energyOutput) : base(id, energyOutput)
    {
        this.Durability += DurabilityIncreser;
    }
}