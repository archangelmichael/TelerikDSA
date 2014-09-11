namespace _04.ColourBalls
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Numerics;

    public class GetColorsPermutationsCount
    {
        private static string testInputFilePath = "../../Tests/test.000.001.in.txt";

        public static void Main(string[] args)
        {
            if (File.Exists(testInputFilePath))
            {
                Console.SetIn(new StreamReader(testInputFilePath));
            }

            string input = Console.ReadLine();
            var colors = new Dictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (!colors.ContainsKey(input[i]))
                {
                    colors.Add(input[i], 0);
                }

                colors[input[i]]++;
            }

            //// Permutations with repetition of n elements are permuations
            //// where the first element is repeated a times, the second b times, the third c times, ... 
            //// n = a + b + c + ... SO: PRn(a + b + c +.. ) = n!/(a! + b! + c! + ... );
            BigInteger top = Factorial(input.Length); //// n!
            BigInteger bottom = 1; //// a! * b! * c! ....
            foreach (var item in colors)
            {
                bottom *= Factorial(item.Value);
            }

            Console.WriteLine(top / bottom);
        }

        private static BigInteger Factorial(int number)
        {
            BigInteger factorial = 1;
            while (number > 1)
            {
                factorial = factorial * number;
                number--;
            }

            return factorial;
        }
    }
}
