namespace InfernoInfinity.Contracts
{
    public interface IWeapon
    {
        string Name { get; }

        void AddGem(IGem gem, int socketIndex);

        void Remove(int socketIndex);
    }
}
