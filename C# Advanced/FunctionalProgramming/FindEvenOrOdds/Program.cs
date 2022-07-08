using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvenOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rangeNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string oddEven = Console.ReadLine(   );

            List<int> numbers = new List<int>();

            for (int i = rangeNumbers[0]; i <= rangeNumbers[1]; i++)
            {
                numbers.Add(i);
            }
            List<int> result = new List<int>();
            Predicate<int> isEven = x => x % 2 == 0;
            Predicate<int> isOdd = x => x % 2 != 0;
            if (oddEven == "even")
            {
                 result = numbers.FindAll(isEven);
                
            }
            else
            {
                result = numbers.FindAll(isOdd);
              
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
