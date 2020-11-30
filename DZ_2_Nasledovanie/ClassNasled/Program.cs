using System;

namespace ClassNasled
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog1 = new Dog("Шарик", 2, 4, "Овчарка");
            Dog dog2 = new Dog("Филарин", 1, 4, "Спаниель");
            Shark SharkT = new Shark("Тигровая", 15, 0, 256);
            Shark SharkK = new Shark("Китовая", 10, 0, 12546);
            dog1.AMove();
            dog2.PrintInfo();
            SharkT.AMove();
            SharkK.PrintInfo();
        }
    }
}
