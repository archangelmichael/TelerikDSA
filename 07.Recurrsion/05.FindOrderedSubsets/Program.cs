namespace _05.FindOrderedSubsets
{
    using System;
    using System.Linq;
    using System.Text;
    /* TASK 5
     * Write a recursive program for generating and printing all ordered k-element subsets 
     * from n-element set (variations Vkn).
     * Example: n=3, k=2, set = {hi, a, b} =>
     * (hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)
     */ 

    public class Program
    {
        private static string[] set;

        private static Random generator = new Random();

        internal static void Main()
        {
            int n, k;
            do
            {
                Console.Write("Enter number of elements n: ");
                n = int.Parse(Console.ReadLine());
                Console.Write("Enter number of ordered subsets k ( k < n and k > 0): ");
                k = int.Parse(Console.ReadLine());
            } while (k < 0 || k > n);

            GenerateSet(n, k);
            Console.WriteLine(string.Format("Set: {0}", string.Join(", ", set)));
            FindVariations(0, n, k, new int[k]);
        }

        private static void GenerateSet(int setLength, int elementLength)
        {
            set = new string[setLength];
            for (int i = 0; i < setLength; i++)
            {
                set[i] = GetString(generator.Next(1, elementLength));
            }
        }

        private static string GetString(int length)
        {
            string letters = "ABCDEFGHIJKLNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder word = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                word.Append(letters[generator.Next(0, letters.Length - 1)]);
            }

            return word.ToString();
        }

        private static void FindVariations(int index, int number, int length, int[] variation)
        {
            if (index == length)
            {
                Console.WriteLine("({0})", string.Join(", ", variation.Select(i => set[i])));
                return;
            }

            for (int i = 0; i < number; i++)
            {
                variation[index] = i;
                FindVariations(index + 1, number, length, variation);
            }
        }
    }
}
