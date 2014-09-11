namespace _05.SetImplementation
{
    using System;

    public class Program
    {
        /*
         * Implement the data structure "set" in a class HashedSet<T> 
         * using your class HashTable<K,T> to hold the elements. 
         * Implement all standard set operations like 
         * Add(T), Find(T), Remove(T), Count, Clear(), union and intersect.
         */
        public static void Main(string[] args)
        {
            var store = new HashedSet<string>();
            Console.WriteLine("********* TEST ADDITION **********");
            store.Add("book");
            store.Add("notepad");
            store.Add("computer");
            PrintCollection(store);

            Console.WriteLine("********* TEST FIND **************");
            Console.WriteLine("Is there notepad in store? {0}", store.Find("notepad") ? "YES" : "NO");
            Console.WriteLine("Is there pc in store? {0}", store.Find("pc") ? "YES" : "NO");

            Console.WriteLine("********* TEST REMOVE **************");
            Console.WriteLine("Try to remove item book. {0}", store.Remove("book") ? "OK" : "CANNOT BE DONE");
            PrintCollection(store);
            Console.WriteLine("Try to remove item book. {0}", store.Remove("book") ? "OK" : "CANNOT BE DONE");
            PrintCollection(store);

            Console.WriteLine("********* TEST COUNT **************");
            Console.WriteLine("Items in store: {0}", store.Count());

            Console.WriteLine("********* TEST UNION **************");
            var anotherStore = new HashedSet<string>() { "notepad", "pc", "phonebook", "dictionary" };
            store.Union(anotherStore);
            PrintCollection(store);
            Console.WriteLine("********* TEST INTERSECT **************");
            anotherStore = new HashedSet<string>() { "pc", "book", "computer" };
            store.Intersect(anotherStore);
            PrintCollection(store);

            Console.WriteLine("********* TEST CLEAR **************");
            store.Clear();
            PrintCollection(store);
        }

        private static void PrintCollection(HashedSet<string> store)
        {
            Console.WriteLine("Items in store: {0}", string.Join(", ", store));
        }
    }
}
