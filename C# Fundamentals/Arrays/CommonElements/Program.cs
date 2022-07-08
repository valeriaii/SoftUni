using System;

namespace CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] arrFirst = Console.ReadLine().Split(" ");
            string[] arrSecond = Console.ReadLine().Split(" ");
            foreach (string elementsTwo in arrSecond)
            {
                for (int i = 0; i < arrFirst.Length; i++)
                {
                    string elementOne = arrFirst[i];
                    if (elementsTwo == elementOne)
                    {
                        Console.Write(elementOne + " ");
                        break;
                    }
                }
            }


        }
    }
}
