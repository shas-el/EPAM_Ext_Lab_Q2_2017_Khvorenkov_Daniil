/*
 * Взаимодействует с пользователем и решает уравнение
 */

namespace Task02
{
    using System;

    public class Solver
    {
        private double h;
        private double a;
        private double b;
        private double c;
        private double discriminant;

        public void ShowDialog()
        {
            h = this.AskForH("h");
            a = this.CalculateA(h);
            Console.Write("a = " + a);//todo pn здесь лучше билдить всё в строку и один раз в конце метода вывести в консоль (побыстрее будет).
            b = this.CalculateB(h, a);
            Console.Write(", b = " + b);
            c = this.CalculateC(h, a, b);
            Console.WriteLine(", c = " + c);
            discriminant = this.CalculateDiscriminant(a, b, c);
            Console.WriteLine("discriminant = " + discriminant);

            if (discriminant > 0)
            {
                double rootOne = (-b + Math.Sqrt((b * b) - (4 * a * c))) / (2 * a);
                double rootTwo = (-b - Math.Sqrt((b * b) - (4 * a * c))) / (2 * a);
                Console.Write("x[1] = " + rootOne);
                Console.WriteLine("x[2] = " + rootTwo + "\n");
            }

            if (discriminant == 0)
            {
                double root = -(b / (2 * a));
                Console.WriteLine("x = " + root + "\n");
            }

            if (discriminant < 0)
            {
                Console.WriteLine("Вещественных корней нет\n");
            }

            Console.WriteLine("***********************\n" +
                              "***********************\n");
        }

        /// <summary>
        /// Просит пользователя ввести коэффициент;
        /// если коэффициент некорректен, то просит еще раз.
        /// </summary>
        /// <param name="name">Имя коэффициента.</param>
        /// <returns>Значение коэффициента.</returns>
        private double AskForH(string name)
        {
            string input;
            double value;

            for (;;)
            {
                Console.Write("Введите коэффициент " + name + ": ");
                input = Console.ReadLine();

                if (double.TryParse(input, out value))
                {
                    return value;
                }

                Console.WriteLine("Введен некорректный коэффициент " + name +
                                  "; пожалуйста, попробуйте еще раз");
            }
        }

        private double CalculateA(double h)
        {
            return Math.Sqrt(Math.Abs(Math.Sin(8 * h) + 17) /
                             Math.Pow(1 - (Math.Sin(4 * h) * Math.Cos((h * h) + 18)), 2));
        }

        private double CalculateB(double h, double a)
        {
            return 1 - Math.Sqrt(3 / (3 + Math.Abs(Math.Tan(a * h * h) - Math.Sin(a * h))));
        }

        private double CalculateC(double h, double a, double b)
        {
            return (a * h * h * Math.Sin(b * h)) + (b * Math.Pow(h, 3) * Math.Cos(a * h));
        }

        private double CalculateDiscriminant(double a, double b, double c)
        {
            return (b * b) - (4 * a * c);
        }
    }
}
