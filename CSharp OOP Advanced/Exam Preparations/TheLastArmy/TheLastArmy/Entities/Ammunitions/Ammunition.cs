public abstract class Ammunition : IAmmunition
{
    private const int wearLevelMultiplier = 100;

    public Ammunition()
    {
        WearLevel = Weight * wearLevelMultiplier;
    }

    public string Name => this.GetType().Name;

    public abstract double Weight { get; }

    public double WearLevel { get; private set; }

    public void DecreaseWearLevel(double wearAmount)
    {
        WearLevel -= wearAmount;
    }
}
