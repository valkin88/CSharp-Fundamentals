namespace InfernoInfinity.Entities.Gems
{
    using InfernoInfinity.Entities.Enums;

    public class Emerald : Gem
    {
        public Emerald(GemQualityLevel gemQualityLevel) : base(gemQualityLevel)
        {
        }

        public override int StrengthBonus => 1 + (int)this.GemQualityLevel;

        public override int AgilityBonus => 4 + (int)this.GemQualityLevel;

        public override int VitalityBonus => 9 + (int)this.GemQualityLevel;
    }
}
