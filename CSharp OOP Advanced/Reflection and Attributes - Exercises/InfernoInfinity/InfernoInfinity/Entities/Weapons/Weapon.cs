namespace InfernoInfinity.Entities.Weapons
{
    using InfernoInfinity.Contracts;
    using InfernoInfinity.Entities.Enums;
    using InfernoInfinity.Entities.Gems;
    using System.Linq;

    public abstract class Weapon : IWeapon
    {
        protected Weapon(string name, RarityLevel rarityLevel)
        {
            
            this.RarityLevel = rarityLevel;
            this.Strenght = 0;
            this.Agility = 0;
            this.Vitality = 0;
            this.Gems = new Gem[NumberOfSockets];
            this.MinDamage = 0;
            this.MaxDamage = 0;
            this.Name = name;
        }

        protected RarityLevel RarityLevel { get; }

        protected int Strenght { get; private set; } 

        protected int Agility { get; private set; }

        protected int Vitality { get; private set; }

        protected IGem[] Gems { get; private set; }

        protected virtual int NumberOfSockets => 0;

        protected virtual int MinDamage { get; private set; }

        protected virtual int MaxDamage { get; private set; }

        public string Name { get; }

        public void AddGem(IGem gem, int socketIndex)
        {
            if (socketIndex >= 0 && socketIndex < this.NumberOfSockets)
            {
                this.Gems[socketIndex] = gem;
            }
        }

        public void Remove(int socketIndex)
        {
            if (socketIndex >= 0 && socketIndex < this.NumberOfSockets)
            {
                if (this.Gems[socketIndex] != null)
                {
                    this.Gems[socketIndex] = null;
                }
            }
        }

        public override string ToString()
        {
            GetStats();
            string result = $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{this.Strenght} Strength, +{this.Agility} Agility, +{this.Vitality} Vitality";

            return result;
        }

        private void GetStats()
        {
            int strenght = 0;
            int agility = 0;
            int vitality = 0;

            foreach (var gem in this.Gems.Where(g => g != null))
            {

                strenght += gem.StrengthBonus;
                agility += gem.AgilityBonus;
                vitality += gem.VitalityBonus;
            }

            this.Strenght = strenght;
            this.Agility = agility;
            this.Vitality = vitality;
        }
    }
}
