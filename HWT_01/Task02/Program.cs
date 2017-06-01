/*
 * Задание 2
 * Программа должна выводить пользователю промежуточные вычисления 
 * (например, a, b, c и дискриминант (если вычисляли при помощи него) и корни (если есть))
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

            Solver s = new Solver();

            for (;;)
            {
                s.ShowDialog();
            }
        }
    }
}
