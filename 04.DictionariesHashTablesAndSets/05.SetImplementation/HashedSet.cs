namespace _05.SetImplementation
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using _04.HashTableImplementation;

    public class HashedSet<T> : IEnumerable<T>
    {
        private HashTable<T, bool> elements;

        public HashedSet()
        {
            this.elements = new HashTable<T, bool>();
        }

        public HashedSet(IEnumerable<T> collection)
        {
            this.elements = new HashTable<T, bool>();
            foreach (var item in collection)
            {
                this.Add(item);
            }
        }

        public int Count()
        {
            return this.elements.Count;
        }

        /// <summary>
        /// Adds new value to the collection
        /// </summary>
        /// <param name="key"> The value to be added to the collection </param>
        /// <returns> Bool value showing if the addition has been successful </returns>
        public bool Add(T key)
        {
            if (this.elements.ContainsKey(key))
            {
                return false;
            }

            this.elements.Add(key, false);
            return true;
        }

        /// <summary>
        /// Search for given value in the collection
        /// </summary>
        /// <param name="key"> the value to search for </param>
        /// <returns> Bool value showing if the value has been found </returns>
        public bool Find(T key)
        {
            return this.elements.ContainsKey(key);
        }

        /// <summary>
        /// Removes given value from the collection
        /// </summary>
        /// <param name="key"> the value to remove from the collection</param>
        /// <returns> Bool value showing if the value has been removed successfully</returns>
        public bool Remove(T key)
        {
            return this.elements.Remove(key);
        }

        /// <summary>
        /// Clear all elements from the collection by creating new collection instance
        /// </summary>
        public void Clear() 
        {
            this.elements = new HashTable<T, bool>();
        }
 
        /// <summary>
        /// Modifies current collection to hold all elements,
        /// which occur in both collections
        /// </summary>
        /// <param name="collection"> another collection to unite values with curret</param>
        public void Union(IEnumerable<T> collection) 
        {
            foreach (var element in collection)
            {
                this.Add(element);
            }
        }

        /// <summary>
        /// Modifies current collection to hold only the values,
        /// which occur in both collections
        /// </summary>
        /// <param name="collection"> another collection to intersect current with</param>
        public void Intersect(IEnumerable<T> collection) 
        {
            foreach (var element in this.elements.Keys.ToList())
            {
                if (!collection.Contains(element))
                {
                    this.Remove(element);
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.elements.Select(pair => pair.Key).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
