using System;
using System.Collections.Generic;
using System.Linq;

namespace BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int[] bomb = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
           
            int specialN = bomb[0];
            int power = bomb[1];
            
            int elementIndex = numbers.IndexOf(specialN) - power;
            int numOfDeleteOp = power * 2;
            numbers.Remove(specialN);
            while(numOfDeleteOp!=0)
            {
                if (elementIndex >= 0 && elementIndex <= numbers.Count - 1)
                {
                    numbers.RemoveAt(elementIndex);
                    numOfDeleteOp--;
                }
                else
                {
                    break;
                }
                
            }

            Console.WriteLine(numbers.Sum());
            //if (numbers.Contains(specialN))
            //{
            //    // int index = numbers.IndexOf(specialN); 
            //    int index = numbers.IndexOf(specialN);
            //    int newIndex = index - power;
            //    int cPower = power;
            //    numbers.Remove(specialN);
            //    while (power >0 || cPower > 0)
            //    {

            //        if (index > 0 && index <= numbers.Count - 1)
            //        {
            //            numbers.RemoveAt(index);
            //            power--;
            //        }
            //        else
            //        {
            //            power--;
            //        }
            //        if (newIndex >= 0 && newIndex <= numbers.Count - 1)
            //        {
            //            numbers.RemoveAt(newIndex);
            //            cPower--;
            //        }
            //        else
            //        {
            //            cPower--;
            //        }


            //    }

            //}



        }
    }
}
