﻿/*
 * Если выписать все натуральные числа меньше 10, кратные 3, или 5, то 
 * получим  3,  5,  6  и  9.  Сумма  этих  чисел  будет  равна  23.  Напишите 
 * программу, которая выводит на экран сумму всех чисел меньше 1000, кратных 3, или 5. 
 */

namespace Task05
{
    using System;
    using System.Text;

    public class Program//todo pn ответ неправильный, правильный ответ 233168
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            int sum = 0;
            int max = 1000;
            int firstNumber = 3;
            int secondNumber = 5;

            for (int i = 0; i < max; i++)
            {
                if ((i % firstNumber == 0) || (i % secondNumber == 0))
                {
                    sum += i;
                }
            }

            Console.WriteLine("Сумма наутральных чисел меньше {0} и кратных 3 или 5 равна {1}", max, sum);
            Console.ReadKey();
        }
    }
}
