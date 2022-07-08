using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>(Console.ReadLine().Split().ToList());


            string command = Console.ReadLine();

            Dictionary<string, Predicate<string>> allFilters = new Dictionary<string, Predicate<string>>();


            while (command != "Print")
            {
                string[] cmd = command.Split(";");
                string operation = cmd[0];
                string criteria = cmd[1];
                string value = cmd[2];

                if (operation == "Add filter")
                {
                    allFilters.Add(criteria + value, GetPredicate(criteria, value));
                }
                else
                {
                    allFilters.Remove(criteria + value);
                }

                command = Console.ReadLine();

            }
            foreach (var (key, value) in allFilters)
            {
                names.RemoveAll(value);
            }

            Console.WriteLine(string.Join(" ", names));
        }
        private static Predicate<string> GetPredicate(string criteria, string value)
        {
            if (criteria == "Starts with")
            {
                return x => x.StartsWith(value);
            }
            if (criteria == "Ends with")
            {
                return x => x.EndsWith(value);
            }
            if (criteria == "Contains")
            {
                return x => x.Contains(value);
            }
            // if (criteria == "Length")
            //{
            int valueAsInt = int.Parse(value);
            return x => x.Length == valueAsInt;
            //}
            //return null;
        }
    }
}

