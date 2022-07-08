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
            while (command != "Party!")
            {
                string[] cmd = command.Split();
                string operation = cmd[0];
                string criteria = cmd[1];
                string value = cmd[2];
                if (operation == "Double")
                {
                    List<string> doubleNames = names.FindAll(GetPredicate(criteria, value)); //if the list is empty FindIndex returns -1, no such index
                    if (doubleNames.Any())
                    {
                        int index = names.FindIndex(GetPredicate(criteria, value));
                        names.InsertRange(index, doubleNames);
                    }


                }
                else if (operation == "Remove")
                {
                    names.RemoveAll(GetPredicate(criteria, value));
                }
                command = Console.ReadLine();
            }
            if (names.Any())
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }

        }

        private static Predicate<string> GetPredicate(string criteria, string value)
        {
            if (criteria == "StartsWith")
            {
                return x => x.StartsWith(value);
            }
            if (criteria == "EndsWith")
            {
                return x => x.EndsWith(value);
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
