using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex3;

namespace Ex3
{
    public class Car : Vehicle
    {
        public Car(string aColor) : base(aColor)
        {
            TypeOfVehicle = "car";
            Color = aColor;
        }
        public override void MakeSound()
        {
            Console.Beep();
        }
        public override void PresentVehicle()
        {
            Console.WriteLine($"Hi, I'm a {Color} car and I will make no sound.");
        }
    }
}
