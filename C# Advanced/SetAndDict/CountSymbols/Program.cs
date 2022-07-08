using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            SortedDictionary<char, int> symbolOccurrences = new SortedDictionary<char, int>();

            foreach (var symbol in text)
            {
                if (!symbolOccurrences.ContainsKey(symbol))
                {
                    symbolOccurrences.Add(symbol, 0);

                }

                symbolOccurrences[symbol]++;
            }

            foreach (var occurrence in symbolOccurrences)
            {
                Console.WriteLine($"{occurrence.Key}: {occurrence.Value} time/s");
            }
        }
    }
}
