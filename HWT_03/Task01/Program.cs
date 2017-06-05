/*
 * Написать  программу,  которая  генерирует  случайным  образом 
 * элементы массива (число элементов в массиве и их тип определяются 
 * разработчиком), определяет для него максимальное и минимальное 
 * значения, сортирует массив и выводит полученный результат на экран. 
 * Примечание: LINQ запросы и готовые функции языка (Sort, Max и т.д.) 
 * использовать в данном задании запрещается.
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
            MyArray array = new MyArray(10);
            Console.WriteLine("Максимальное значение в массиве: {0}", array.Max());
            Console.WriteLine("Минимальное значение в массиве: {0}", array.Min());
            array.Sort();
            Console.WriteLine("Отсортированные элементы массива в порядке возрастания:");

            foreach (int i in array.Array)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}
