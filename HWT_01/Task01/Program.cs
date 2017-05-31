/*
 * Задание 1
 * Написать консольное  приложение,  которое проверяет принадлежность точки заштрихованной области.
 * Пользователь  вводит координаты  точки  (x;y) и выбирает букву графика(a-к). В консоли должно высветиться сообщение: 
 * «Точка[(x;y)] принадлежит фигуре[г]».
 */

namespace Task01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Middleman middleman = new Middleman();
            for (;;)
            {
                middleman.ShowDialog();
            }
        }
    }
}
