namespace _03.WriteCombinationsWithNoDuplicates
{
    using System;
    /* TASK 3
     * Modify the previous program to skip duplicates:
     * n=4, k=2  (1 2), (1 3), (1 4), (2 3), (2 4), (3 4)
     */ 
 
    public class Program
    {
        public static void Main(string[] args)
        {
            int n, k;
            do
            {
                Console.Write("Enter number of elements n: ");
                n = int.Parse(Console.ReadLine());
                Console.Write("Enter number of duplicates k ( k < n and k > 0): ");
                k = int.Parse(Console.ReadLine());
            } while (k < 0 || k > n);

            WriteCombinations(0, n, k, new int[k]);
        }

        private static void WriteCombinations(int index, int number, int length, int[] arr)
        {
            if (index == length)
            {
                Console.WriteLine("({0})", string.Join(" ", arr));
                return;
            }

            int num = (index == 0) ? 1 : arr[index - 1] + 1;
            for (; num <= number; num++)
            {
                arr[index] = num;
                WriteCombinations(index + 1, number, length, arr);
            }
        }
    }
}
