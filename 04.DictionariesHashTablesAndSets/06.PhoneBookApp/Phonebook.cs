namespace _06.PhoneBookApp
{
    using System.Collections.Generic;

    public class Phonebook
    {
        private IDictionary<string, List<PhonebookEntry>> phonebook;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Phonebook()
        {
            this.phonebook = new Dictionary<string, List<PhonebookEntry>>();
        }

        /// <summary>
        /// Constructor with given phonebook entries
        /// </summary>
        /// <param name="phonebookEntries"> given set of phonebook entries </param>
        public Phonebook(IEnumerable<PhonebookEntry> phonebookEntries)
            : this()
        {
            foreach (var entry in phonebookEntries)
            {
                this.Add(entry);
            }
        }

        /// <summary>
        /// Adds all names and all their combinations with townto the phonebook
        /// </summary>
        /// <param name="entry"> the phonebook entry information </param>
        public void Add(PhonebookEntry entry)
        {
            var names = entry.Name.Split(' ');
            foreach (var name in names)
            {
                this.AddEntry(name, entry);
                this.AddEntry(name + ' ' + entry.Town, entry);
            }
        }

        /// <summary>
        /// Looks for entries satisfying given query search
        /// </summary>
        /// <param name="searchTerms"> the parameters witch will be user to search for and entry </param>
        /// <returns> a list of all entries satisfying the search pattern formed from the parameters </returns>
        public IList<PhonebookEntry> Find(params string[] searchTerms)
        {
            var query = string.Join(" ", searchTerms);
            return this.phonebook[query];
        }

        /// <summary>
        /// Add new entry if it does not exsist
        /// </summary>
        /// <param name="key"> the key value to look for </param>
        /// <param name="entry"> the value, which will be added to the phonebook by given key </param>
        private void AddEntry(string key, PhonebookEntry entry)
        {
            if (!this.phonebook.ContainsKey(key))
            {
                this.phonebook[key] = new List<PhonebookEntry>();
            }

            this.phonebook[key].Add(entry);
        }
    }
}
