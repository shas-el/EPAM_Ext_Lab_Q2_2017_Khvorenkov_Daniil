/*
 * Написать  класс,  описывающий  треугольник  со  сторонами a,  b,  c,  и 
 * позволяющий осуществить расчёт его площади и периметра. Написать 
 * программу, демонстрирующую использование данного треугольника.
 */

namespace Task02
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Triangle triangle = new Triangle(1, 1, 10);
            DescribeTriangle(triangle);

            for (;;)
            {
                var a = AskForDouble("длина стороны a");
                var b = AskForDouble("длина стороны b");
                var c = AskForDouble("длина стороны c");
                var triangleIsCorrect = triangle.SetSides(a, b, c);

                if (!triangleIsCorrect)
                {
                    Console.WriteLine("Такой треугольник не может существовать\n");
                }

                DescribeTriangle(triangle);
                Console.WriteLine("Для прекращения работы нажмите Esc;\nДля продолжения работы нажмите любую другую клавишу\n\n");

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }

        private static double AskForDouble(string name)
        {
            double value;
            Console.Write("Введите {0}: ", name);

            while (!double.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Некорректная {0}", name);
                Console.Write("Введите {0}: ", name);
            }

            return value;
        }

        private static void DescribeTriangle(Triangle t)
        {
            Console.WriteLine("A: {0}", t.SideA);
            Console.WriteLine("B: {0}", t.SideB);
            Console.WriteLine("C: {0}", t.SideC);
            Console.WriteLine("Периметр треугольника: {0}", t.CalculatePerimeter());
            Console.WriteLine("Площадь треугольника: {0}\n", t.CalculateArea());
        }
    }
}
