using System;
using System.Linq;

namespace TheLift
{
    class Program
    {
        static void Main(string[] args)
        {
            int waitingP = int.Parse(Console.ReadLine());
            int[] currState = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            bool isThereEmpty = true;


            for (int i = 0; i < currState.Length; i++)
            {

                while (currState[i] != 4)
                {
                    waitingP--;
                    if (waitingP < 0)
                    {
                        waitingP = 0;
                        break;
                    }

                    currState[i]++;
                }
                if (waitingP == 0)
                {
                    break;
                }
            }




            if (currState[currState.Length - 1] == 4)
            {

                isThereEmpty = false;
            }


            if (isThereEmpty)
            {
                Console.WriteLine("The lift has empty spots!\n" + string.Join(" ", currState));
            }
            else if (!isThereEmpty)
            {
                if (waitingP > 0)
                {
                    Console.WriteLine($"There isn't enough space! {waitingP} people in a queue!\n" + string.Join(" ", currState));
                }
            }
            else
            {
                Console.WriteLine(string.Join(" ", currState));
            }



        }
    }
}
