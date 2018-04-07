namespace InfernoInfinity.Core
{
    using System.Collections.Generic;
    using InfernoInfinity.Contracts;
    using System.Linq;

    public class WeaponStorage : IWeaponStorage
    {
        private IList<IWeapon> weaponStorage;

        public WeaponStorage()
        {
            this.weaponStorage = new List<IWeapon>();
        }

        public void Add(IWeapon weapon) => weaponStorage.Add((IWeapon)weapon);

        public bool Remove(string weaponName, int socketIndex)
        {
            if (this.weaponStorage.Any(w => w.Name == weaponName))
            {
                IWeapon weapon = this.weaponStorage.First(w => w.Name == weaponName);

                weapon.Remove(socketIndex);

                return true;
            }
            return false;
        }

        public string Print(string weaponName)
        {
            IWeapon weapon = null;
            string result = "";

            if (this.weaponStorage.Any(w => w.Name == weaponName))
            {
                weapon = this.weaponStorage.First(w => w.Name == weaponName);
                result = weapon.ToString();
            }

            return result;
        }
    }
}