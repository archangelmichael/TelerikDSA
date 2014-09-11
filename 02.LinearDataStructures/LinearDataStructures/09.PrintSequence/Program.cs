namespace _09.PrintSequence
{
    using System;
    using System.Collections.Generic;

    /*
     * We are given the following sequence:
        S1 = N;
        S2 = S1 + 1;
        S3 = 2*S1 + 1;
        S4 = S1 + 2;
        S5 = S2 + 1;
        S6 = 2*S2 + 1;
        S7 = S2 + 2;
        ...
        Using the Queue<T> class write a program to print 
        its first 50 members for given N.
        Example: N=2  2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...
     */
    public class Program
    {
        private static const int SequenceMembersCount = 50;

        public static void Main(string[] args)
        {
            int startValue = GetInputLength();
            List<int> sequenceElements = GetSequence(startValue);
            Console.WriteLine(string.Join(", ", sequenceElements));
        }

        private static List<int> GetSequence(int startAt)
        {
            List<int> seqence = new List<int>();
            var numbersSequence = new Queue<int>();
            numbersSequence.Enqueue(startAt);
            int count = 0;
            int index = 0;
            while (count < SequenceMembersCount)
            {
                int current = numbersSequence.Dequeue();
                index++;
                numbersSequence.Enqueue(current + 1);
                numbersSequence.Enqueue((2 * current) + 1);
                numbersSequence.Enqueue(current + 2);
                seqence.Add(current);
                count++;
            }

            return seqence;
        }

        private static int GetInputLength()
        {
            string input = Console.ReadLine();
            int number;
            if (!int.TryParse(input, out number))
            {
                throw new ArgumentException("Sequence length must be valid number!");
            }

            if (number < 0)
            {
                throw new ArgumentOutOfRangeException("Sequence length must be positive!");
            }

            return number;
        }
    }
}
