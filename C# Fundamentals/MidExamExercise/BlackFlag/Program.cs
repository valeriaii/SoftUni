using System;

namespace BlackFlag
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int plunderPerDay = int.Parse(Console.ReadLine());
            double target = double.Parse(Console.ReadLine());
            double currPlunder = 0;
            for (int i = 1; i <= days; i++)
            {
                currPlunder += plunderPerDay;
                if (i % 3 == 0)
                {
                    currPlunder += 0.5 * plunderPerDay;
                }
                if (i % 5 == 0)
                {
                    currPlunder -= 0.3 * currPlunder;
                }


            }

            if (currPlunder >= target)
            {
                Console.WriteLine($"Ahoy! {currPlunder:f2} plunder gained.");
            }
            else
            {
                double percentage =  (currPlunder / target) * 100.0;
                Console.WriteLine($"Collected only {percentage:f2}% of the plunder.");
            }

        }
    }
}
