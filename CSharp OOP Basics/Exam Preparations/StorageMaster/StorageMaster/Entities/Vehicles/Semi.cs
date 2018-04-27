namespace StorageMaster.Entities.Vehicles
{
    public class Semi : Vehicle
    {
        private const int DefaultCapacity = 5;

        public Semi() : base(DefaultCapacity)
        {
        }
    }
}
