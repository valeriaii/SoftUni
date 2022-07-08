using System;
using System.Linq;

namespace MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rooms = Console.ReadLine().Split('|').ToArray();
           

            int initHealth = 100;
            int initBitcoins = 0;
            

            for(int i =0; i<rooms.Length;i++)
            {
                
                
                string[] cmd = rooms[i].Split();

                string command = cmd[0];
                int num = int.Parse(cmd[1]);

                if (command == "potion")
                {
                    if (initHealth < 100)
                    {
                        initHealth += num;
                        if (initHealth >= 100)
                        {

                            Console.WriteLine($"You healed for {initHealth - 100} hp.");
                            initHealth = 100;
                        }
                       
                        Console.WriteLine($"Current health: {initHealth} hp.");
                    }
                    else
                    {
                        Console.WriteLine($"You healed for {num} hp.");
                        Console.WriteLine($"Current health: {initHealth} hp.");
                    }
                }
                else if(command == "chest")
                {
                    initBitcoins += num;
                    Console.WriteLine($"You found {initBitcoins} bitcoins.");

                }
                else
                {
                    initHealth -= num;
                    if (initHealth>0)
                    {
                        Console.WriteLine($"You slayed {command}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {command}.\nBest room: {i+1}");
                    }

                }
              
            }




        }
    }
}
