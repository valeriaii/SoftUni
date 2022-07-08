using System;
using System.Collections.Generic;
using System.Linq;

namespace StacksAndQueues
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int toPush = inputNumbers[0];
            int toPop = inputNumbers[1];
            int specialNum = inputNumbers[2];

            int[] inputElements = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>();

           // Stack<int> stack = new Stack<int>(inputElements.Take(toPush));

            for (int i = 0; i < toPush; i++)
            {
                stack.Push(inputElements[i]);

            }
            for (int i = 0; i < toPop; i++)
            {
                stack.Pop();

            }
            if (stack.Contains(specialNum))
            {
                Console.WriteLine("true");
            }
            else if(stack.Count>0)
            {
                Console.WriteLine(stack.Min());
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}
