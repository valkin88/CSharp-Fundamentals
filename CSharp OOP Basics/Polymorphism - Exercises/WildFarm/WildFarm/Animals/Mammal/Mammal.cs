using System;

public abstract class Mammal : Animal
{
    private string livingRegion;

    public Mammal(string name, double weight, string livingRegion) 
        : base(name, weight)
    {
        this.LivingReagion = livingRegion;
    }

    public string LivingReagion
    {
        get { return livingRegion; }
        private set { livingRegion = value; }
    }
}
