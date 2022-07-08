using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberWagons = int.Parse(Console.ReadLine());
            int[] peopleInWagon = new int[numberWagons];
            int allPeople = 0;

            for (int i = 0; i < numberWagons; i++)
            {
                peopleInWagon[i] = int.Parse(Console.ReadLine());
               // Console.Write($"{peopleInWagon[i]} ");
                allPeople += peopleInWagon[i];

            }
            foreach (int number in peopleInWagon)
            {
                Console.WriteLine(number + ' ' );
            }
            Console.WriteLine($"\n{allPeople}");
        }
    }
}
