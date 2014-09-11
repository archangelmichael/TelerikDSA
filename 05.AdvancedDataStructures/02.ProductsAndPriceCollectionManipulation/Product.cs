namespace _02.ProductsAndPriceCollectionManipulation
{
    using System;

    public class Product : IComparable<Product>
    {
        private string name;
        private int price;

        public Product(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name 
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Product name cannot be null!");
                }

                this.name = value;
            }
        }

        public int Price 
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("Price cannot be negative!");
                }

                this.price = value;
            }
        }

        public int CompareTo(Product other)
        {
            return this.price.CompareTo(other.price);
        }
    }
}
