namespace _02.ExtractElementsWithOddCount
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GetElementsWithOddOccurrences
    {
        /*
         * Write a program that extracts from a given sequence of strings all elements that present in it odd number of times. 
         * Example: {C#, SQL, PHP, PHP, SQL, SQL }  {C#, SQL}
         */

        public static void Main(string[] args)
        {
            string[] values = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            var occurences = GetElementsOccurences(values);
            var elementsWithOddOccurences = occurences.Where(current => current.Value % 2 != 0).Select(current => current.Key);
            Console.WriteLine(string.Join(", ", elementsWithOddOccurences));
        }

        private static IDictionary<T, int> GetElementsOccurences<T>(IEnumerable<T> values)
        {
            var dictionary = new Dictionary<T, int>();
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
