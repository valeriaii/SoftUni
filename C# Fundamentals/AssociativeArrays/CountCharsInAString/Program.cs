using System;
using System.Collections.Generic;
using System.Linq;

namespace CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<char, int> charCount = new Dictionary<char, int>();

            char[] charArr = input.Where(ch=>!Char.IsWhiteSpace(ch)).ToArray();

            for (int i = 0; i < charArr.Length; i++)
            {
                if (!charCount.ContainsKey(charArr[i]))
                {
                    charCount.Add(charArr[i],0);
                }
                charCount[charArr[i]]++;
            }
            foreach (var ch in charCount)
            {
                Console.WriteLine($"{ch.Key} -> {ch.Value}");
            }
            
        }
    }
}
