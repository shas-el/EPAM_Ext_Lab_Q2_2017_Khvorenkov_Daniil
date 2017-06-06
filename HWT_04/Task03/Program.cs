/*
 * Проведите сравнительный  анализ  скорости  работы  классов String  и 
 * StringBuilder для операции сложения строк
 */

namespace Task03
{
    using System;
    using System.Diagnostics;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            var n1 = 10;
            var n2 = 100;
            var n3 = 1000;
            Compare(n1);
            Compare(n2);
            Compare(n3);
            Console.ReadKey();
        }

        private static void Compare(int n)
        {
            Stopwatch sw = new Stopwatch();
            string s = string.Empty;
            StringBuilder sb = new StringBuilder();
            sw.Start();

            for (int i = 0; i < 160; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    s += "*";
                }
            }

            sw.Stop();
            Console.WriteLine(
                "Время при сложении {0} строк (в тиках): {1}",
                n,
                sw.ElapsedTicks / (double)160);
            sw.Restart();

            for (int i = 0; i < 160; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    sb.Append("*");
                }
            }

            sw.Stop();
            Console.WriteLine(
                "Время при сложении {0} строк с использованием StringBuilder: {1}",
                n,
                sw.ElapsedTicks / (double)160);
        }
    }
}
