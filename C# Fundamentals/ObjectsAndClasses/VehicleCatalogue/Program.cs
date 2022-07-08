using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace VehicleCatalogue
{
    class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }

        public Vehicle(string typeOfVehicle, string modelOfVehicle, string colorOfVehicle, int horsepowerOfVehicle)
        {
            Type = typeOfVehicle;
            Model = modelOfVehicle;
            Color = colorOfVehicle;
            Horsepower = horsepowerOfVehicle;
        }

        public override string ToString()
        {
            return $"Type: {Type}\nModel: {Model}\nColor: {Color}\nHorsepower: {Horsepower}";
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Vehicle> vehicles = new List<Vehicle>();
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
            while (input != "End")
            {


                string[] vehicleInfo = input.Split();
              
                Vehicle vehicle = new Vehicle(
                    myTI.ToTitleCase(vehicleInfo[0]),
                    vehicleInfo[1],
                    vehicleInfo[2],
                    int.Parse(vehicleInfo[3]));

                vehicles.Add(vehicle);


                input = Console.ReadLine();

            }

            

            while (true)

            {
            
                input = Console.ReadLine();
                if (input == "Close the Catalogue")
                {
                    int sumHorsepowerCars = 0;
                    int sumHorsepowerTrucks = 0;
                    int numOfCars = 0;
                    int numOfTrucks = 0;
                    foreach (Vehicle car in vehicles.Where(x => x.Type == "Car"))
                    {
                        numOfCars++;
                        sumHorsepowerCars += car.Horsepower;
                    }

                    foreach (Vehicle truck in vehicles.Where(x => x.Type == "Truck"))
                    {
                        numOfTrucks++;
                        sumHorsepowerTrucks += truck.Horsepower;
                    }
                    if (numOfCars!=0 && numOfTrucks!=0)
                    {
                        Console.WriteLine($"Cars have average horsepower of: {((float)sumHorsepowerCars / (float)numOfCars):f2}.");
                        Console.WriteLine($"Trucks have average horsepower of: {((float)sumHorsepowerTrucks / (float)numOfTrucks):f2}.");
                   }
                    
                    return;
                }
                foreach (Vehicle vehicle in vehicles.Where(x => x.Model == input))
                {
                    Console.WriteLine(vehicle);
                }
            }
        }
    }
}
