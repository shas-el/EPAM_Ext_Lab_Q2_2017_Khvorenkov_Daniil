/*
 * Создать  класс  Ring  (кольцо),  описываемое  координатами  центра, внешним и внутренним радиусами,
 * а также свойствами, позволяющими  * узнать  площадь  кольца  и  суммарную  длину  внешней  и  внутренней границ кольца.
 * Обеспечить нахождение класса в заведомо корректном состоянии.
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
            Ring r = new Ring(10, 10, 20, 10);
            Console.WriteLine("Координаты центра: [{0} ; {1}]", r.X, r.Y);
            Console.WriteLine("Внутренний радиус: {0}", r.InnerRadius);
            Console.WriteLine("Внешний радиус: {0}", r.Radius);
            Console.WriteLine("Длина внешней окружности: {0}", ((Disc)r).Circumference);
            Console.WriteLine("Сумма длин окружностей: {0}", r.Circumference);
            Console.WriteLine("Площадь кольца: {0}", r.Area);
            Console.ReadKey();
        }
    }
}
