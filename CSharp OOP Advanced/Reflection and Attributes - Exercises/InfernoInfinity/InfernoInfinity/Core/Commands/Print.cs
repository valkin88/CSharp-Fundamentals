namespace InfernoInfinity.Core.Commands
{
    using InfernoInfinity.Contracts;
    using InfernoInfinity.Core.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Print : Command
    {
        [Inject]
        private readonly IWeaponStorage weaponStorage;

        [Inject]
        private readonly List<IWeapon> createdWeapons;

        public Print(string[] data) : base(data)
        {
        }

        public override void Execute()
        {
            string weaponName = this.Data[1];

            string result = this.weaponStorage.Print(weaponName);

            if (result == "" && this.createdWeapons.Any(w => w.Name == weaponName))
            {
                IWeapon weapon = this.createdWeapons.First(w => w.Name == weaponName);
                result = weapon.ToString();
            }

            if (result != "")
            {
                Console.WriteLine(result);
            }
        }
    }
}
