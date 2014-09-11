namespace _02.ColourfulBunnies
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class FindAllRabbitsCount
    {
        private static string testInputFilePath = "../../Tests/test.000.001.in.txt";

        public static void Main(string[] args)
        {
            if (File.Exists(testInputFilePath))
            {
                Console.SetIn(new StreamReader(testInputFilePath));
            }

            int rabbitsAsked = int.Parse(Console.ReadLine());
            var groupedAnswers = new Dictionary<int, int>();

            for (int i = 0; i < rabbitsAsked; i++)
            {
                int count = int.Parse(Console.ReadLine());
                if (!groupedAnswers.ContainsKey(count + 1))
                {
                    groupedAnswers.Add(count + 1, 0);
                }

                groupedAnswers[count + 1]++;
            }

            long rabbitsCount = 0;
            foreach (var answer in groupedAnswers)
            {
                int value = answer.Value;
                int key = answer.Key;

                if (value < key)
                {
                    rabbitsCount += key;
                }
                else
                {
                    if (value% key == 0)
                    {
                        rabbitsCount += value;
                    }
                    else
                    {
                        rabbitsCount += value/key*key + key;
                    }
                }
            }

            Console.WriteLine(rabbitsCount);
        }
    }
}
