namespace StorageMaster.Factories
{
    using StorageMaster.Entities.Storage;
    using StorageMaster.Constats;
    using System;

    public class StorageFactory
    {
        public Storage CreateStorage(string type, string name)
        {
            switch (type)
            {
                case "AutomatedWarehouse":
                    return new AutomatedWarehouse(name);
                case "DistributionCenter":
                    return new DistributionCenter(name);
                case "Warehouse":
                    return new Warehouse(name);
                default:
                    throw new InvalidOperationException(Constats.InvalidStorageType);
            }
        }
    }
}
