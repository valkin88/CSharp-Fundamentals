namespace InfernoInfinity.Entities.Weapons
{
    using InfernoInfinity.Entities.Enums;

    public class Axe : Weapon
    {
        public Axe(string name, RarityLevel rarityLevel) : base(name, rarityLevel)
        {
        }

        protected override int NumberOfSockets => 4;

        protected override int MinDamage => 5 * (int)this.RarityLevel + (this.Strenght * 2) + (this.Agility * 1);

        protected override int MaxDamage => 10 * (int)this.RarityLevel + (this.Strenght * 3) + (this.Agility * 4);
    }
}
