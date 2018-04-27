namespace StorageMaster.Entities.Storage
{
    using StorageMaster.Entities.Products;
    using StorageMaster.Entities.Vehicles;
    using StorageMaster.Constants;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Storage
    {
        private readonly Vehicle[] arrayOfVehicles;
        private readonly IList<Product> listOfProducts;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;

            this.arrayOfVehicles = new Vehicle[this.GarageSlots];
            this.AddVehicleToGarage(vehicles);

            this.listOfProducts = new List<Product>();
        }

        public string Name { get; }

        public int Capacity { get; }

        public int GarageSlots { get; }

        public IReadOnlyCollection<Vehicle> Garage => this.arrayOfVehicles;

        public IReadOnlyCollection<Product> Products => (IReadOnlyCollection<Product>)this.listOfProducts;

        public bool IsFull => this.listOfProducts.Sum(p => p.Weight) >= this.Capacity;

        private void AddVehicleToGarage(IEnumerable<Vehicle> vehicles)
        {
            int counter = 0;

            foreach (var vehicle in vehicles)
            {
                this.arrayOfVehicles[counter] = vehicle;
                counter++;
            }

        }

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException(Constants.InvalidGarageSlot);
            }

            if (this.arrayOfVehicles[garageSlot] == null)
            {
                throw new InvalidOperationException(Constants.NoVehicleFound);
            }

            Vehicle vehicle = this.arrayOfVehicles[garageSlot];

            return vehicle;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicle = this.GetVehicle(garageSlot);

            int slotIndex = this.AddVehicle(deliveryLocation, vehicle);

            this.arrayOfVehicles[garageSlot] = null;

            return slotIndex;
        }

        private int AddVehicle(Storage deliveryLocation, Vehicle vehicle)
        {
            int countOfSlots = deliveryLocation.arrayOfVehicles.Length;
            bool isItFull = true;
            int indexOfSlot = 0;

            for (int i = 0; i < countOfSlots; i++)
            {
                if (deliveryLocation.arrayOfVehicles[i] == null)
                {
                    deliveryLocation.arrayOfVehicles[i] = vehicle;
                    isItFull = false;
                    indexOfSlot = i;
                    break;
                }
            }

            if (isItFull == true)
            {
                throw new InvalidOperationException(Constants.NoRoomInGarage);
            }

            return indexOfSlot;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException(Constants.StorageIsFull);
            }

            Vehicle vehicle = this.GetVehicle(garageSlot);

            int countOfProducts = this.UnloadProducts(vehicle);

            return countOfProducts;
        }

        private int UnloadProducts(Vehicle vehicle)
        {
            int countOfProducts = 0;

            while (true)
            {
                if (vehicle.IsEmpty)
                {
                    break;
                }

                if (this.IsFull)
                {
                    break;
                }

                Product product = vehicle.Unload();

                this.listOfProducts.Add(product);

                countOfProducts++;
            }

            return countOfProducts;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            Dictionary<string, int> sortedProducts = AddProductsToDictionary();

            double sumOfProductsWeight = this.listOfProducts.Sum(p => p.Weight);

            AppendFirstPartOfOutput(builder, sortedProducts, sumOfProductsWeight);
            AppendSecondPartOfOutput(builder);

            return builder.ToString().Trim();
        }

        private void AppendSecondPartOfOutput(StringBuilder builder)
        {
            builder.Append("Garage: [");

            foreach (var vehicle in this.arrayOfVehicles)
            {
                if (vehicle != null)
                {
                    builder.Append($"{vehicle.GetType().Name}|");
                }
                else
                {
                    builder.Append($"empty|");
                }
            }
            builder.Remove(builder.Length - 1, 1);
            builder.AppendLine("]");
        }

        private void AppendFirstPartOfOutput(StringBuilder builder, Dictionary<string, int> sortedProducts, double sumOfProductsWeight)
        {
            builder.Append($"Stock ({sumOfProductsWeight}/{this.Capacity}): [");

            bool isEmpty = true;

            foreach (var product in sortedProducts.OrderByDescending(p => p.Value).ThenBy(p => p.Key))
            {
                builder.Append($"{product.Key} ({product.Value}), ");
                isEmpty = false;
            }

            if (!isEmpty)
            {
                builder.Remove(builder.Length - 2, 2);
            }

            builder.AppendLine("]");
        }

        private Dictionary<string, int> AddProductsToDictionary()
        {
            Dictionary<string, int> sortedProducts = new Dictionary<string, int>();

            foreach (var product in this.listOfProducts)
            {
                if (!sortedProducts.ContainsKey(product.GetType().Name.ToString()))
                {
                    sortedProducts.Add(product.GetType().Name.ToString(), 1);
                }
                else
                {
                    sortedProducts[product.GetType().Name.ToString()]++;
                }
            }

            return sortedProducts;
        }
    }
}
