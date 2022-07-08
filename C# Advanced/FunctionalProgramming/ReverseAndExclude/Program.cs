using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int divider = int.Parse(Console.ReadLine());
            Predicate<int> isDivisible = x => x % divider == 0;

            numbers.Reverse();
             numbers.RemoveAll(isDivisible);
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
