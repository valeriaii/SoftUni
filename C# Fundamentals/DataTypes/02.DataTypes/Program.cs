using System;

namespace _02.DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstInt = int.Parse(Console.ReadLine());
            int secondInt = int.Parse(Console.ReadLine());
            int thirdInt = int.Parse(Console.ReadLine());
            int fourthInt = int.Parse(Console.ReadLine());

            Console.WriteLine(((firstInt+secondInt)/thirdInt)*fourthInt);
        }
    }
}
