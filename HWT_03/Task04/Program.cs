/*
 * Элемент двумерного массива считается стоящим на чётной позиции, 
 * если  сумма  номеров  его  позиций  по  обеим  размерностям  является 
 * чётным  числом  (например,  [1,1] – чётная  позиция,  а  [1,2] -нет).  
 * Определить сумму элементов массива, стоящих на чётных позициях.
 */

namespace Task04
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            MyArray array = new MyArray(4);
            Console.WriteLine("Элементы массива:\n{0}\n", array.ElementsString());
            Console.WriteLine("Сумма четных элементов: {0}", array.EvensSum());
            Console.ReadKey();
        }
    }
}
