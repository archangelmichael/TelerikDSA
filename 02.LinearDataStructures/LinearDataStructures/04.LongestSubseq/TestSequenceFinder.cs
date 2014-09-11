namespace _04.LongestSubseq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TestSequenceFinder
    {
        public static void Main()
        {
            var numbersSequence = new List<int>() { 2, 5, 6, 23, 23, 23, 2, 2, 6, 6, 23 };
            var longestSequence = SubsequenceFinder.FindLongestSubsequence(numbersSequence);
            Console.WriteLine(string.Join(", ", longestSequence));
        }
    }
}
