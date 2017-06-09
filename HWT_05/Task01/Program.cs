/*
 * Написать  класс  Round,  задающий  круг  с  указанными  координатами центра, радиусом, 
 * а также свойствами, позволяющими узнать длину описанной  окружности  и  площадь  круга.  Обеспечить  нахождение 
 * объекта  в  заведомо  корректном  состоянии.  Написать  программу, демонстрирующую использование данного круга.
 */

namespace Task01
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Round round = new Round(10, 10, -10);
            DescribeRound(round);

            for (;;)
            {
                round.X = AskForDouble("X");
                round.Y = AskForDouble("Y");
                round.Radius = AskForDouble("Радиус");
                DescribeRound(round);
                Console.WriteLine("Для прекращения работы нажмите Esc;\nДля продолжения работы нажмите любую другую клавишу");

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
                Console.WriteLine("Некорректный {0}", name);
                Console.Write("Введите {0}: ", name);
            }

            return value;
        }

        private static void DescribeRound(Round r)
        {
            Console.WriteLine("Х: {0}", r.X);
            Console.WriteLine("Y: {0}", r.Y);
            Console.WriteLine("Радиус: {0}", r.Radius);
            Console.WriteLine("Площадь круга: {0}", r.Area);
            Console.WriteLine("Радиус описывающей окружности: {0}", r.Circumference);
        }
    }
}
