namespace _01.StudentsInformationManipulation
{
    using System;

    public class Student : IComparable<Student>
    {
        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }

        /// <summary>
        /// Implements Student Comparison first by LastName and then by FirstName
        /// </summary>
        /// <param name="other"> another Student instance to compare to </param>
        /// <returns> an int value showing which student is first according to condition</returns>
        public int CompareTo(Student other)
        {
            if (this.LastName == other.LastName)
            {
                return this.FirstName.CompareTo(other.FirstName);
            }
            else
            {
                return this.LastName.CompareTo(other.LastName);
            }
        }
    }
}
