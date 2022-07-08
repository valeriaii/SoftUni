using System;

namespace _02.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] words = input.Split();
            string string1 = words[0];
            string string2 = words[1];
            SumString(string1, string2);
        }

        static void SumString(string str1,string str2)
        {
            int shorter = str1.Length < str2.Length ? str1.Length : str2.Length;

            int sum = 0;
            for (int i = 0; i < shorter; i++)
            {
                sum += str1[i] * str2[i];
            }
            if(shorter == str1.Length)
            {
                for (int i = shorter; i < str2.Length; i++)
                {
                    sum += str2[i];
                }
            }
            else
            {
                for (int i = shorter - 1; i < str1.Length; i++)
                {
                    sum += str1[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
