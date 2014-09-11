namespace _01.CountDoubleValuesOccurrences
{
    using System;
    using System.Collections.Generic;

    public class GetOccurences
    {
        /*
         * Write a program that counts in a given array of double values the number of occurrences of each value. 
         * Use Dictionary<TKey,TValue>.Example: array = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5}
         * -2.5  2 times
         * 4  3 times
         * 3  4 times
         */

        public static void Main(string[] args)
        {
            double[] values = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            IDictionary<double, int> occurences = GetElementsOccurences(values);
           
            ////Print occurrences
            foreach (var key in occurences)
            {
                Console.WriteLine("{0} => {1} times", key.Key, key.Value);
            }
        }

        private static IDictionary<T, int> GetElementsOccurences<T>(IEnumerable<T> values)
        {
            var dictionary = new SortedDictionary<T, int>();
            foreach (var item in values)
            {
                if (dictionary.ContainsKey(item))
                {
                    dictionary[item]++;
                }
                else
                {
                    dictionary.Add(item, 1);
                }
            }

            return dictionary;
        }
    }
}
