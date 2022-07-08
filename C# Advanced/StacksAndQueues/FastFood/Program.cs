using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalQuantity = int.Parse(Console.ReadLine());

            int[] inpuOrders = Console.ReadLine().Split().Select(int.Parse).ToArray();

            
            Queue<int> queueOfOrders = new Queue<int>(inpuOrders);
            Console.WriteLine(queueOfOrders.Max());

            while(queueOfOrders.Count>0&& totalQuantity >= 0)
            {
                int currentOrder = queueOfOrders.Peek();

                if (totalQuantity -currentOrder<0)
                {
                    break;
                }

                totalQuantity -= currentOrder;
                queueOfOrders.Dequeue();
            }

            if (queueOfOrders.Count>0)
            {
                Console.WriteLine($"Orders left: {string.Join(" ",queueOfOrders)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
