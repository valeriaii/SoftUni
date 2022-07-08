using System;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputNames = Console.ReadLine().Split();
            PrintNames(inputNames, x => Console.WriteLine(x));
           // Action<string[]> printNames = inputNames => Console.WriteLine("Sir "string.Join(Environment.NewLine + "Sir ", inputNames));
        }
        public static void PrintNames(string[] names, Action<string> print)
        {
            foreach (var name in names)
            {
                Console.Write("Sir " ); 
                print(name);
            }
        }
    }
}
