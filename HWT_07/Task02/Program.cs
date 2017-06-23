/*
 * Задан  английский  текст.  Выделить  отдельные  слова  и  для  каждого 
 * посчитать  частоту  встречаемости.  Слова,  отличающиеся  регистром, 
 * считать одинаковыми. В качестве разделителей считать пробел и точку.
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
            Middleman m = new Middleman();
            m.ShowDialog();
        }
    }
}
