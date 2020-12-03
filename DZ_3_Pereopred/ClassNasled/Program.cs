using System;

namespace ClassNasled
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog1 = new Dog("Шарик", 2, 4, "Овчарка");
            Dog dog2 = new Dog("Филарин", 1, 4, "Спаниель");
            //использование обобщенных типов данных
            Shark<int> SharkT = new Shark<int>("Тигровая", 15, 0, 256);
            Shark<double> SharkK = new Shark<double>("Китовая", 10, 0, 12546.5);
            dog1.AMove();
            dog2.PrintInfo();
            SharkT.AMove();
            SharkK.PrintInfo();

            // Применение переопределенных методов (из класса Dog)
            Dog dog3 = new Dog("Филарин", 1, 4, "Спаниель");
            if (dog2.Equals(dog3))
            {
                Console.WriteLine("dog2 и dog3 - это одна и та же собака");
            }
            Console.WriteLine(dog3.ToString());
        }
    }
}
