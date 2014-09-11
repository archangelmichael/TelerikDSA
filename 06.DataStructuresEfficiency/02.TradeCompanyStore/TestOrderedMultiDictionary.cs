namespace _02.TradeCompanyStore
{
    using System;
    using System.Diagnostics;
    using Wintellect.PowerCollections;
    /*
     * A large trade company has millions of articles, 
     * each described by barcode, vendor, title and price. 
     * Implement a data structure to store them 
     * that allows fast retrieval of all articles in given price range [x…y]. 
     * Hint: use OrderedMultiDictionary<K,T> from Wintellect's Power Collections for .NET.
     */
    public class TestOrderedMultiDictionary
    {
        private const int ArticlesCount = 1000000;

        private static Random generator = new Random();

        private static Stopwatch watch = new Stopwatch();
        
        private static OrderedMultiDictionary<int, CompanyProduct> companyArticles = 
            new OrderedMultiDictionary<int, CompanyProduct>(false);

        public static void Main(string[] args)
        {
            PopulateCompanyArticles();
            int bottom = generator.Next(1, ArticlesCount / 2);
            int top = generator.Next(ArticlesCount / 2, ArticlesCount);
            watch.Restart();
            SearchArticlesInPriceRange(bottom, top);
            Console.WriteLine("Search in range [{0},{1}] in {2}", bottom, top, watch.Elapsed);
            PerformLotsOfSearchesInARow();
        }

        private static void PerformLotsOfSearchesInARow()
        {
            Console.WriteLine("Performing {0} searches in a row...", ArticlesCount / 2);
            watch.Restart();
            for (int i = 0; i < ArticlesCount / 2; i++)
            {
                int bottom = generator.Next(1, ArticlesCount / 2);
                int top = generator.Next(ArticlesCount / 2, ArticlesCount);
                SearchArticlesInPriceRange(bottom, top);
            }

            Console.WriteLine("{0} searches performed in {1}", ArticlesCount / 2, watch.Elapsed);
            watch.Stop();
        }

        private static void SearchArticlesInPriceRange(int bottom, int top)
        {
            companyArticles.Range(bottom, true, top, true);
        }

        private static void PopulateCompanyArticles()
        {
            Console.WriteLine("Populating with articles....");
            watch.Start();
            for (int i = 0; i < ArticlesCount; i++)
            {
                var price = generator.Next(1, ArticlesCount);
                var product = new CompanyProduct(GenerateRandomString(), GenerateRandomString(), GenerateRandomString(), price);
                companyArticles.Add(price, product);
            }

            Console.WriteLine("{0} articles added in {1}", ArticlesCount, watch.Elapsed);
        }

        private static string GenerateRandomString()
        {
            return new string((char)generator.Next(65, 90), generator.Next(3, 9));
        }
    }
}
