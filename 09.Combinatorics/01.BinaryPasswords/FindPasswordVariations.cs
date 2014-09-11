namespace _01.BinaryPasswords
{
    using System;
    using System.IO;

    public class FindPasswordVariations
    {
        private static string testInputFilePath = "../../Tests/test.000.001.in.txt";

        public static void Main(string[] args)
        {
            if (File.Exists(testInputFilePath))
            {
                Console.SetIn(new StreamReader(testInputFilePath));
            }

            string password = Console.ReadLine();
            long starCount = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] == '*')
                {
                    starCount++;
                }
            }

            //// Possible variations for n elements, choosing k times, with repetition is:  n^k
            Console.WriteLine("MATH.POW SOLUTION");
            double starsCount = (double)starCount;
            long result2 = (long)Math.Pow(2d, starsCount);
            Console.WriteLine(result2);
        }
    }
}
