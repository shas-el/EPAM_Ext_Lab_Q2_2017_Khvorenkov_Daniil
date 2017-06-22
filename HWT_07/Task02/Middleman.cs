/*
 * Обеспечивает взаимодействие с пользователем 
 */

namespace Task02
{
    using System;

    public class Middleman
    {
        public void ShowDialog()
        {
            for (;;)
            {
                TextProcessor processor = new TextProcessor();
                Console.WriteLine("Enter line:");
                processor.Text = Console.ReadLine();
                Console.WriteLine(processor.GetWordsList());
                Console.WriteLine("Press Esc to exit;\nPress any other key to continue\n");

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    break;
                }

                Console.Write("\b");
            }
        }
    }
}