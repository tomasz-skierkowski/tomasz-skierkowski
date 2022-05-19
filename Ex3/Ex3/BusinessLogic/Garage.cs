using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Ex3;

namespace Ex3
{
    public class Garage
    {
        public string name;
        public int maxNumberOfVehicles;
        public Garage(string aName)
        {
            name = aName;
        }


        private List<Vehicle> vehicles = new List<Vehicle>();

        public int AddNewVehicle(Vehicle vehicle)
        {
            if (vehicles.Count < maxNumberOfVehicles)
            {
                vehicles.Add(vehicle);
                return vehicles.Count;
            }
            else
            {
                return -1;
            }
        }
        public int CountVehicles()
        {
            return vehicles.Count;
        }

        public void PrintAllVehicles()
        {

            foreach (var vehicle in vehicles)
            {
                vehicle.PresentVehicle();
                Thread.Sleep(2000);
                Console.WriteLine();
            }


        }
    }
}
