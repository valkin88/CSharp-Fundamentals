namespace InfernoInfinity.Entities.Weapons
{
    using InfernoInfinity.Entities.Enums;

    public class Sword : Weapon
    {
        public Sword(string name, RarityLevel rarityLevel) : base(name, rarityLevel)
        {
        }

        protected override int NumberOfSockets => 3;

        protected override int MinDamage => (4 * (int)this.RarityLevel) + (this.Strenght * 2) + (this.Agility * 1);

        protected override int MaxDamage => 6 * (int)this.RarityLevel + (this.Strenght * 3) + (this.Agility * 4);
    }
}
