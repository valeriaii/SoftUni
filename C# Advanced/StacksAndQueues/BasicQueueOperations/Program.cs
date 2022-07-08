using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int toEnqueue = inputNumbers[0];
            int toDequeue = inputNumbers[1];
            int specialNum = inputNumbers[2];

            int[] inputElements = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>();

            // Stack<int> stack = new Stack<int>(inputElements.Take(toPush));

            for (int i = 0; i < toEnqueue; i++)
            {
                queue.Enqueue(inputElements[i]);

            }
            for (int i = 0; i < toDequeue; i++)
            {
                queue.Dequeue();

            }
            if (queue.Contains(specialNum))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count > 0)
            {
                Console.WriteLine(queue.Min());
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}
