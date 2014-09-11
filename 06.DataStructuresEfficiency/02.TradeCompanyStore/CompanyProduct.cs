namespace _02.TradeCompanyStore
{
    using System;

    public class CompanyProduct : IComparable<CompanyProduct>
    {
        public CompanyProduct(string barcode, string vendor, string title, int price)
        {
            this.Barcode = barcode;
            this.Vendor = vendor;
            this.Title = title;
            this.Price = price;
        }

        public string Barcode { get; set; }

        public string Vendor { get; set; }

        public string Title { get; set; }

        public int Price { get; set; }
        
        /// <summary>
        /// Orders Products by price
        /// </summary>
        /// <param name="other"> another CompanyProduct instance to compare with</param>
        /// <returns> integer value showing which product has priority</returns>
        public int CompareTo(CompanyProduct other)
        {
            return this.Price.CompareTo(other.Price);
        }
    }
}
