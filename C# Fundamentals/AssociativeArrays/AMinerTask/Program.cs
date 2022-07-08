using System;
using System.Collections.Generic;

namespace AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resourcesQuantity = new Dictionary<string, int>();
            string input = Console.ReadLine();

            while(input!="stop")
            {
                string resource = input;
                int quantity = int.Parse(Console.ReadLine());

                if (!resourcesQuantity.ContainsKey(resource))
                {
                    resourcesQuantity[resource] = quantity;
                }
                else
                {
                    resourcesQuantity[resource] += quantity;
                }
                input = Console.ReadLine();
            }
            foreach (var resource in resourcesQuantity)
            {
                Console.WriteLine($"{resource.Key} -> {resourcesQuantity[resource.Key]}");
            }
        }
    }
}
