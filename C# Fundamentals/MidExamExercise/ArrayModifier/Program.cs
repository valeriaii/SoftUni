using System;
using System.Linq;

namespace ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();
            string command = Console.ReadLine();
           

            while (command != "end")
            { 
                string[] cmdArg = command.Split();
                if (cmdArg[0] =="swap")
                {
                    Swap(arr, int.Parse(cmdArg[1]), int.Parse(cmdArg[2]));
                }else if (cmdArg[0] == "multiply")
                {
                    Multiply(arr, int.Parse(cmdArg[1]), int.Parse(cmdArg[2]));
                }
                else if (cmdArg[0] == "decrease")
                {
                    Decrease(arr);
                }


                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ",arr));
        }
        static void Swap(int[] arr,int ind1, int ind2)
        {
            
            int temp = arr[ind1];
            arr[ind1] = arr[ind2];
            arr[ind2] = temp;
            
        }
        static void Multiply(int[] arr, int ind1, int ind2)
        {
            arr[ind1] = arr[ind1] * arr[ind2];
        }

        static void Decrease(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i]--;
            }
        }
    }
}
