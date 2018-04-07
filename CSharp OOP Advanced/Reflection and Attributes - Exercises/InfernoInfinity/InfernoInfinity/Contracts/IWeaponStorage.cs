namespace InfernoInfinity.Core
{
    using InfernoInfinity.Contracts;

    public interface IWeaponStorage
    {
        void Add(IWeapon weapon);

        bool Remove(string weaponName, int socketIndex);

        string Print(string weaponName);
    }
}