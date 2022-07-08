using System;

namespace Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            //if (capacity > numberOfPeople)
            //{
            //    Console.WriteLine("All the persons fit inside in the elevator.\nOnly one course is needed.");
            //}
            //else
            //{
            //int numFullCourses = (int)(numberOfPeople / capacity);
            int totalCourses = (int)Math.Ceiling((double)numberOfPeople / capacity);

                Console.WriteLine(totalCourses);
            //}
        }
    }
}
