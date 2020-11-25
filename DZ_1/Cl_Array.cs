using System;
using System.Collections.Generic;
using System.Text;

namespace DZ_1
{
    class Cl_Array
    {
        public static int[] InputArray()
        {
            int n;
            Console.Write("Введите число элементов массива: ");
            n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("Введите arr[{0}] ", i);
                arr[i] = int.Parse(Console.ReadLine());
            }
            return arr;
        }

        public static int[] Sort(int[] arr)
        {
            int temp;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            return arr;
        }

        public static void OutputArray(int[] arr)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Элементы отсортированного массива:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("arr[{0}] = {1}", i, arr[i]);
            }
        }

    }
}
