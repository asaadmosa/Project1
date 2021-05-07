using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Entities
{
    public class Car
    {
        public int ModelYear { get; set; }
        public string Model { get; set; }
        public string Carline { get; set; }
        public double EnginePower { get; set; }
        public int Cylinder { get; set; }
        public double CityFuelConsumption { get; set; }
        public double HiWayFuelConsumption { get; set; }
        public double CompinationFuelConsumption { get; set; }
    }
}
