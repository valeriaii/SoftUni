﻿using System;
using System.Collections.Generic;

namespace PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> chemicalElements = new SortedSet<string>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                for (int j = 0; j < input.Length; j++)
                {
                    if (!chemicalElements.Contains(input[j]))
                    {
                        chemicalElements.Add(input[j]);
                    }
                }

            }
            Console.WriteLine(string.Join(" ", chemicalElements));
        }
    }
}
