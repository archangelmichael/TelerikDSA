namespace _02.ReverseSequence
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        /* 
         * Write a program that reads N integers from the console and reverses them using a stack. 
         * Use the Stack<int> class.
         */

        public static void Main(string[] args)
        {
            int sequenceLength = ReadInputLength();
            Stack<int> numbersSequence = GetNumbersSequence(sequenceLength);
            PrintReverseSequence(numbersSequence);
        }

        private static Stack<int> GetNumbersSequence(int sequenceLength)
        {
            var sequence = new Stack<int>();
            int currentNumber;
            for (int index = 0; index < sequenceLength; index++)
            {
                currentNumber = 0;
                string inputNumber = Console.ReadLine();
                if (!int.TryParse(inputNumber, out currentNumber))
                {
                    throw new ArgumentException("Input must be a number!");
                }

                sequence.Push(currentNumber);
            }

            return sequence;
        }

        private static int ReadInputLength()
        {
            Console.WriteLine("Enter numbers sequence length");
            string input = Console.ReadLine();
            int sequenceLength = 0;
            if (!int.TryParse(input, out sequenceLength))
            {
                throw new ArgumentException("Invalid sequence length entereed!");
            }

            if(sequenceLength <= 0)
            {
                throw new ArgumentException("Sequence length must be positive number!");
            }

            Console.WriteLine("Enter numbers");
            return sequenceLength;
        }

        private static void PrintReverseSequence(Stack<int> output)
        {
            Console.WriteLine("Reversed Sequence");
            while (output.Count > 0)
            {
                Console.WriteLine(output.Pop());
            }
        }
    }
}
