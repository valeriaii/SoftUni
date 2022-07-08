using System;
using System.Linq;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int, int[], bool> isDivisible = isDivisibleByNumbers;

            for (int i = 1; i <= range; i++)
            {
                if (isDivisible(i,dividers)==true)
                {
                    Console.Write(i+" ");
                } 
            }

        }

        private static bool isDivisibleByNumbers(int number, int[] dividers)
        {
            bool isDivisible = true;
            for (int i = 0; i < dividers.Length; i++)
            {
                if (number%dividers[i]!=0)
                {
                    isDivisible = false;
                }
            }
            return isDivisible;
        }
    }
}
