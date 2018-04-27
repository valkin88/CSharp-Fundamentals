namespace StorageMaster.Entities.Storage
{
    using System.Collections.Generic;
    using StorageMaster.Entities.Vehicles;

    public class DistributionCenter : Storage
    {
        private const int DefaultCapacity = 2;
        private const int DefaultGarageSlots = 5;
        private static IEnumerable<Vehicle> vehicles = new List<Vehicle> { new Van(), new Van(), new Van() };

        public DistributionCenter(string name) : base(name, DefaultCapacity, DefaultGarageSlots, vehicles)
        {
        }
    }
}
