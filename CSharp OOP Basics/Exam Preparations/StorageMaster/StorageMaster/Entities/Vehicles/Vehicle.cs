namespace StorageMaster.Entities.Vehicles
{
    using StorageMaster.Entities.Products;
    using StorageMaster.Constats;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Vehicle
    {
        private readonly IList<Product> listOfProducts;

        protected Vehicle(int capacity)
        {
            this.Capacity = capacity;
            this.listOfProducts = new List<Product>();
        }

        public int Capacity { get; }

        public IReadOnlyCollection<Product> Trunk => (IReadOnlyCollection<Product>)this.listOfProducts;

        public bool IsFull => this.listOfProducts.Sum(p => p.Weight) >= this.Capacity;

        public bool IsEmpty => this.listOfProducts.Count == 0;

        public void LoadProduct(Product product)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException(Constats.VehicleIsFull);
            }

            this.listOfProducts.Add(product);
        }

        public Product Unload()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException(Constats.NoProductsInVehicle);
            }

            Product product = this.listOfProducts.Last();

            this.listOfProducts.Remove(product);

            return product;
        }
    }
}
