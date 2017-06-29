/*
 * Напишите расширяющий метод, который определяет сумму элементов массива.
 */

namespace Task01
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int[] intArray = { 0, 1, 2, 3, 4, 5 };
            Console.WriteLine(intArray.Sum());

            double[] doubleArray = { 0.5, 0.25, 0.125, 0.0625, 0.03125 };
            Console.WriteLine(doubleArray.Sum());

            Console.ReadKey();
        }
    }
}
