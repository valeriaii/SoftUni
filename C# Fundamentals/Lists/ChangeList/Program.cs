using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();
           

            while (command!="end")
            {
                 string[] cmdArg = command.Split();

                if(cmdArg[0] == "Delete")
                {
                    list.Remove(int.Parse(cmdArg[1]));
                }
                else 
                {
                    list.Insert(int.Parse(cmdArg[2]), int.Parse(cmdArg[1]));
                }


                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ",list));
        }
    }
}
