namespace StorageMaster.Entities.Storage
{
    using System.Collections.Generic;
    using StorageMaster.Entities.Vehicles;

    public class AutomatedWarehouse : Storage
    {
        private const int DefaultCapacity = 1;
        private const int DefaultGarageSlots = 2;
        private static IEnumerable<Vehicle> vehicles = new List<Vehicle> { new Truck() };

        public AutomatedWarehouse(string name) : base(name, DefaultCapacity, DefaultGarageSlots, vehicles)
        {
        }
    }
}
