namespace InfernoInfinity.Entities.Weapons
{
    using InfernoInfinity.Entities.Enums;

    public class Knife : Weapon
    {
        public Knife(string name, RarityLevel rarityLevel) : base(name, rarityLevel)
        {
        }

        protected override int NumberOfSockets => 2;

        protected override int MinDamage => 3 * (int)this.RarityLevel + (this.Strenght * 2) + (this.Agility * 1);

        protected override int MaxDamage => 4 * (int)this.RarityLevel + (this.Strenght * 3) + (this.Agility * 4);
    }
}
