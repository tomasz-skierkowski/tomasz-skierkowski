using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex3;

namespace Ex3
{
    public abstract class Vehicle
    {

        protected string Color { get; set; }

        protected string TypeOfVehicle;

        public Vehicle(string aColor)
        {
            Color = aColor;
        }
        public abstract void MakeSound();
        public virtual void PresentVehicle()
        {
            Console.WriteLine($"I am {Color} {TypeOfVehicle}.");
            MakeSound();
        }

        public override string ToString()
        {

            return $"{Color} {TypeOfVehicle}";
        }
    }

}
