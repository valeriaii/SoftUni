using System;
using System.Linq;

namespace ZigZagArr
{
    class Program
    {
        static void Main(string[] args)
        {
            int nLines = int.Parse(Console.ReadLine());
            int[] evenArr = new int[nLines];
            int[] oddArr = new int[nLines];

            for (int i = 0; i < nLines; i++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if(i%2==0)
                {
                    evenArr[i] = numbers[0];
                    oddArr[i] = numbers[1];
                }
                else
                {
                    evenArr[i] = numbers[1];
                    oddArr[i] = numbers[0];
                }
            }
            Console.WriteLine(String.Join(" ", evenArr));
            Console.WriteLine(String.Join(" ", oddArr));
        }
    }
}
