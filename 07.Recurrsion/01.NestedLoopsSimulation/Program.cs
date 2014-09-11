namespace _01.NestedLoopsSimulation
{
    using System;
    /* TASK 1
     * Write a recursive program that simulates the execution of n nested loops from 1 to n.
     */
 
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            NestLoops(0, n, new int[n]);
        }

        private static void NestLoops(int i, int n, int[] arr)
        {
            if (i == n)
            {
                Console.WriteLine(string.Join(", ", arr));
                return;
            }

            for (int num = 1; num <= n; num++)
            {
                arr[i] = num;
                NestLoops(i + 1, n, arr);
            }
        }
    }
}
