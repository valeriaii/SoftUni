using System;
using System.Linq;

namespace AppliedArithmetics2
{
    class Program
    {
        public static int[] inputIntegers;
        static void Main(string[] args)
        {
             inputIntegers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string operation = Console.ReadLine();

            Func<string, int[], int[]> manipulateNumbers = Manipulate;
            

            while (operation!="end")
            {

               inputIntegers = manipulateNumbers(operation, inputIntegers);
                operation = Console.ReadLine();
            }

        }

        private static int[] Manipulate(string command, int[] numbers)
        {
            switch (command)
            {
                case "add":
                    return numbers = numbers.Select(n => n + 1).ToArray();
                    
                case "multiply":
                    return numbers = numbers.Select(n => n * 2).ToArray();
                    
                case "subtract":
                    return numbers = numbers.Select(n => n - 1).ToArray();
                    
                case "print":
                    Console.WriteLine(string.Join(" ", numbers));
                    return numbers;
                    
                default:
                    break;
            }
            return null;
        }
    }
}
