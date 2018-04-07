namespace InfernoInfinity.Core.Commands
{
    using InfernoInfinity.Contracts;
    using InfernoInfinity.Core.Attributes;
    using System.Collections.Generic;
    using System.Linq;

    public class Add : Command
    {
        [Inject]
        private readonly List<IWeapon> createdWeapons;

        [Inject]
        private readonly IWeaponStorage weaponStorage;

        [Inject]
        private readonly IGemFactory gemFactory;

        public Add(string[] data) : base(data)
        {
        }

        public override void Execute()
        {
            string weaponName = this.Data[1];
            int socketIndex = int.Parse(this.Data[2]);
            string[] gemInfo = this.Data[3].Split(' ');
            string gemQuality = gemInfo[0];
            string gemType = gemInfo[1];

            IGem gem = this.gemFactory.CreateGem(gemType, gemQuality);

            IWeapon weapon = this.createdWeapons.FirstOrDefault(w => w.Name == weaponName);

            weapon.AddGem(gem, socketIndex);

            this.weaponStorage.Add(weapon);
        }
    }
}
