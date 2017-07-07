/*
 * Напишите расширяющий метод, который определяет, является ли 
 * строка положительным целым числом. Методы Parse и TryParse не использовать.
 */

namespace Task02
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            for (;;)
            {
                Console.WriteLine("Enter line:");
                var input = Console.ReadLine();

                if (input.IsNaturalNumber())
                {
                    Console.WriteLine("{0} is a natural number", input);//todo pn "является ли строка положительным целым числом" в каком месте ты увидел "натуральное число"?
				}
                else
                {
                    Console.WriteLine("{0} isn't a natural number", input);
                }

                Console.WriteLine("\nPress Esc to exit program; Press any other key to continue\n");

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    break;
                }

                Console.Write("\b");
            }
        }
    }
}
