namespace _03.WordsSearchInLargeText
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;

    /*
     * Write a program that finds a set of words (e.g. 1000 words) in a large text (e.g. 100 MB text file). 
     * Print how many times each word occurs in the text. Hint: you may find a C# trie in Internet.
     */
    public class Program
    {
        private const int WordsCount = 1000;
        private const int WordsCountFor100MB = 16000000;
        private static Random generator = new Random();
        private string filePath = "../../output.txt";

        public static void Main(string[] args)
        {
            //// WARNING !!! TO GENERATE 100MB TEXT FILE UNCOMMENT NEXT LINE
            //// BE PATIENT AS IT TAKES SOME TIME TO GENERATE 27 000 PAGES 
            //// WITH MORE THAN 16,000,000 WORDS IN IT
            //// var words = GenerateWords();
            //// GenerateBigTextFile(words);

            var sw = new Stopwatch();
            var trie = new Trie();
            for (int i = 0; i < WordsCountFor100MB; i++)
            {
                string word = GetRandomWord();
                sw.Start();
                trie.Add(word);
                sw.Stop();
            }

            Console.WriteLine("Added {0} words in {1}", WordsCountFor100MB, sw.Elapsed);
            sw.Reset();
            for (int i = 0; i < WordsCount; i++)
            {
                string word = GetRandomWord();
                sw.Start();
                trie.GetWordOccurance(word);
                sw.Stop();
            }

            Console.WriteLine("Search for {0} words in {1}", WordsCount, sw.Elapsed);
            Console.WriteLine("Most common word: {0}", trie.GetMostCommonWord());
        }

        private static string GetRandomWord()
        {
            return new string((char)generator.Next(65, 91), generator.Next(3, 6));
        }

        private static void GenerateBigTextFile(string[] words)
        {
            using (StreamWriter writer = new StreamWriter("../../output.txt", false))
            {
                long fileSize = 0;
                long maxSize = 104857600; //// EQUALS 100MB
                while (fileSize < maxSize)
                {
                    string word = words[generator.Next(words.Length)] + " ";
                    writer.Write(word);
                    FileInfo file = new FileInfo(@"../../output.txt");
                    fileSize = file.Length;
                }
            }
        }

        private static string[] GenerateWords()
        {
            var generatedWords = new List<string>();
            for (int i = 0; i < WordsCount; i++)
            {
                string name = GetRandomWord();
                generatedWords.Add(name);
            }

            return generatedWords.ToArray();
        }
    }
}
