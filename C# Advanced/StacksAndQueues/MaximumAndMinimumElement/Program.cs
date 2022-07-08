using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
          

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                int cmd = int.Parse(input[0]);
                if (cmd==1)
                {
                    int element = int.Parse(input[1]);
                    stack.Push(element);
                }
                else if (cmd ==2)
                {
                    stack.Pop();
                }
                else if (stack.Count>0)
                {
                    if (cmd==3)
                    {
                        Console.WriteLine(stack.Max());
                    }
                    else if (cmd==4)
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }
            Console.WriteLine(String.Join(", ", stack.ToArray()));
          
        }
    }
}
