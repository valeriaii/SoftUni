using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputClothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());
            int numOfRacks = 1;
            int sumOfClothes = 0;

            Stack<int> stack = new Stack<int>(inputClothes);

            while (stack.Count > 0 )
            { 
                sumOfClothes += stack.Peek();
                if (sumOfClothes <= rackCapacity)
                {
                    stack.Pop();
                }
                else
                {
                    numOfRacks++;
                    sumOfClothes = 0;
                }
            }
            Console.WriteLine(numOfRacks);
        }
    }
}
