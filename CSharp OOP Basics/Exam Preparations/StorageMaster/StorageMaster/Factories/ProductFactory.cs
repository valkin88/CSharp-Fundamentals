namespace StorageMaster.Factories
{
    using StorageMaster.Entities.Products;
    using StorageMaster.Constats;
    using System;

    public class ProductFactory
    {
        public Product CreateProduct(string typeOfProduct, double priceOfProduct)
        {
            switch (typeOfProduct)
            {
                case "Gpu":
                    return new Gpu(priceOfProduct);

                case "HardDrive":
                    return new HardDrive(priceOfProduct);

                case "Ram":
                    return new Ram(priceOfProduct);

                case "SolidStateDrive":
                    return new SolidStateDrive(priceOfProduct);

                default:
                    throw new InvalidOperationException(Constats.InvalidProductType);
            }
        }
    }
}
