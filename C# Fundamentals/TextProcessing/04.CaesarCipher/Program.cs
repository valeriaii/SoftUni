﻿using System;

namespace _04.CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string cipher = String.Empty;
            for (int i = 0; i < text.Length; i++)
            {
                char letter = text[i];
                letter +=(char) 3;
                cipher += letter;

            }
            Console.WriteLine(cipher);
        }
    }
}
