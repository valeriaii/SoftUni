using System;

namespace _03.ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] inputArray = input.Split(new char[] { '.','\\' });
            Console.WriteLine($"File name: {inputArray[inputArray.Length-2]}");
            Console.WriteLine($"File extension: {inputArray[inputArray.Length-1]}");

        }
    }
}
