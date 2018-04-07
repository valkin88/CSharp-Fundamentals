namespace InfernoInfinity.Entities.Gems
{
    using InfernoInfinity.Entities.Enums;

    public class Ruby : Gem
    {
        public Ruby(GemQualityLevel gemQualityLevel) : base(gemQualityLevel)
        {
        }

        public override int StrengthBonus => 7 + (int)this.GemQualityLevel;

        public override int AgilityBonus => 2 + (int)this.GemQualityLevel;

        public override int VitalityBonus => 5 + (int)this.GemQualityLevel;
    }
}
