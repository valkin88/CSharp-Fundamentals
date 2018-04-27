namespace StorageMaster.Core
{
    using global::StorageMaster.Entities.Products;
    using global::StorageMaster.Entities.Storage;
    using global::StorageMaster.Entities.Vehicles;
    using global::StorageMaster.Factories;
    using global::StorageMaster.Constants;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StorageMaster
    {
        private IList<Product> products;
        private IList<Storage> storage;
        private ProductFactory productFactory;
        private StorageFactory storageFactory;
        private VehicleFactory vehicleFactory;
        private Vehicle currentVehicle;

        public StorageMaster()
        {
            this.products = new List<Product>();
            this.storage = new List<Storage>();
            this.productFactory = new ProductFactory();
            this.storageFactory = new StorageFactory();
            this.vehicleFactory = new VehicleFactory();
            this.currentVehicle = null;
        }

        public string AddProduct(string type, double price)
        {
            Product product = this.productFactory.CreateProduct(type, price);

            this.products.Add(product);

            return string.Format(Constants.AddProduct, type);
        }

        public string RegisterStorage(string type, string name)
        {
            Storage storage = this.storageFactory.CreateStorage(type, name);

            this.storage.Add(storage);

            return string.Format(Constants.RegisterStorage, name);
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            if (this.storage.Any(s => s.Name == storageName))
            {
                this.currentVehicle = this.storage.First(s => s.Name == storageName).GetVehicle(garageSlot);
            }

            string typeOfVehicle = this.currentVehicle.GetType().Name;

            return string.Format(Constants.SelectVehicle, typeOfVehicle);
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int loadedProductsCount = 0;

            foreach (var product in productNames)
            {
                if (this.products.Any(p => p.GetType().Name == product))
                {
                    if (this.currentVehicle.IsFull)
                    {
                        break;
                    }

                    Product currentProduct = this.products.Last(p => p.GetType().Name == product);
                    int indexOfProduct = this.products.IndexOf(this.products.Last(p => p.GetType().Name == product));
                    this.currentVehicle.LoadProduct(currentProduct);
                    this.products.RemoveAt(indexOfProduct);

                    loadedProductsCount++;
                }
                else
                {
                    throw new InvalidOperationException(string.Format(Constants.ProductOutOfStock, product));
                }
            }

            string typeOfCurrentVehicle = this.currentVehicle.GetType().Name;
            int countOfProductsToLoad = productNames.Count();

            return string.Format(Constants.LoadVehicle, loadedProductsCount, countOfProductsToLoad, typeOfCurrentVehicle);
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            if (!this.storage.Any(s => s.Name == sourceName))
            {
                throw new InvalidOperationException(Constants.InvalidSourceStorage);
            }

            if (!this.storage.Any(s => s.Name == destinationName))
            {
                throw new InvalidOperationException(Constants.InvalidDestinationStorage);
            }

            var vehicleToMove = this.storage.First(s => s.Name == sourceName).GetVehicle(sourceGarageSlot);
            int destinationGarageSlot = this.storage.First(s => s.Name == sourceName).SendVehicleTo(sourceGarageSlot, this.storage.First(s => s.Name == destinationName));
            string typeOfVehicle = vehicleToMove.GetType().Name;

            return string.Format(Constants.SendVehicleTo, typeOfVehicle, destinationName, destinationGarageSlot);
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            var unloadedVehicle = this.storage.FirstOrDefault(s => s.Name == storageName).GetVehicle(garageSlot);
            int productsInVehicle = unloadedVehicle.Trunk.Count;

            int unloadedProductsCount = this.storage.FirstOrDefault(s => s.Name == storageName).UnloadVehicle(garageSlot);
            
            var currentStorage = this.storage.FirstOrDefault(s => s.Name == storageName);

            return string.Format(Constants.UnloadVehicle, unloadedProductsCount, productsInVehicle, currentStorage.Name);
        }

        public string GetStorageStatus(string storageName)
        {
            var currentStorage = this.storage.FirstOrDefault(s => s.Name == storageName);

            return currentStorage.ToString();
        }

        public string GetSummary()
        {
            StringBuilder builder = new StringBuilder();

            var storageOutput = this.storage.OrderByDescending(p => p.Products.Sum(x => x.Price));

            foreach (var s in storageOutput)
            {
                builder.AppendLine(string.Format(Constants.NameOfStorage, s.Name));

                double sumOfProductsPrice = s.Products.Sum(x => x.Price);

                builder.AppendLine(string.Format(Constants.StorageWorth,sumOfProductsPrice));
            }

            return builder.ToString().Trim();
        }

    }
}
