using System;

namespace _06.ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine( );
            string result = String.Empty;
            char prevChar = input[0];
            Console.Write(prevChar);
            for (int i = 1; i < input.Length;  i++)
            {
                char currChar = input[i];
                if (prevChar!=currChar)
                {
                    prevChar= currChar;
                    Console.Write(prevChar);
                }
            }

            
        }
    }
}
