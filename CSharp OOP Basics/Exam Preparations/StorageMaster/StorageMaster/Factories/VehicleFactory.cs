namespace StorageMaster.Factories
{
    using StorageMaster.Entities.Vehicles;
    using StorageMaster.Constants;
    using System;

    public class VehicleFactory
    {
        public Vehicle CreateVehicle(string type)
        {
            switch (type)
            {
                case "Semi":
                    return new Semi();
                case "Truck":
                    return new Truck();
                case "Van":
                    return new Van();
                default:
                    throw new InvalidOperationException(Constants.InvalidVehicleType);
            }
        }
    }
}
