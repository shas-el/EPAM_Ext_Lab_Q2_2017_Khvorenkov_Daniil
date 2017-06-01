/*
 * Обеспечивает взаимодействие с пользователем 
 */

namespace Task01
{
    using System;
    using System.Text.RegularExpressions;

    public class Middleman
    {
        /// <summary>
        /// Просит пользователя ввести координаты точки и номер графика
        /// и выводит информацию о принадлежности точки фигуре
        /// </summary>
        public void ShowDialog()
        {

            string input;
            double x;
            double y;
            char plot;
            string belongs = " принадлежит фигуре ";

            x = this.AskForCoordinate("X");
            y = this.AskForCoordinate("Y");

            for (;;)
            {
                Console.Write("Введите номер графика: ");
                input = Console.ReadLine();

                if (this.IsPlotChar(input))
                {
                    plot = Convert.ToChar(input);
                    break;
                }

                Console.WriteLine("Введен некорректный номер графика; пожалуйста, попробуйте еще раз");
            }

            if (!(BelongingDeterminator.BelongsTo(x, y, plot)))
            {
                belongs = " не принадлежит фигуре ";
            }

            Console.WriteLine("Точка [(" + x + ";" + y + ")]" + belongs + "[" + plot + "]" + "\n\n" +
                              "******************************\n" +
                              "******************************\n");
        }

        /// <summary>
        /// Просит пользователя ввести координату;
        /// если координата некорректна, то просит еще раз.
        /// </summary>
        /// <param name="name">Имя координаты.</param>
        /// <returns>Значение координаты.</returns>
        private double AskForCoordinate(string name)
        {
            string input;
            double value;

            for (;;)
            {
                Console.Write("Введите координату " + name + ": ");
                input = Console.ReadLine();

                if (double.TryParse(input, out value))
                {
                    return value;
                }

                Console.WriteLine("Введена некорректная координата " + name +
                                  "; пожалуйста, попробуйте еще раз");
            }
        }

        /// <summary>
        /// Определяет, может ли строка быть преобразована в номер графика.
        /// </summary>
        /// <param name="s">Строка ввода</param>
        /// <returns>true, если строка подходит, иначе – false </returns>
        private bool IsPlotChar(string s)
        {
            Regex regex = new Regex(@"^[а-еж-ик]$");
            return regex.IsMatch(s);
        }
    }
}
