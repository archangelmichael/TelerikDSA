namespace _02.DirectoryTraversal
{
    using System;
    using System.IO;

    /*
    Write a program to traverse the directory 
    C:\WINDOWS and all its subdirectories recursively and 
    to display all files matching the mask *.exe. Use the 
    class System.IO.Directory.
     */
    public class TraverseDirectory
    {
        public static void Main()
        {
            string path = "C:\\WINDOWS";
            string pattern = "*.exe";
            SearchDirectory(new DirectoryInfo(path), pattern);
        }

        /// <summary>
        /// Displays all files in a folder (and all its subfolders) matching a given search pattern
        /// </summary>
        /// <param name="dir">the directory to search in</param>
        /// <param name="mask">the pattern we are searching for</param>
        private static void SearchDirectory(DirectoryInfo dir, string mask)
        {
            try
            {
                PrintFileInFolder(dir, mask);
                foreach (DirectoryInfo child in dir.EnumerateDirectories())
                {
                    SearchDirectory(child, mask);
                }
            }
            catch (System.Exception)
            {
                Console.WriteLine("Unauthorized Access!");
            }
        }

        /// <summary>
        /// Displays all files in a specific folder that match a given search pattern
        /// </summary>
        /// <param name="dir">the folder containing the files</param>
        /// <param name="mask">the pattern we are searching for</param>
        private static void PrintFileInFolder(DirectoryInfo dir, string mask)
        {
            foreach (var file in dir.EnumerateFiles(mask))
            {
                Console.WriteLine(file.FullName.Substring(dir.FullName.Length + 1));
            }
        }
    }
}
