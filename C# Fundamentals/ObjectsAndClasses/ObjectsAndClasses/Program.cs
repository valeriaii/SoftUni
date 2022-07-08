using System;

namespace ObjectsAndClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split();
            Random random = new Random();
            for (int i = 0; i < strings.Length; i++)
            {
                int swapPosition = random.Next(strings.Length);
                string temp = strings[i];
                strings[i] = strings[swapPosition];
                strings[swapPosition] = temp;
            }
        }
    }
}
