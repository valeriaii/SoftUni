using System;

namespace DataModifier
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            int result = DataModifier.CalculateDifference(firstDate, secondDate);
            Console.WriteLine(result);
        }
    }
}
