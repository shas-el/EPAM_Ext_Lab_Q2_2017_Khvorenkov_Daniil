/*
 * Напишите заготовку для векторного графического редактора. Полная 
 * версия редактора должна позволять создавать и выводить на экран 
 * такие фигуры как: Линия, Окружность, Прямоугольник, Круг, Кольцо. 
 * Заготовка,  для  упрощения,  должна  представлять  собой  консольное приложение с функционалом: 
 * 1. Создать фигуру выбранного типа по произвольным координатам. 
 * 2. Вывести фигуры на экран (для каждой фигуры вывести на консоль её тип и значения параметров).
 */

namespace Task03
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Editor editor = new Editor();

            for (;;)
            {
                editor.ShowDialog();
                Console.WriteLine("Для прекращения работы нажмите Esc;\nДля продолжения работы нажмите любую другую клавишу\n");

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }
    }
}
