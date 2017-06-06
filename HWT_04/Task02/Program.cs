/*
 * Написать программу, которая удваивает в первой введенной строки все 
 * символы, принадлежащие второй введенной строке.
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
            string s1 = string.Empty;
            string s2 = string.Empty;
            StringBuilder sb = new StringBuilder();

            while (string.IsNullOrEmpty(s1))
            {
                Console.WriteLine("Введите первую строку:");
                s1 = Console.ReadLine();
            }

            while (string.IsNullOrEmpty(s2))
            {
                Console.WriteLine("Введите первую строку:");
                s2 = Console.ReadLine();
            }

            foreach (char c in s1)
            {
                if (s2.Contains(c.ToString()))
                {
                    sb.Append(c, 2);
                }
                else
                {
                    sb.Append(c);
                }
            }

            Console.WriteLine("Результирующая строка:\n{0}", sb);
            Console.ReadKey();
        }
    }
}
