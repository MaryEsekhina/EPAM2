using System;
using System.Collections.Generic;
using System.Text;

namespace ClassNasled
{
    class Dog : Animal
    {
        string breed;
        string name;

        public override void AMove()
        {
            Console.WriteLine("Собака бегает");
        }

        public Dog(string name, int age, int legs, string breed) : base(age, legs)
        {
            this.breed = breed;
            this.name = name;
        }

        public override void PrintInfo()
        {
            Console.WriteLine("Собаку зовут {0}, ей {1} лет, её порода {2}", name, age, breed);
        }
    }
}
