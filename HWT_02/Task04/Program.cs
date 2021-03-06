﻿/*
 * Написать  программу,  которая  запрашивает  с  клавиатуры  число  N  и 
 * выводит  на  экран  следующее  «изображение»,  состоящее  из  N 
 * треугольников: 
 *      *
 *      *
 *     ***
 *      *
 *     ***
 *    ***** 
 */

namespace Task04
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            int n;
            string input;
            Console.Write("Введите количество треугольников: ");
            input = Console.ReadLine();

            while (!(int.TryParse(input, out n) && n > 0))
            {
                Console.WriteLine("Введено некорректное количество треугольников; введите положительное натуральное число");
                Console.Write("Введите количество треугольников: ");
                input = Console.ReadLine();
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    StringBuilder sb = new StringBuilder((i * 2) + 1);
                    Console.WriteLine(sb.Append(' ', n - j).Append('*', (j * 2) + 1));
                }
            }

            Console.ReadKey();
        }
    }
}
