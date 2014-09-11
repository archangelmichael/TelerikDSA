namespace _01.StudentsInformationManipulation
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    /*
     * A text file students.txt holds information about students and their courses.
     * Using SortedDictionary<K,T> print the courses in alphabetical order 
     * and for each of them prints the students ordered by family and then by name:
     */
    public class TestSortedDictionary
    {
        private static SortedDictionary<string, SortedSet<Student>> students = 
            new SortedDictionary<string, SortedSet<Student>>();

        public static void Main(string[] args)
        {
            GetStudentsFromInput();
            PrintStudentCoursesInOrder();
        }

        private static void PrintStudentCoursesInOrder()
        {
            foreach (var entry in students)
            {
                Console.WriteLine("Students in course {0}: {1}", entry.Key, string.Join(", ", entry.Value));
            }
        }

        private static void GetStudentsFromInput()
        {
            using (StreamReader reader = new StreamReader("../../students.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    var entries = line.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    var student = new Student(entries[0].Trim(), entries[1].Trim());
                    if (!students.ContainsKey(entries[2]))
                    {
                        students.Add(entries[2], new SortedSet<Student>());
                    }

                    students[entries[2]].Add(student);
                    line = reader.ReadLine();
                }
            }
        }
    }
}
