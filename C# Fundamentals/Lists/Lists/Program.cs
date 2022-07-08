using System;
using System.Collections.Generic;
using System.Linq;

namespace Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            
                List<int> peopleInWagons = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToList(); ;
            int maxCapacity = int.Parse(Console.ReadLine());
            string command = Console.ReadLine(); 
            while (command !="end")
            {
                string[] cmdArg = command.Split();//array
                if (cmdArg[0]=="Add")
                {
                    
                    peopleInWagons.Add(int.Parse(cmdArg[1]));//string to int
                }
                else
                {
                    int passengers = int.Parse(cmdArg[0]);
                    for (int i = 0; i < peopleInWagons.Count; i++)
                    {
                        int currWagon = peopleInWagons[i];
                        bool isEnoughSpace = currWagon + passengers <= maxCapacity;
                        if (isEnoughSpace)
                        {
                            peopleInWagons[i] += passengers;
                            break;
                        }
                    }
                }
                command = Console.ReadLine();

            }
            Console.WriteLine(string.Join(" ",peopleInWagons));
            
        }
    }
}
