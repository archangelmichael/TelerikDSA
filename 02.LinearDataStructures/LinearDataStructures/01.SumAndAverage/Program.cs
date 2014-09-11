namespace _01.SumAndAverage
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        /*
         * Write a program that reads from the console a sequence of positive integer numbers. 
         * The sequence ends when empty line is entered. 
         * Calculate and print the sum and average of the elements of the sequence. 
         * Keep the sequence in List<int>.
         */

        public static void Main(string[] args)
        {
            IList<int> numbersSequence = GetInputSequence();
            int sumOfNumbers = 0;
            foreach (var number in numbersSequence)
            {
                sumOfNumbers += number;
            }

            Console.WriteLine("The sum of the sequence is: {0}", sumOfNumbers);
            Console.WriteLine("The average value of the sequence is: {0}", (double)sumOfNumbers / numbersSequence.Count);
        }

        private static IList<int> GetInputSequence()
        {
            var sequence = new List<int>();
            string input = Console.ReadLine();
            while (input != string.Empty)
            {
                int number = -1;
                bool isNumber = int.TryParse(input, out number);
                if (!isNumber || number < 0)
                {
                    throw new ArgumentException("Invalid Input! Input must be a positive number!");
                }

                sequence.Add(number);
                input = Console.ReadLine();
            }

            return sequence;
        }
    }
}
