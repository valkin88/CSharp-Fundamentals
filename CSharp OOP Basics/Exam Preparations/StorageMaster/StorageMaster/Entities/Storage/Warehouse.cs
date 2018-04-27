namespace StorageMaster.Entities.Storage
{
    using System.Collections.Generic;
    using StorageMaster.Entities.Vehicles;

    public class Warehouse : Storage
    {
        private const int DefaultCapacity = 10;
        private const int DefaultGarageSlots = 10;
        private static IEnumerable<Vehicle> vehicles = new List<Vehicle> { new Semi(), new Semi(), new Semi() };

        public Warehouse(string name) : base(name, DefaultCapacity, DefaultGarageSlots, vehicles)
        {
        }
    }
}
