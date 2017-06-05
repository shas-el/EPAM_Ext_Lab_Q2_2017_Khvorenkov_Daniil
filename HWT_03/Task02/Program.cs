/*
 * Написать программу, которая заменяет все положительные элементы 
 * в трёхмерном массиве на нули. Число элементов в массиве и их тип 
 * определяются разработчиком
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
            MyArray array = new MyArray(2);
            Console.WriteLine("Элементы массива:\n{0}\n", array.ElementsString());
            array.NaturalsToZero();
            Console.WriteLine("Элементы массива после обработки:\n{0}", array.ElementsString());
            Console.ReadKey();
        }
    }
}
