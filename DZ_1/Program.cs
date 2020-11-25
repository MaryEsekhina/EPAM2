using System;

namespace DZ_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Программа для работы с массивом - 1");
            Console.WriteLine("Программа-калькулятор - 2");
            Console.WriteLine("Ваш выбор? 1/2");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine(" ");
            if (n == 1)
            {
                Console.WriteLine("Вы выбрали работу с массивом");
                int[] arr = Cl_Array.InputArray();
                Cl_Array.Sort(arr);
                Cl_Array.OutputArray(arr);
            }
            else if (n==2)
            {
                Console.WriteLine("Вы выбрали калькулятор");
                float rezult;
                float x = Calc.InputF("число1"); 
                float y = Calc.InputF("число2");
                char znak = Calc.InputC("вид операции, +. -. *. /");
                rezult = Calc.Result(x, y, znak);
                Console.WriteLine("Результат равен: {0}", rezult);
            }
            else
            {
                Console.WriteLine("Ваш выбор некорректен");
            }
        }
    
    }
}
