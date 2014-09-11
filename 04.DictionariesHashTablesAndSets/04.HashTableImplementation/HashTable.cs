namespace _04.HashTableImplementation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<K, V> : IEnumerable<KeyValuePair<K, V>>
    {
        private const int InitialValuesSize = 16;

        private LinkedList<KeyValuePair<K, V>>[] table;

        public HashTable()
        {
            this.Clear();
        }

        public int Capacity 
        {
            get
            {
                return this.table.Length;
            }
        }

        public int Count { get; private set; }

        public IEnumerable<K> Keys
        {
            get
            {
                return this.table.Where(x => x != null).SelectMany(x => x).Select(x => x.Key);
            }
        }

        public V this[K key]
        {
            get
            {
                return this.Find(key);
            }

            set
            {
                this.Add(key, value);
            }
        }

        public void Add(K key, V value)
        {
            var hash = this.HashKey(key);
            if (this.table[hash] == null)
            {
                this.table[hash] = new LinkedList<KeyValuePair<K, V>>();
            }

            var alreadyHasKey = this.table[hash].Any(p => p.Key.Equals(key));
            if (alreadyHasKey)
            {
                throw new ArgumentException("Key already exists!");
            }

            var pair = new KeyValuePair<K, V>(key, value);
            this.table[hash].AddLast(pair);
            this.Count++;
            if (this.Count >= 0.75 * this.Capacity)
            {
                this.ResizeAndReaddValues();
            }
        }

        public bool Remove(K key)
        {
            int index = this.HashKey(key);

            if (this.table[index] == null)
            {
                // Key does not exist in the hash table.
                return false;
            }

            var chain = this.table[index];
            var pairsToRemove = this.table[index].Where(p => p.Key.Equals(key)).ToList();

            if (pairsToRemove.Count == 0)
            {
                // No values found that correspond to the given key
                return false;
            }

            foreach (var pair in pairsToRemove)
            {
                chain.Remove(pair);
                this.Count--;
            }

            return true;
        }

        public void Clear()
        {
            this.table = new LinkedList<KeyValuePair<K, V>>[InitialValuesSize];
            this.Count = 0;
        }

        public V Find(K key)
        {
            int index = this.HashKey(key);

            if (this.table[index] == null)
            {
                throw new KeyNotFoundException("Key not found!");
            }

            var chain = this.table[index];
            foreach (var pair in chain)
            {
                if (pair.Key.Equals(key))
                {
                    return pair.Value;
                }
            }

            throw new KeyNotFoundException("Key not found!");
        }

        public bool ContainsKey(K key)
        {
            var hash = this.HashKey(key);

            if (this.table[hash] == null)
            {
                return false;
            }

            var pairs = this.table[hash];
            return pairs.Any(pair => pair.Key.Equals(key));
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (var valueCollection in this.table)
            {
                if (valueCollection != null)
                {
                    foreach (var value in valueCollection)
                    {
                        yield return value;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void ResizeAndReaddValues()
        {
            ////cache old values
            var cachedValues = this.table;
            ////resize
            this.table = new LinkedList<KeyValuePair<K, V>>[2 * this.Capacity];

            this.Count = 0;

            foreach (var valueCollection in cachedValues)
            {
                if (valueCollection != null)
                {
                    foreach (var value in valueCollection)
                    {
                        this.Add(value.Key, value.Value);
                    }
                }
            }
        }

        private int HashKey(K key)
        {
            var hashKey = key.GetHashCode();
            hashKey %= this.Capacity;
            hashKey = Math.Abs(hashKey);
            return hashKey;
        }
    }
}
