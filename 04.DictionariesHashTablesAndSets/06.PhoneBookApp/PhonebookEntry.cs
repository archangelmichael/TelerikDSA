namespace _06.PhoneBookApp
{
    using System;

    public class PhonebookEntry
    {
        private string name;
        private string town;
        private string phone;

        public PhonebookEntry(string name, string town, string phone)
        {
            this.Name = name;
            this.Town = town;
            this.Phone = phone;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Person name cannot be empty!");
                }

                this.name = value;
            }
        }

        public string Town
        {
            get
            {
                return this.town;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Town name cannot be empty!");
                }

                this.town = value;
            }
        }

        public string Phone
        {
            get
            {
                return this.phone;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Phone number name cannot be empty!");
                }

                this.phone = value;
            }
        }

        public override string ToString()
        {
            return this.Name.PadRight(30) + " | " + this.Town.PadRight(14) + " | " + this.Phone.PadRight(14);
        }
    }
}
