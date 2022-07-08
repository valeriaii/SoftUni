using System;
using System.Linq;

namespace EqualSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int leftSum =0 , rightSum = 0;

            for (int i = 0; i <= numbers.Length -1; i++)
            {
                if (numbers.Length == 1)
                {
                    Console.WriteLine(0);
                    return;
                }
                //leftsum
                leftSum = 0;
                for (int sumLeft = i; sumLeft >0 ; sumLeft--)
                {
                    int nextEl = sumLeft - 1;
                    if (sumLeft>0)
                    {
                        leftSum += numbers[nextEl];
                    }
                }
                //rightSum
                rightSum = 0;
                for (int j= i; j < numbers.Length; j++)
                {
                    int nextEl = j+1 ;
                    if (j<numbers.Length -1)
                    {
                        rightSum += numbers[nextEl];
                    }
                }
                if(rightSum == leftSum)
                {
                    Console.WriteLine(i);
                    return;
                }

            }
            Console.WriteLine("no");
        }
    }
}
