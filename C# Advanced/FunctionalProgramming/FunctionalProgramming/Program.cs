using System;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputNames = Console.ReadLine().Split();
           
            Action<string[]> printNames = inputNames => Console.WriteLine(string.Join(Environment.NewLine,inputNames));
            printNames(inputNames);
        }
       
    }
}
