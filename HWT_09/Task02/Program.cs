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
                    Console.WriteLine("{0} is a non-negative integer", input);//todo pn "является ли строка положительным целым числом" в каком месте ты увидел "натуральное число"?
                                                                        //Some definitions, including the standard ISO 80000-2, begin the natural numbers with 0, corresponding to the non-negative integers
                                                                        //https://en.wikipedia.org/wiki/Natural_number
                }
                else
                {
                    Console.WriteLine("{0} isn't a non-negative integer", input);
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
