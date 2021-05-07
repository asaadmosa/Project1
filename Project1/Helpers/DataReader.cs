using Project1.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Helpers
{
    public static class DataReader
    {
        public static IEnumerable<Car> GetAllCars(string path)
        {
            return File.ReadAllLines(path).Skip(1).Select(line => ToCar(line));
        }

        public static Car ToCar(this string source)
        {
            var carS = source.Split(',');

            return new Car
            {
                ModelYear = int.Parse(carS[0]),
                Model = carS[1],
                Carline = carS[2],
                EnginePower = double.Parse(carS[3]),
                Cylinder = int.Parse(carS[4]),
                CityFuelConsumption = double.Parse(carS[5]),
                HiWayFuelConsumption = double.Parse(carS[6]),
                CompinationFuelConsumption = double.Parse(carS[6])
            };
        }


        public static IEnumerable<Manufacturer> GetAllManufacturers(string path)
        {
            return File.ReadAllLines(path).Select(line => ToManufacturer(line));
        }

        public static Manufacturer ToManufacturer(this string source)
        {
            var manufacturerS = source.Split(',');

            return new Manufacturer
            {
                Model = manufacturerS[0],
                Country= manufacturerS[1],
                ModelYear = int.Parse(manufacturerS[2])
            };
        }
    }
}
