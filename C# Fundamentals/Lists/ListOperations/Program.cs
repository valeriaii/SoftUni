using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] cmd = command.Split();
                if (cmd[0] == "Add")
                {
                    list.Add(int.Parse(cmd[1]));
                }
                else if (cmd[0] == "Insert")
                {
                    int index = int.Parse(cmd[2]);
                    if (index < 0 || index >= list.Count)
                    {
                        Console.WriteLine("Invalid inddex");
                    }
                    else
                    {
                        list.Insert(index, int.Parse(cmd[1]));
                    }
                }
                else if (cmd[0] == "Remove")
                {
                    int index = int.Parse(cmd[2]);
                    if (index < 0 || index >= list.Count)
                    {
                        Console.WriteLine("Invalid inddex");
                    }
                    else
                    {
                        list.RemoveAt(index);
                    }

                }
                else if (cmd[1] == "left")
                {
                    int rotations = int.Parse(cmd[2]);

                    int temp = list[0];
                    list.RemoveAt(0);
                    list.Add(temp);
                    rotations--;
                }
            
                else if (cmd[1] == "right")
                {
                    int rotations = int.Parse(cmd[2]);
                     while (rotations != 0)
                        {
                        int temp = list[list.Count - 1];
                        list.RemoveAt(list.Count - 1);
                        list.Insert(0, temp);
                         rotations--;
                         }
                }
            command = Console.ReadLine();
            }
    
                Console.WriteLine(string.Join(" ",list));
            
           
        }
    }
}
