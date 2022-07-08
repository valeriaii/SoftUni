using System;
using System.Linq;

namespace CustomMinFunc
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> getMinNumbers = numbers => numbers.Min();

            int[] inputIntegers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Console.WriteLine(getMinNumbers(inputIntegers));

        }
    }
}
