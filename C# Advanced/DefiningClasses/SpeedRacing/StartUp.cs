using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionPerKm = double.Parse(input[2]);
                Car car = new Car(model, fuelAmount, fuelConsumptionPerKm);
                cars.Add(car);

            }

            string command = Console.ReadLine();
            while (command!="End")
            {
                string[] cmd = command.Split();
                string model = cmd[1];
                double amountOfKm = double.Parse(cmd[2]);

                Car carForDriving = cars
                        .Where(x => x.Model == model)
                        .ToList()
                        .First();

                carForDriving.MoveDistance(model, amountOfKm);
                command = Console.ReadLine();
            }
            foreach (var item in cars)
            {
                Console.WriteLine($"{ item.Model} { item.FuelAmount:F2} {item.TravelledDistance}");
            }
        }
    }
}
