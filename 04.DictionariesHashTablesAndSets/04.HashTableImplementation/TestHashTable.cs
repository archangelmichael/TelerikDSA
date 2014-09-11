namespace _04.HashTableImplementation
{
    using System;
    using System.Linq;

    public class TestHashTable
    {
        /*
         *Implement the data structure "hash table" in a class HashTable<K,T>. 
         * Keep the data in array of lists of key - value pairs (LinkedList<KeyValuePair<K,T>>[]) 
         * with initial capacity of 16. 
         * When the hash table load runs over 75%, perform resizing to 2 times larger capacity. 
         * Implement the following methods and properties: 
         * Add(key, value), 
         * Find(key)value, 
         * Remove(key), 
         * Count, 
         * Clear(), 
         * this[], 
         * Keys. 
         * Try to make the hash table to support iterating over its elements with foreach.
         */

        public static void Main(string[] args)
        {
            var ranges = new HashTable<string, int>();
            ////Test ADD
            ranges.Add("Sofia Burgas", 400);
            ranges.Add("Sofia Plovdiv", 150);
            ranges.Add("Sofia Varna", 550);
            ranges.Add("Sofia Vidin", 150);
            ranges.Add("Sofia Pleven", 150);

            ////Test FOREACH
            foreach (var range in ranges.OrderBy(r => r.Value))
            {
                Console.WriteLine("{0} -> range {1}", range.Key, range.Value);
            }

            ////Test ADD DUPLICATE should throw an exception
            try
            {
                ranges.Add("Sofia Pleven", 140);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            ////Test Keys
            Console.WriteLine("Keys: {0}", string.Join(", ", ranges.Keys));

            ////Test Count
            Console.WriteLine("Number of pairs: {0}", ranges.Count);

            ////Test FIND
            Console.WriteLine("Sofia Pleven -> {0}", ranges.Find("Sofia Pleven"));

            ////Test INDEXING
            Console.WriteLine("Sofia Pleven -> {0}", ranges["Sofia Pleven"]);

            ////Test ContainsKey
            Console.WriteLine("Contains \"Sofia Plovdiv\": {0}", ranges.ContainsKey("Sofia Plovdiv"));

            ////Test REMOVE
            ranges.Remove("Sofia Burgas");
            Console.WriteLine("Remove \"Sofia Burgas\"");
            Console.WriteLine("Keys: {0}", string.Join(", ", ranges.Keys));
            Console.WriteLine("Number of pairs: {0}", ranges.Count);
            Console.WriteLine("Removing \"Sofia Varna\" -> {0}", ranges.Remove("Sofia Varna"));

            ////Test CLEAR
            ranges.Clear();
            Console.WriteLine("Clear hash table");
            Console.WriteLine("Number pairs: {0}", ranges.Count);
        }
    }
}
