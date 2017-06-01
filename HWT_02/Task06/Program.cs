/*
 * Для  выделения  текстовой  надписи  можно  использовать  выделение жирным,  курсивом  и  подчёркиванием.
 * Предложите  способ  хранения информации  о  выделении  надписи  и  напишите  программу,
 * которая позволяет назначать и удалять текстовой надписи выделение
 */


namespace Task06
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            bool[] state = new bool[3];

            for (;;)
            {
                StringBuilder builder = new StringBuilder();

                if (state[0])
                {
                    builder.Append("Bold ");
                }

                if (state[1])
                {
                    builder.Append("Italic ");
                }

                if (state[2])
                {
                    builder.Append("Underline");
                }

                Console.WriteLine("Параметры надписи: {0}", builder);
                Console.WriteLine("Введите:\n\t1: bold\n\t2: italic\n\t3: underline\n\t4: clear");

                switch (Console.ReadLine())
                {
                    case "1":
                        state[0] = !state[0];
                        break;
                    case "2":
                        state[1] = !state[1];
                        break;
                    case "3":
                        state[2] = !state[2];
                        break;
                    case "4":
                        state = new bool[3];
                        break;
                }
            }
        }
    }
}
