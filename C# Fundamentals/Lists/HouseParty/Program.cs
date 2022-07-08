using System;
using System.Collections.Generic;

namespace HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());//num of command
            List<string> guestList = new List<string> ();
            
            for (int i = 0; i < n; i++)
            {
                string command = Console.ReadLine();
                string[] cmdArg = command.Split();
                if (cmdArg.Length > 3)
                {
                    if (guestList.Contains(cmdArg[0]))
                    {
                        guestList.Remove(cmdArg[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{cmdArg[0]} is not in the list!");
                    }
                }
                else
                {
                    if (guestList.Contains(cmdArg[0]))
                    {
                        Console.WriteLine($"{cmdArg[0]} is already in the list!");
                    }
                    else
                    {
                        guestList.Add(cmdArg[0]);
                    }
                }
               
                     
            }
            for (int i = 0; i < guestList.Count; i++)
            {
                    Console.WriteLine(guestList[i]);
            }
            
            
        }
    }
}
