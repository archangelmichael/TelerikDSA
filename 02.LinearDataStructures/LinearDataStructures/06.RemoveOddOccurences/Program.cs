namespace _06.RemoveOddOccurences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        /* Write a program that removes from given sequence all numbers that occur odd number of times. 
            Example: {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2}  {5, 3, 3, 5} */
        public static void Main(string[] args)
        {
            List<int> givenSequence = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            var newSequence = RemoveNumbersWithOddCount(givenSequence);
            Console.WriteLine(string.Join(", ", newSequence));
        }

        private static IEnumerable<int> RemoveNumbersWithOddCount(List<int> givenSequence)
        {
            var dictionaryWithNumberOccurences = givenSequence.GroupBy(x => x).ToDictionary(gr => gr.Key, gr => gr.Count());
            var newSequence = givenSequence.Where(x => dictionaryWithNumberOccurences[x] % 2 == 0);
            return newSequence.ToList();
        }
    }
}
