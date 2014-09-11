namespace _03.CountWordsOccurences
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class WordsOccurences
    {
        /*
         * Write a program that counts how many times each word from given text file words.txt appears in it. 
         * The character casing differences should be ignored. 
         * The result words should be ordered by their number of occurrences in the text.
         * Example: This is the TEXT. Text, text, text - THIS TEXT! Is this the text?
         * Result: is  2 the  2 this  3 text  6
         */

        public static void Main(string[] args)
        {
            var separators = new char[] { '-', ' ', ',', '.', '!', '?', ';', ':' };
            using (var reader = new StreamReader("../../words.txt"))
            {
                var words = new List<string>();
                var input = reader.ReadLine();
                while (input != null)
                {
                    var inputWords = input.Split(separators, StringSplitOptions.RemoveEmptyEntries).Select(word => word.ToLower());
                    words.AddRange(inputWords);
                    input = reader.ReadLine();
                }

                var wordsOccurences = GetElementsOccurences(words);
                PrintWordOccurencesOrderedByOccurences(wordsOccurences);
            }
        }

        private static void PrintWordOccurencesOrderedByOccurences<T>(IDictionary<T, int> wordsOccurences)
        {
            var orderedWordOccurrences = wordsOccurences.OrderBy(pair => pair.Value);
            foreach (var pair in orderedWordOccurrences)
            {
                Console.WriteLine("{0} => {1} times", pair.Key, pair.Value);
            }
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
