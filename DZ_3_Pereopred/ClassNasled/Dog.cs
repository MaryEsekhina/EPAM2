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


        // Переопределение методов Tostring и Equals
        public override string ToString()
        {
            return String.Format("Собака, имя {0}, возраст {1}, порода {2}, количество лап {3} ", this.name, this.age, this.breed, this.legs);
        }

        public override bool Equals(object obj)
        {
            return obj is Dog dog &&
                   age == dog.age &&
                   legs == dog.legs &&
                   breed == dog.breed &&
                   name == dog.name;
        }
    }
}
