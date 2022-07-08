using System;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace _05.MultiplyBignumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input =Console.ReadLine();
            
            int multiplier = int.Parse(Console.ReadLine());

            StringBuilder finalResult = new StringBuilder();

            int rest = 0;

            if (input =="0" || multiplier==0)
            {
                Console.WriteLine(0);
                return;
            }
            for (int i = input.Length-1; i >=0; i--)
            {
                int currDigit = int.Parse(input[i].ToString());

                int product = currDigit * multiplier + rest;

                 int result = product % 10;
                rest = product / 10;
                finalResult.Insert(0,result);//add in the begining
            }
            if (rest > 0)
            {
                finalResult.Insert(0, rest);
            }
            Console.WriteLine(finalResult);

        }
    }
}
