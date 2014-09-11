namespace _06.SubsetsOfKStrings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /* TASK 6
     * Write a program for generating and printing all subsets of k strings from given set of strings.
     * Example: s = {test, rock, fun}, k=2
     * (test rock),  (test fun),  (rock fun)
     */ 
    public class Program
    {
        private static string[] set;

        private static Random generator = new Random();

        internal static void Main()
        {
            int k;
            do
            {
                Console.Write("Enter number of subsets k ( k < n and k > 0): ");
                k = int.Parse(Console.ReadLine());
            } while (k < 0);

            int setLength = generator.Next(k, k + 10);
            GenerateSet(setLength, k);
            Console.WriteLine(string.Format("Set: {0}", string.Join(", ", set)));
            FindSubsetCombinations(0, setLength, k, new int[k]);
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

        private static void FindSubsetCombinations(int index, int setLength, int length, int[] combination)
        {
            if (index == length)
            {
                Console.WriteLine("({0})", string.Join(" ", combination.Select(x => set[x])));
                return;
            }

            int i = (index == 0) ? 0 : combination[index - 1] + 1;
            for (; i < setLength; i++)
            {
                combination[index] = i;
                FindSubsetCombinations(index + 1, setLength, length, combination);
            }
        }
    }
}
