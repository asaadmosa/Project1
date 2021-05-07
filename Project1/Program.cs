using Project1.Entities;
using Project1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
           const string carPath = @"C:\Users\user\source\repos\Project1\Project1\Resources\Cars.csv";
           const string manufacturerPath = @"C:\Users\user\source\repos\Project1\Project1\Resources\Manufacturers.csv";
           IEnumerable<Car> cars = DataReader.GetAllCars(carPath);
           IEnumerable<Manufacturer> manufacturers = DataReader.GetAllManufacturers(manufacturerPath);
           int userInput;
           while (1 == 1)
            {
                menuDisplay();
                userInput = int.Parse(Console.ReadLine());
                switch (userInput)
                {
                    case 1: listAllManufactureres(manufacturers);
                        break;
                    case 2: listAllViacleManufacturer(cars,manufacturers);
                        break;
                    case 3: carsPerMFG(cars,manufacturers);
                        break;
                    default: Console.WriteLine("please insert valid choice");
                        break;
                }
            }
        }

        private static void menuDisplay()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("please insert your choice:");
            Console.WriteLine("1: List of all manufacturers");
            Console.WriteLine("2: List of all vehicles of a specific manufacturer");
            Console.WriteLine("3: Number of cars per MFG");
        }

        private static void carsPerMFG(IEnumerable<Car> cars, IEnumerable<Manufacturer> manufacturers)
        {
            foreach (var manufacture in manufacturers)
            {
                Console.WriteLine($"{manufacture.Model}   {cars.Where(car => car.Model ==manufacture.Model).Count()}");
            }
        }

        private static void listAllViacleManufacturer(IEnumerable<Car> cars, IEnumerable<Manufacturer> manufacturers)
        {
            var orderedmanufacturers = manufacturers.OrderBy(manufacturer => manufacturer.Model)
                                                    .Select((item, index) => (index+1,item));
            foreach (var manufacturer in orderedmanufacturers)
            {
                Console.WriteLine($"{manufacturer.Item1}. {manufacturer.item.Model}");
            }

            //choose your index
            Console.WriteLine("Please select manufacturer by index");
            int choice=int.Parse(Console.ReadLine());
            var manmufacturecar = orderedmanufacturers.Where(item => item.Item1 == choice).First().item.Model;

            var manufatureCars= cars.Where(car => car.Model == manmufacturecar).OrderBy(item=>item.Carline);
            
            foreach (var manufacturer in manufatureCars)
            {
                Console.WriteLine($"{manufacturer.Model} , {manufacturer.Carline} , {manufacturer.ModelYear} , {manufacturer.EnginePower} , {manufacturer.CompinationFuelConsumption}");
            }
        }

        private static void listAllManufactureres(IEnumerable<Manufacturer> manufacturers)
        {
            var Orderedmanufacturers = manufacturers.OrderBy(manufacturer => manufacturer.Model).Select(Model=>Model);
            foreach (Manufacturer manufacturer in Orderedmanufacturers)
            {
                Console.WriteLine($"{manufacturer.Model}");
            }
        }
    }
}
