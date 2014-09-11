namespace SortingHomework
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            //// Iterate through all elements of the collection. O(n) worst case.
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            int min = 0,
                max = items.Count;
            while (max >= min)
            {
                // calculate the midpoint for roughly equal partition
                int mid = (min + max + 1) / 2;
                if (items[mid].Equals(item))
                {
                    // key found at index imid
                    return true;
                    // determine which subarray to search
                }
                else if (items[mid].CompareTo(item) < 0)
                {   // change min index to search upper subarray
                    min = mid + 1;
                }
                else
                {   // change max index to search lower subarray
                    max = mid - 1;
                }
            }
            // key was not found
            return false;
        }

        public void Shuffle()
        {
            Random generator = new Random();
            var list = new SortedList<int, T>();
            
            //// Add all items from collection in a sorted list
            //// using randomly generated number as a key
            //// This shuffle is not very effective for collections
            //// with more that 2 000 000 elements
            foreach (T element in items)
            {
                list.Add(generator.Next(), element);
            }
            
            //// replace old collection values
            int index = 0;
            foreach (var pair in list)
            {
                items[index] = pair.Value;
                index++;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
