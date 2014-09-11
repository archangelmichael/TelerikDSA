namespace _03.Divisors
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class GetNumberWithLowestDivisorsCount
    {
        private static string testInputFilePath = "../../Tests/test.000.001.in.txt";

        private static IList<int> numbers = new List<int>();

        public static void Main(string[] args)
        {
            if (File.Exists(testInputFilePath))
            {
                Console.SetIn(new StreamReader(testInputFilePath));
            }

            int rowsCount = int.Parse(Console.ReadLine());
            char[] digits = new char[rowsCount];
            for (int i = 0; i < rowsCount; i++)
            {
                digits[i] = char.Parse(Console.ReadLine());
            }

            Array.Sort(digits);
            //// All possible numbers are permutations with repetitions
            GenerateAllNumbers(digits, 0, digits.Length);

            Dictionary<int, int> numbersDivisorsCount = new Dictionary<int,int>();
            int minDivisorsCount = int.MaxValue;
            foreach (var number in numbers)
            {
                int divisorsCount = FindDivisors(number);
                numbersDivisorsCount.Add(number, divisorsCount);
                if (divisorsCount < minDivisorsCount)
                {
                    minDivisorsCount = divisorsCount;
                }
            }

            var lowestNumberWithLowestDivisors = numbersDivisorsCount
                                        .Where(num => num.Value == minDivisorsCount)
                                        .Select(num => num.Key)
                                        .OrderBy(num => num)
                                        .FirstOrDefault();

            Console.WriteLine(lowestNumberWithLowestDivisors);
        }

        private static int FindDivisors(int number)
        {
            int count = 0;
            for (int i = 1; i < number; i++)
            {
                if (number % i == 0)
                {
                    count++;
                }
            }

            return count;
        }

        private static void GenerateAllNumbers(char[] arr, int start, int n)
        {
          AddNumber(arr);
          for (int left = n - 2; left >= start; left--)
          {
            for (int right = left + 1; right < n; right++)
              if (arr[left] != arr[right])
              {
                Swap(ref arr[left], ref arr[right]);
                GenerateAllNumbers(arr, left + 1, n);
              }
            var firstElement = arr[left];
            for (int i = left; i < n - 1; i++)
              arr[i] = arr[i + 1];
            arr[n - 1] = firstElement;
          }
        }
        
        private static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }

        private static void AddNumber(char[] arr)
        {
            int numberToAdd = int.Parse(string.Join("", arr));
            numbers.Add(numberToAdd);
        }
    }
}
