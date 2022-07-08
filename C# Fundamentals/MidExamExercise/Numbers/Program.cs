using System;
using System.Linq;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            double average = Average(numbers);


            if (numbers.Length == 1)
            {
                Console.WriteLine("No");
                return;
            }
            int[] biggerThanAvg = BiggerThanAvg(numbers, average);
            
            Array.Sort(biggerThanAvg);
            Array.Reverse(biggerThanAvg);
            
            if (biggerThanAvg.Length > 5)
            {
                int[] toPrint = new int[5];
                for (int i = 0; i < 5; i++)
                {
                    
                    toPrint[i] = biggerThanAvg[i];
                   
                }
                Console.WriteLine(string.Join(" ", toPrint));
            }
            else
            {
                Console.WriteLine(string.Join(" ", biggerThanAvg));

            }







        }
        static double Average(int[] arr)
        {
            int sum = 0;
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
                count++;
            }
            double average = sum / count;
            return average;
        }

        static int[] BiggerThanAvg(int[] arr,double avg)
        {
           
            int j = 0;
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > avg)
                {
                    count++;
                }
            }
                int[] newArr = new int[count];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > avg)
                {
                    newArr[j]=arr[i];
                    j++;
                }
            }
            return newArr;
        }
        
    }
}
