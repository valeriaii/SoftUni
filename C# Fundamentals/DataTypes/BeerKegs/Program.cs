using System;

namespace BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int nLines = int.Parse(Console.ReadLine());

            double biggestKeg = 0;
            string kegModel = string.Empty;
            for (int i = 0; i < nLines; i++)
            {
                string model = Console.ReadLine();
                float radius = float.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = (Math.PI * radius * radius * height);

                if (volume> biggestKeg)
                {
                    biggestKeg = volume;
                    kegModel = model;
                }

            }
            Console.WriteLine(kegModel);
          


        }
    }
}
