namespace InfernoInfinity.Entities.Gems
{
    using InfernoInfinity.Entities.Enums;

    public class Amethyst : Gem
    {
        public Amethyst(GemQualityLevel gemQualityLevel) : base(gemQualityLevel)
        {
        }

        public override int StrengthBonus => 2 + (int)this.GemQualityLevel;

        public override int AgilityBonus => 8 + (int)this.GemQualityLevel;

        public override int VitalityBonus => 4 + (int)this.GemQualityLevel;
    }
}
