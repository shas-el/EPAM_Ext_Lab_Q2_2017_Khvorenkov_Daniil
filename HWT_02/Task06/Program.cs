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
        private enum State
        {
            None, 
            Bold,
            Italic,
            Underline = 4,
        }

        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            int state = 0;
	        string stateString;

			for (;;)
            {
                switch (state) //todo pn не самое оптимальное решение. Если добавится ещё выделение цветом? сколько будет веток у switch? Лучше уж флажки добавить на каждый стиль или просто дополнять строку выбранным стилем.
                {
                    case 0:
                        stateString = "None";
                        break;
                    case 1:
                        stateString = "Bold";
                        break;
                    case 2:
                        stateString = "Italic";
                        break;
                    case 3:
                        stateString = "Bold, Italic";
                        break;
                    case 4:
                        stateString = "Underline";
                        break;
                    case 5:
                        stateString = "Bold, Underline";
                        break;
                    case 6:
                        stateString = "Italic, Underline";
                        break;
                    case 7:
                        stateString = "Bold, Italic, Underline";
                        break;
                    default:
                        stateString = "Something went horribly wrong";
                        break;
                }

                Console.WriteLine("Параметры надписи: {0}", stateString);
                Console.WriteLine("Введите:\n\t1: bold\n\t2: italic\n\t3: underline\n\t4: clear");

                switch (Console.ReadLine())
                {
                    case "1":
                        state = state ^ (int)State.Bold;
                        break;
                    case "2":
                        state = state ^ (int)State.Italic;
                        break;
                    case "3":
                        state = state ^ (int)State.Underline;
                        break;
                    case "4":
                        state = state & (int)State.None;
                        break;
                }
            }
        }
    }
}
