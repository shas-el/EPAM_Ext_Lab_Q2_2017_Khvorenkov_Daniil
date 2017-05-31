/*
 * Написать программу, которая определяет площадь прямоугольника со 
 * сторонами a и b. Если пользователь вводит некорректные значения 
 * (отрицательные,  или  0),  должно  выдаваться  сообщение  об  ошибке. 
 * Возможность ввода пользователем строки вида «абвгд», или нецелых
 * чисел игнорировать.
 */  

namespace Task01
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            string input;
            int a;
            int b;
            Console.Write("Введите a: ");
            input = Console.ReadLine();

            while (!(int.TryParse(input, out a) && a > 0))
            {
                Console.WriteLine("Введено некорректное а; введите положительное натуральное число");
                Console.Write("Введите a: ");
                input = Console.ReadLine();
            }

            Console.Write("Введите b: ");
            input = Console.ReadLine();

            while (!(int.TryParse(input, out b) && b > 0))
            {
                Console.WriteLine("Введено некорректное b; введите положительное натуральное число");
                Console.Write("Введите b: ");
                input = Console.ReadLine();
            }

            Console.WriteLine("Площадь прямоугольника со сторонами {0} и {1} равна {2}", a, b, (long)a * b);
            Console.ReadKey();
        }
    }
}
