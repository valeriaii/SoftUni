using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            List<string> names = new List<string>(Console.ReadLine().Split().ToList());

            Predicate<string> nameLength = x => x.Length <= length;

            names = names.FindAll(nameLength);
            Console.WriteLine(string.Join(Environment.NewLine, names));

            
        }
    }
}
