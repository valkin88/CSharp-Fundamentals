﻿namespace StorageMaster.Entities.Products
{
    using System;
    using StorageMaster.Constants;

    public abstract class Product
    {
        private double price;

        protected Product(double price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }

        public double Price
        {
            get { return price; }
            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException(Constants.PriceCannotBeNegative);
                }
                price = value;
            }
        }

        public double Weight { get; }

    }
}
