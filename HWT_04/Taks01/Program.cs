/* Написать  программу,  которая  определяет  среднюю  длину  слова  во 
 * введенной текстовой строке. Учесть, что символы пунктуации на длину 
 * слов влиять не должны. Регулярные выражения не использовать. И не 
 * пытайтесь прописать все ручками. Используйте стандартные методы 
 * класса String.
 */

namespace Taks01
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            string s = "";

            while (string.IsNullOrWhiteSpace(s))
            {
                Console.WriteLine("Введите строку:");
                s = Console.ReadLine();
            }

            var wordsNumber = 0;
            var charsNumber = 1;
            s.Trim();

            if (char.IsPunctuation(s, 0))
            {
                charsNumber = 0;
            }
            else
            {
                wordsNumber = 1;
            }

            for (int i = 1; i < s.Length; i++)
            {
                if (!(char.IsPunctuation(s, i) || char.IsSeparator(s, i)))
                {
                    charsNumber++;
                    if (char.IsPunctuation(s, i - 1) || char.IsSeparator(s, i - 1))
                    {
                        wordsNumber++;
                    }
                }
            }

            Console.WriteLine(
                "Количество значимых символов: {0}\nКоличество слов: {1}\nСредняя длина слова: {2}",
                charsNumber,
                wordsNumber,
                wordsNumber == 0 ? 0 : (double)charsNumber / wordsNumber);
            Console.ReadKey();
        }
    }
}
