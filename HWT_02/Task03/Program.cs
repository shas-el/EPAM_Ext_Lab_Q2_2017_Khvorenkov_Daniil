/*
 * Написать программу, которая запрашивает с клавиатуры число N и 
 * выводит на экран следующее «изображение», состоящее из N строк: 
 *     *
 *    ***
 *   *****
 *  *******
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

            int n;
            string input;
            Console.Write("Введите количество строк: ");
            input = Console.ReadLine();

            while (!(int.TryParse(input, out n) && n > 0))
            {
                Console.WriteLine("Введено некорректное количество строк; введите положительное натуральное число");
                Console.Write("Введите количество строк: ");
                input = Console.ReadLine();
            }

            for (int i = 0; i < n; i++)
            {
                StringBuilder sb = new StringBuilder((n * 2) + 1);
                string whiteSpace = new string(' ', n - i);//todo не понял идеи с выделением переменных whiteSpace и s. Сразу бы лучше в StringBuilder добавил.
				string s = new string('*', (i * 2) + 1);
                Console.WriteLine(sb.Append(whiteSpace).Append(s));
            }

            Console.ReadKey();
        }
    }
}
