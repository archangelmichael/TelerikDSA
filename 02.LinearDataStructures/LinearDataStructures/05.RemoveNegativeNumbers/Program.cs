namespace _05.RemoveNegativeNumbers
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        /* Write a program that removes from given sequence all negative numbers. */
        public static void Main(string[] args)
        {
            List<int> givenSequence = new List<int>() { 1, -4, 22, -13, -11, 2, 0, 88, -192 };
            givenSequence.RemoveAll(x => x < 0);
            Console.WriteLine(string.Join(", ", givenSequence));
        }
    }
}
