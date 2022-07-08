using System;
using System.Collections.Generic;

namespace UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> setUsernames = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (!setUsernames.Contains(input))
                {
                    setUsernames.Add(input);
                }

            }
            foreach (var item in setUsernames)
            {
                Console.WriteLine(item);
            }
        }
    }
}
