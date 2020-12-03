using System;
using System.Collections.Generic;
using System.Linq;

namespace DZ4_Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            Cloths trousers = new Cloths("Брюки", 46);
            Cloths skirt = new Cloths("Юбка", 46);
            Cloths shorts = new Cloths("Шорты", 48);
            Cloths tshirt = new Cloths("Футболка", 48);
            Cloths dress = new Cloths("Платье", 44);
            Cloths blouse = new Cloths("Блузка", 48);
            List<Cloths> wardrobe = new List<Cloths>(){ trousers, skirt, shorts, tshirt, dress, blouse};
            List<Cloths> wardrobeSort = wardrobe.OrderBy(x => x.size).ToList();
            Console.WriteLine("Исходная коллекция:");
            foreach (Cloths x in wardrobe)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("Отсортированная коллекция:");
            foreach (Cloths x in wardrobeSort) 
            {
                Console.WriteLine(x);
            }
        }
    }
}
