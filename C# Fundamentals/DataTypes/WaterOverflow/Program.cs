using System;

namespace WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
           int nLines = int.Parse(Console.ReadLine());
            int litersInTank = 0;
            for (int i = 0; i < nLines; i++)
            {
                //if (litersInTank > 255)
                //{
                //    Console.WriteLine("Insufficient capacity!");
                //}
                //else
                //{
                    int litersWater = int.Parse(Console.ReadLine());
                    
                    if (litersWater + litersInTank > 255)
                    {
                        Console.WriteLine("Insufficient capacity!");
                    }
                      else
                {
                    litersInTank += litersWater;
                }
               // }
            }
            Console.WriteLine(litersInTank);
            
           
        }
    }
}
