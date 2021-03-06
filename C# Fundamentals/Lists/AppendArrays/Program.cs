using System;
using System.Collections.Generic;
using System.Linq;

namespace AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine()
                .Split("|")
                .ToList();

            items.Reverse();
            List<string> result = new List<string>();
            foreach (string currItem in items)
            {
                string[] numbers = currItem
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();
                foreach (string numToAdd in numbers)
                {
                    result.Add(numToAdd);
                }
            }
            Console.WriteLine(string.Join(" ",result));
            
        }
    }
}
