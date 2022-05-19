using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex3;

namespace Ex3
{
    public class Bus : Vehicle
    {
        public Bus(string aColor) : base(aColor)
        {
            TypeOfVehicle = "bus";
            Color = aColor;
        }
        public override void MakeSound()
        {
            Console.Beep();
            Console.Beep();
            Console.Beep();
        }
    }
}
