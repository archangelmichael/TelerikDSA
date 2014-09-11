namespace _10.FindShortestSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /*
     * * We are given numbers N and M and the following operations: 
     * a) N = N+1
     * b) N = N+2
     * c) N = N*2
     * Write a program that finds the shortest sequence of operations 
     * from the list above that starts from N and finishes in M. 
     * Hint: use a queue.
     * Example: N = 5, M = 16 => Sequence: 5  7  8  16
     */
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> operations = new List<int>();
            int start = GetInputValue();
            int end = GetInputValue();

            int newTarget = end;
            int multyplierCounter = 0;

            operations.Add(start);

            while (newTarget / 2 >= start)
            {
                newTarget /= 2;
                multyplierCounter++;
            }

            while (start < newTarget)
            {
                if (start + 2 < newTarget)
                {
                    start += 2;
                    operations.Add(start);
                }
                else if (start < newTarget)
                {
                    start++;
                    operations.Add(start);
                }
            }

            for (int i = 0; i < multyplierCounter; i++)
            {
                start *= 2;
                operations.Add(start);
            }

            Console.WriteLine(string.Join(" -> ", operations));
        }

        private static int GetInputValue()
        {
            Console.WriteLine("Enter number");
            string input = Console.ReadLine();
            int number;
            if (!int.TryParse(input, out number))
            {
                throw new ArgumentException("Value must be valid number!");
            }

            if (number < 0)
            {
                throw new ArgumentOutOfRangeException("Value must be positive!");
            }

            return number;
        }
    }
}
