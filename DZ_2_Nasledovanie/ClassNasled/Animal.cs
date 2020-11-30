using System;
using System.Collections.Generic;
using System.Text;

namespace ClassNasled
{
    abstract class Animal
    {
        public int age;
        public int legs;

        abstract public void AMove();

        public Animal( int age, int legs)
        {
            this.age = age;
            this.legs = legs;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine("Информация о животном");
        }

    }
}
