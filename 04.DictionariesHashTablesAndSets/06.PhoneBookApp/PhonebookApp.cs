namespace _06.PhoneBookApp
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class PhonebookApp
    {
        private const string START = "************* COMMAND START *****************";
        private const string END = "************* COMMAND END *****************";
        /*
         * A text file phones.txt holds information about people, their town and phone number.
         * Duplicates can occur in people names, towns and phone numbers. 
         * Write a program to read the phones file and execute a sequence of commands given in the file commands.txt:
         *  find(name) – display all matching records by given name (first, middle, last or nickname)
         *  find(name, town) – display all matching records by given name and town        */
        public static void Main(string[] args)
        {
            //// GET PHONEBOOK ENTRIES
            var phonebook = new Phonebook();
            using (var reader = new StreamReader("../../input.entries.00.in.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    ProcessInput(phonebook, line);
                    line = reader.ReadLine();
                }
            }

            ////GET COMMANDS
            var commands = new List<string>();
            using (var reader = new StreamReader("../../input.commands.00.in.txt"))
            {
                var line = reader.ReadLine();
                
                while (line != null)
                {
                    commands.Add(line);
                    line = reader.ReadLine();
                }
            }

            ////PROCESS COMMANDS
            ProcessCommands(commands, phonebook);
        }

        private static void ProcessCommands(IEnumerable<string> commands, Phonebook phonebook)
        {
            foreach (var command in commands)
            {
                Console.WriteLine(START);
                Console.WriteLine("Command to execute: " + command);
                var args = command.Substring(5, command.Length - 6);
                var searchTerms = args.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    var entries = phonebook.Find(searchTerms);
                    Console.WriteLine(string.Join("\n", entries));
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Command failed: {0}!", args);
                }

                Console.WriteLine(END);
            }
        }

        private static void ProcessInput(Phonebook phonebook, string line)
        {
            var input = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            phonebook.Add(new PhonebookEntry(input[0].Trim(), input[1].Trim(), input[2].Trim()));
        }
    }
}
