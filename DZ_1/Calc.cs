using System;
using System.Collections.Generic;
using System.Text;

namespace DZ_1
{
    class Calc
    {
        static public float Result(float x, float y, char z)
        {
            float r;
            switch (z)
            {
                case '+':  r = x + y; break;
                case '-': r = x - y; break;
                case '*':  r = x * y; break;
                case '/':  r = x / y; break;
                default: { r = 0; Console.WriteLine("Введено неверное значение операции"); } break;
            }
            return r;
        }

        static public float InputF(string name)
        {
            Console.WriteLine("Введите {0}", name);
            float x;
             try
            {
                x = float.Parse(Console.ReadLine());
             }
            catch (FormatException)
            {
                Console.WriteLine("Введено неверное значение. Аргументу присвоено значение 0");
                x = 0;
            }
             return x;
            }
        static public char InputC(string name)
        {
            Console.WriteLine("Введите {0}", name);
            char x;
            try
            {
                x = char.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Введена неверная операция. Вычисление производиться не будет");
                x = ' ';
            }
            return x;
        }

    }
}
