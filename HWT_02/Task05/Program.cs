/*
 * Если выписать все натуральные числа меньше 10, кратные 3, или 5, то 
 * получим  3,  5,  6  и  9.  Сумма  этих  чисел  будет  равна  23.  Напишите 
 * программу, которая выводит на экран сумму всех чисел меньше 1000, кратных 3, или 5. 
 */

using System.Text;

namespace Task05
{
    using System;

    public class Program//todo pn ответ неправильный, правильный ответ 233168
    {
        public static void Main(string[] args)
        {
	        Console.InputEncoding = Encoding.Unicode;
	        Console.OutputEncoding = Encoding.Unicode;

			int sum = 0;
            int max = 1000;
            int firstNumber = 3;
            int secondNmber = 5;

            for (int i = firstNumber; i < max; i += firstNumber)
            {
                sum += i;
            }

            for (int i = secondNmber; i < max; i += secondNmber)
            {
                sum += i;
            }

            Console.WriteLine("Сумма наутральных чисел меньше {0} и кратных 3 или 5 равна {1}", max, sum);
            Console.ReadKey();
        }
    }
}
