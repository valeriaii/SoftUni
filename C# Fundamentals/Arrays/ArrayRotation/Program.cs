using System;
using System.Linq;

namespace ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());

            for (int rotattion = 0; rotattion < rotations; rotattion++)
            {
                int temp = arr[0];
                for (int operations = 0; operations < arr.Length-1; operations++)//с -1 бутаме масива наляво
                {
                    arr[operations] = arr[operations + 1];

                }
                arr[arr.Length - 1] = temp;//първото става последно
            }
            Console.WriteLine(String.Join(" ",arr));

        }
    }
}
