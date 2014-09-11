namespace _04.GenerateAllPermutations
{
    using System;
    /* TASk 4
     * Write a recursive program for generating and printing all permutations 
     * of the numbers 1, 2, ..., n for given integer number n. 
     * Example:	n=3  {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2},{3, 2, 1}
     */

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter number of elements n: ");
            int n = int.Parse(Console.ReadLine());
            FindPermutations(0, n, new int[n], new bool[n]);
        }

        private static void FindPermutations(int index, int number, int[] arr, bool[] used)
        {
            if (index == number)
            {
                Console.WriteLine("{{{0}}}", string.Join(", ", arr));
                return;
            }

            for (int num = 0; num < number; num++)
            {
                if (used[num])
                {
                    continue;
                }

                arr[index] = num + 1;
                used[num] = true;
                FindPermutations(index + 1, number, arr, used);
                used[num] = false;
            }
        }
    }
}