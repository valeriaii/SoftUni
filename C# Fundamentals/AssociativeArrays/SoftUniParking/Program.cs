using System;
using System.Collections.Generic;

namespace SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfLines = int.Parse(Console.ReadLine());
            Dictionary<string, string> parking = new Dictionary<string, string>();
            
            for (int i = 0; i < numOfLines; i++)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];
                string user = input[1];
                if (command == "register")
                {
                   
                    string licensePlateNumber = input[2];
                    if (!parking.ContainsKey(user))
                    {
                        parking.Add(user, licensePlateNumber);
                        Console.WriteLine($"{user} registered {licensePlateNumber} successfully");
                    }
                    else
                    {
                        if (parking.ContainsValue(parking[user]))
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                        }
                    }
                }
                else if (command=="unregister")
                {
                    if (!parking.ContainsKey(user))
                    {
                        Console.WriteLine($"ERROR: user {user} not found");
                    }
                    else
                    {
                        parking.Remove(user);
                        Console.WriteLine($"{user} unregistered successfully");
                    }
                }
            }

            foreach (var user in parking)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
