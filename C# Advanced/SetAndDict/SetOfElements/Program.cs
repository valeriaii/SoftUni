using System;
using System.Collections.Generic;
using System.Linq;

namespace SetOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = input[0];
            int m = input[1];
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();
            HashSet<int> repeatedElements = new HashSet<int>();

            FillSet(firstSet,n);
            FillSet(secondSet, m);

            foreach (var item in firstSet)
            {
                if (secondSet.Contains(item))
                {
                    repeatedElements.Add(item);
                }
            }
           
           
                Console.Write(string.Join(" ", repeatedElements));
            
        }

        private static HashSet<int> FillSet(HashSet<int> set, int length)
        {
            for (int i = 0; i < length; i++)
            {
                set.Add(int.Parse(Console.ReadLine()));
            }
            return set;
        }
    }
}
