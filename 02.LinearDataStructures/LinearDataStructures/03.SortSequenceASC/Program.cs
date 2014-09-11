namespace _03.SortSequenceASC
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        /* 
         * Write a program that reads a sequence of integers (List<int>) ending with an empty line 
         * and sorts them in an increasing order.
         */
        public static void Main(string[] args)
        {
            List<int> numbersSequence = GetInputSequence();
            ////CAN USE ANY OF THE FOLLOWING METHODS
            ////numbersSequence.Sort();
            numbersSequence.Sort((num1, num2) => num1.CompareTo(num2));
            PrintOutput(numbersSequence);
        }

        private static List<int> GetInputSequence()
        {
            var sequence = new List<int>();
            Console.WriteLine("Enter numbers (each number on a separate row). End with empty line!");
            string input = Console.ReadLine();
            while (input != string.Empty)
            {
                int number = -1;
                bool isNumber = int.TryParse(input, out number);
                if (!isNumber)
                {
                    throw new ArgumentException("Invalid Input! Input must be an integer number!");
                }

                sequence.Add(number);
                input = Console.ReadLine();
            }

            return sequence;
        }

        private static void PrintOutput(List<int> numbersSequence)
        {
            Console.WriteLine("Ordered sequence");
            foreach (var number in numbersSequence)
            {
                Console.WriteLine(number);
            }
        }
    }
}
