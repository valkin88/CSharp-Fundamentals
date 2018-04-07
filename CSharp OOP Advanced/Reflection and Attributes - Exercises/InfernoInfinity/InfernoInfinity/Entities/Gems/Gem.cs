namespace InfernoInfinity.Entities.Gems
{
    using InfernoInfinity.Contracts;
    using InfernoInfinity.Entities.Enums;

    public abstract class Gem : IGem
    {
        protected Gem(GemQualityLevel gemQualityLevel)
        {
            this.GemQualityLevel = gemQualityLevel;
            this.StrengthBonus = 0;
            this.AgilityBonus = 0;
            this.VitalityBonus = 0;
        }

        protected GemQualityLevel GemQualityLevel { get; }

        public virtual int StrengthBonus { get; private set; }

        public virtual int AgilityBonus { get; private set; }

        public virtual int VitalityBonus { get; private set; }
    }
}
