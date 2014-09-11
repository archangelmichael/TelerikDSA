namespace _07.CountNumberOccurences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        /* 
         * Write a program that finds in given array of integers (all belonging to the range [0..1000]) 
         * how many times each of them occurs.
         * Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2} => 2  2 times; 3  4 times; 4  3 times
        */
        public static void Main(string[] args)
        {
            List<int> givenSequence = new List<int>() { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            var occurences = GetNumberOccurences(givenSequence);
            foreach (var entry in occurences)
            {
                Console.WriteLine("{0} is found {1} times", entry.Key, entry.Value);
            }
        }

        private static IDictionary<int, int> GetNumberOccurences(List<int> givenSequence)
        {
            ////Order the elements in ascendin order, group them by their value and create a dictionary
            var dictionaryWithNumberOccurences = givenSequence.OrderBy(x => x).GroupBy(x => x).ToDictionary(gr => gr.Key, gr => gr.Count());
            return dictionaryWithNumberOccurences;
        }
    }
}
