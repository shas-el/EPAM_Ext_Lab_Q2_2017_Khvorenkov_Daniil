/*
 * Написать  программу,  которая  определяет  сумму  неотрицательных 
 * элементов в одномерном массиве. Число элементов в массиве и их тип 
 * определяются разработчиком.
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
            MyArray array = new MyArray(10);
            StringBuilder sb = new StringBuilder();
            
            foreach (int i in array.Array)
            {
                sb.AppendFormat("{0}  ", i);
            }

            Console.WriteLine("Элементы массива:\n{0}\n", sb);
            Console.WriteLine("Сумма положительных элементов массива:\n{0}", array.NaturalsSum());
            Console.ReadKey();
        }
    }
}
