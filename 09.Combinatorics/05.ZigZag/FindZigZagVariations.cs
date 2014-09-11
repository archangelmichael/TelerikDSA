namespace _05.ZigZag
{
    using System;
    using System.IO;

    public class FindZigZagVariations
    {
        private static string testInputFilePath = "../../Tests/test.008.in.txt";

        private static int[] arr;

        private static bool[] used;

        private static long zigzagsCount = 0;

        public static void Main(string[] args)
        {
            if (File.Exists(testInputFilePath))
            {
                Console.SetIn(new StreamReader(testInputFilePath));
            }

            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int range = int.Parse(input[0]);
            int variationSize = int.Parse(input[1]);

            arr = new int[variationSize];
	        used = new bool[range];
            GenerateVariationsNoRepetitions(0);
            Console.WriteLine(zigzagsCount);
        }

        private static void GenerateVariationsNoRepetitions(int index)
        {
            if (index == arr.Length)
            {
                if (CheckVariation(arr))
                {
                    zigzagsCount++;
                }

                return;
            }

            for (int i = 0; i < used.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    arr[index] = i;
                    GenerateVariationsNoRepetitions(index + 1);
                    used[i] = false;
                }
            }
        }

        private static bool CheckVariation(int[] variation)
        {
            if (variation.Length == 1)
            {
                return true;
            }
            if (variation.Length == 2)
            {
                return variation[0] > variation[1];
            }

            for (int i = 1; i < variation.Length - 1; i++)
            {
                var isEven = i % 2 == 0 && !(variation[i - 1] < variation[i] && variation[i] > variation[i + 1]);
                var isOdd = i % 2 == 1 && !(variation[i - 1] > variation[i] && variation[i] < variation[i + 1]);
                if (isEven || isOdd)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
