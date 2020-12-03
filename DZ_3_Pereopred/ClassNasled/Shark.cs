using System;
using System.Collections.Generic;
using System.Text;

namespace ClassNasled
{
    class Shark<T> : Animal
    {
        T quantityTeeth;
        string type;

        public override void AMove()
        {
            Console.WriteLine("Акула плывет");
        }

        public Shark(string type, int age, int legs, T teeth) : base(age, legs)
        {
            quantityTeeth = teeth;
            this.type = type;
        }
        public override void PrintInfo()
        {
            Console.WriteLine("Это {0} акула, у неё {1} зубов", type, quantityTeeth);
        }
    }
}
