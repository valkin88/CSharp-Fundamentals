namespace InfernoInfinity.Core.Factories
{
    using InfernoInfinity.Contracts;
    using InfernoInfinity.Entities.Enums;
    using System;
    using System.Linq;
    using System.Reflection;

    public class WeaponFactory : IWeaponFactory
    {
        public IWeapon CreateWeapon(string[] data)
        {
            string[] weaponInfo = data[1].Split(' ');
            string weaponLevel = weaponInfo[0];
            string weaponType = weaponInfo[1];
            string weaponName = data[2];

            Type typeOfWeapon = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == weaponType);

            var rarityLevel = (RarityLevel)Enum.Parse(typeof(RarityLevel), weaponLevel);

            object[] weaponParams = new object[] { weaponName, rarityLevel };

            var weapon = (IWeapon)Activator.CreateInstance(typeOfWeapon, weaponParams);

            return weapon;
        }
    }
}
