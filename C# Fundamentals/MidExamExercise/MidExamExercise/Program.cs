using System;

namespace MidExamExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            int numStudents = int.Parse(Console.ReadLine());
            int hours = 0;
            int sum = first + second + third;
            
            int studentsLeft = numStudents;

            while (numStudents != 0)
            {
               if (hours % 4 == 0)
                {
                    hours++;

                } 
                else if (sum < numStudents)
                {
                    numStudents -= sum;
                    hours++;

                }
                else if(numStudents<sum)
                {
                    numStudents = 0;
                    hours++;
                }
                
                else
                {
                    hours++;
                    break;
                }
                
                
               
            }
            Console.WriteLine($"Time needed: {hours-1}h.");


        
        }
    }
}
