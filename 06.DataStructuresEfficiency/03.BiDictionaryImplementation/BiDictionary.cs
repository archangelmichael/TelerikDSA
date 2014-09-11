namespace _03.BiDictionaryImplementation
{
    using System.Linq;
    using Wintellect.PowerCollections;

    /// <summary>
    /// Implemented by 3 Multidictionaries keeping different key->value combinations
    /// with no duplicate values allowed
    /// </summary>
    /// <typeparam name="K1"> first key </typeparam>
    /// <typeparam name="K2"> secont key </typeparam>
    /// <typeparam name="V"> value </typeparam>
    public class BiDictionary<K1, K2, V>
    {
        private MultiDictionary<K1, V> firstKeyDictionary;
        private MultiDictionary<K2, V> secondKeyDictionary;
        private MultiDictionary<int, V> valueDictionary;

        public BiDictionary()
        {
            this.firstKeyDictionary = new MultiDictionary<K1, V>(true);
            this.secondKeyDictionary = new MultiDictionary<K2, V>(true);
            this.valueDictionary = new MultiDictionary<int, V>(true);
        }

        public void Add(K1 firstKey, K2 secondKey, V value)
        {
            this.firstKeyDictionary.Add(firstKey, value);
            this.secondKeyDictionary.Add(secondKey, value);
            var keysHashValue = this.GetBothKeysHashValue(firstKey, secondKey);
            this.valueDictionary.Add(keysHashValue, value);
        }

        public V[] FindByFirstKey(K1 firstKey)
        {
            return this.firstKeyDictionary[firstKey].ToArray();
        }

        public V[] FindBySecondKey(K2 secondKey)
        {
            return this.secondKeyDictionary[secondKey].ToArray();
        }

        public V[] FindByBothKeys(K1 firstKey, K2 secondKey)
        {
            var hash = this.GetBothKeysHashValue(firstKey, secondKey);
            return this.valueDictionary[hash].ToArray();
        }

        private int GetBothKeysHashValue(K1 firstKey, K2 secondKey)
        {
            return firstKey.GetHashCode() ^ secondKey.GetHashCode();
        }
    }
}
