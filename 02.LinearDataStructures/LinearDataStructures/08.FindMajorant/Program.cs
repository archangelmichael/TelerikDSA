namespace _08.FindMajorant
{
    using System;
    using System.Linq;

    public class Program
    {
        /*
         * The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times. 
         * Write a program to find the majorant of given array (if exists). 
         * Example: {2, 2, 3, 3, 2, 3, 4, 3, 3}  3 
         */
        public static void Main(string[] args)
        {
            int[] inputArray = new int[] { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            int majorantOccurence = (inputArray.Length / 2) + 1;
            ////Create dictionary with the count of the occurences of each number
            var elementOccurences = inputArray.GroupBy(x => x).ToDictionary(gr => gr.Key, gr => gr.Count());
            ////Check each element by its occurenceCount
            var majorantElement = inputArray.FirstOrDefault(x => elementOccurences[x] >= majorantOccurence);
            string output = majorantElement == 0 ? "Array doesnt have a majorant element!" : "The majorant element is " + majorantElement;
            Console.WriteLine(output);
        }
    }
}
