namespace _04.LongestSubseq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SubsequenceFinder
    {
        public static IList<int> FindLongestSubsequence(IList<int> inputSequence)
        {
            var longestSequence = new List<int>();
            int startSequenceIndex = 0;
            int sequenceElementsCount = 0;

            for (int elementIndex = 0; elementIndex < inputSequence.Count - 1; elementIndex++)
            {
                int currEqualElementsCount = 1;
                while (elementIndex < inputSequence.Count - 1 && inputSequence[elementIndex] == inputSequence[elementIndex + 1])
                {
                    elementIndex++;
                    currEqualElementsCount++;
                }

                if (currEqualElementsCount > sequenceElementsCount)
                {
                    sequenceElementsCount = currEqualElementsCount;
                    startSequenceIndex = elementIndex - sequenceElementsCount + 1;
                }
            }

            for (int i = startSequenceIndex; i < startSequenceIndex + sequenceElementsCount; i++)
            {
                longestSequence.Add(inputSequence[i]);
            }

            return longestSequence;
        }
    }
}
