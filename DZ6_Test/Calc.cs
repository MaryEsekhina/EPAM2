using System;
using System.Collections.Generic;
using System.Text;

namespace DZ6_Test
{
    public static class Calc
    {
        public static int Plus(int x, int y)
        {
            return x + y;
        }
        public static int Minus(int x, int y)
        {
            return x - y;
        }

        public static int Multipl(int x, int y)
        {
            return x * y;
        }
        public static int Div(int x, int y)
        {
            if (y == 0) return 0;
            return x / y;
        }
    }
}
