using System;
using System.Linq;

namespace MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int count = 0;
            int start = 0;
            int max = 0;
           

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == input[i + 1])
                {
                    count++;
                    if (count > max)
                    {
                        start = i - count; //1-1=0
                        max = count;//макс=1
                       
                    }
                }
                else
                {
                    count = 0;
                }
            }
            //1 1 1 2 3 1 3 3
            for (int i = start +1; i <=start+ max+1; i++)
            {
                Console.Write($"{input[i]} " );
            }

        }
    }
}
