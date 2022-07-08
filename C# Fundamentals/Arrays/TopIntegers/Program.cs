using System;
using System.Linq;

namespace TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < inputArr.Length; i++)
            {
                bool isCurrNumberBigger = true;
                for (int j = i+1; j < inputArr.Length; j++)//сравняваме предното със следващото
                {
                    if (inputArr[i] <= inputArr[j])
                    {
                        isCurrNumberBigger = false;
                    }
                }
                if (isCurrNumberBigger)
                {
                    Console.Write(inputArr[i]+" ");
                }
                
            }
        }
    }
}
