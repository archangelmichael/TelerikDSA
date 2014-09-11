namespace _02.ProductsAndPriceCollectionManipulation
{
    using System;
    using System.Diagnostics;
    using Wintellect.PowerCollections;

    /*
     * Write a program to read a large collection of products (name + price) 
     * and efficiently find the first 20 products in the price range [a…b]. 
     * Test for 500 000 products and 10 000 price searches.
     * Hint: you may use OrderedBag<T> and sub-ranges.
    */
    public class Program
    {
        private const int ProductsCount = 500000;
        private const int PriceTopCheck = 350000;
        private const int PriceBotCheck = 150000;
        private const int FoundProductsCount = 20;
        private const int NumberOfSearches = 10000;
        private static Product[] arrayOfProducts;
        private static Random generator = new Random();

        public static void Main()
        {
            arrayOfProducts = GetRandomProducts();
            SearchProductsInRange();
        }

        private static void SearchProductsInRange()
        {
            var bag = new OrderedBag<Product>();
            var watch = new Stopwatch();
            watch.Start();
            foreach (var item in arrayOfProducts)
            {
                bag.Add(item);
            }

            Console.WriteLine("Adding Products: {0}", watch.Elapsed);
            watch.Restart();
            var bottom = new Product("bottom", PriceBotCheck);
            var top = new Product("top", PriceTopCheck);
            for (int i = 0; i < NumberOfSearches; i++)
            {
                for (int j = 0; j < FoundProductsCount; j++)
                {
                    bag.Range(bottom, true, top, true);
                }
            }

            Console.WriteLine("{0} Price Checks with {1} elements from {2} elements in {3}", NumberOfSearches, FoundProductsCount, ProductsCount, watch.Elapsed);
            watch.Stop();
        }

        private static Product[] GetRandomProducts()
        {
            var generatedProducts = new Product[ProductsCount];
            for (int i = 0; i < ProductsCount; i++)
            {
                string name = new string((char)generator.Next(65, 91), generator.Next(4, 8));
                int price = generator.Next(1, ProductsCount);
                generatedProducts[i] = new Product(name, price);
            }

            return generatedProducts;
        }
    }
}
